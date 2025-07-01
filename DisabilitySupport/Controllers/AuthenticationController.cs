using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DisabilitySupport.BLL.Interfaces;
using DisabilitySupport.DAL.Data;
using DisabilitySupport.DAL.Models;
using DisabilitySupport.DAL.Models.Authentication;
using DisabilitySupport.DAL.Models.Authentication.LogIn;
using DisabilitySupport.DAL.Models.Authentication.SignUp;
using DisabilitySupport.DAL.Models.Enumerations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DisabilitySupport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IEmailService emailService;
        private readonly IConfiguration configuration;
        private readonly ApplicationDbContext _context;

        public AuthenticationController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IEmailService emailService,
            IConfiguration configuration,
            ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.emailService = emailService;
            this.configuration = configuration;
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromQuery] string role, [FromBody] RegisterUser registerUser)
        {
            var userExists = await userManager.FindByEmailAsync(registerUser.Email);
            if (userExists != null)
                return StatusCode(StatusCodes.Status403Forbidden,
                    new Response { Status = "Error", Message = "User Already Exists!" });

            var user = new ApplicationUser
            {
                Email = registerUser.Email,
                UserName = registerUser.Email,
                FullName = registerUser.FullName,
                PhoneNumber = registerUser.Phone,
                Address = registerUser.Address,
                Zone = registerUser.Region,
                CreatedAt = DateTime.UtcNow,
                DateOfBirth = string.IsNullOrEmpty(registerUser.Birthday) ? null : DateTime.Parse(registerUser.Birthday),
                Gender = Enum.TryParse(registerUser.Gender, out Gender genderValue) ? genderValue : null,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            if (!await roleManager.RoleExistsAsync(role))
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response { Status = "Error", Message = "Role doesn’t exist!" });

            var result = await userManager.CreateAsync(user, registerUser.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response { Status = "Error", Message = "User creation failed!" });

            await userManager.AddToRoleAsync(user, role);

            
            if (registerUser.IsDisabled && role == "Patient")
            {
                Console.WriteLine(" test enter condition Patient + IsDisabled");
                var disabled = new Disabled
                {
                    UserId = user.Id,
                    DisabilityType = registerUser.DesabilityType ?? "",
                    MedicalConditionDescription = registerUser.MedicalCondition,
                    EmergencyContactName = registerUser.EmergencyContactName,
                    EmergencyContactPhone = registerUser.EmergencyContactPhone,
                    EmergencyContactRelation = registerUser.EmergencyContactRelation
                };
                _context.DisabledPeople!.Add(disabled);
            }
            else if (!registerUser.IsDisabled && role == "Helper")
            {
                var helper = new Helper
                {
                    UserId = user.Id,
                    Bio = registerUser.Description
                };
                _context.Helpers!.Add(helper);
            }

            await _context.SaveChangesAsync();

        
            var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = Url.Action(nameof(ConfirmEmail), "Authentication",
                new { token, email = user.Email }, Request.Scheme);
            var message = new Message(new[] { user.Email! }, "Confirm your email", confirmationLink!);
            emailService.sendEmail(message);

            return Ok(new Response
            {
                Status = "Success",
                Message = $"User created successfully and email sent to {user.Email}!"
            });
        }

        [HttpGet("confirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response { Status = "Error", Message = "This user doesn't exist!" });

            var result = await userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
                return Ok(new Response { Status = "Success", Message = "Email verified successfully!" });

            return StatusCode(StatusCodes.Status500InternalServerError,
                new Response { Status = "Error", Message = "Email verification failed!" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUser loginUser)
        {
            var user = await userManager.FindByEmailAsync(loginUser.Email);
            if (user == null || !await userManager.CheckPasswordAsync(user, loginUser.Password))
                return Unauthorized("Invalid credentials");

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(ClaimTypes.Name, user.Email!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
            };

            var userRoles = await userManager.GetRolesAsync(user);
            foreach (var userRole in userRoles)
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));

            var token = GetToken(authClaims);
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }

        [HttpPost("forgotpassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([Required] string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
                return BadRequest(new Response { Status = "Error", Message = "Could not send email." });

            var token = await userManager.GeneratePasswordResetTokenAsync(user);
            var resetLink = Url.Action(nameof(ResetPassword), "Authentication",
                new { token, email = user.Email }, Request.Scheme);
            var message = new Message(new[] { user.Email! }, "Reset your password", resetLink!);
            emailService.sendEmail(message);

            return Ok(new Response
            {
                Status = "Success",
                Message = $"Password reset link sent to {user.Email}!"
            });
        }

        [HttpGet("resetPassword")]
        public IActionResult ResetPassword(string token, string email)
        {
            return Ok(new ResetPasswordModel { Token = token, Email = email });
        }

        [HttpPost("resetPassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return BadRequest(new Response { Status = "Error", Message = "User not found!" });

            var result = await userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description).ToList();
                return BadRequest(new { Status = "Error", Errors = errors });
            }

            return Ok(new Response { Status = "Success", Message = "Password reset successfully!" });
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]!));

            return new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
            );
        }
    }
}
