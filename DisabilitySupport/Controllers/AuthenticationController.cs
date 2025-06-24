using DisabilitySupport.DAL.Models;
using DisabilitySupport.DAL.Models.Authentication;
using DisabilitySupport.DAL.Models.Authentication.SignUp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DisabilitySupport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;
        public AuthenticationController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUser registerUser, string role)
        {
            var userExists = await userManager.FindByEmailAsync(registerUser.Email);
            if (userExists != null)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new Response { Status = "Error", Message = "User Already Exists!" });
            }

            ApplicationUser user = new() { 
            Email = registerUser.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            FullName = registerUser.FullName,
                UserName = registerUser.FullName
            };

            if (await roleManager.RoleExistsAsync(role))
            {
                var result = await userManager.CreateAsync(user, registerUser.Password);
                if (!result.Succeeded)
                {

                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User Failed to be created!" });
                }

                await userManager.AddToRoleAsync(user, role);
                return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "User created successfully!" });


            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Role doesn`t exist!" });

            }

        }
    }
}
