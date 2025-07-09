using DisabilitySupport.BLL.Interfaces;
using DisabilitySupport.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[Route("api/[controller]")]
[ApiController]
public class UserProfileController : ControllerBase
{
    private readonly IUserProfileService _profileService;
    private readonly UserManager<ApplicationUser> _userManager;

    public UserProfileController(IUserProfileService profileService, UserManager<ApplicationUser> userManager)
    {
        _profileService = profileService;
        _userManager = userManager;
    }

    [HttpGet("patient")]
   // [Authorize(Roles = "Patient")]
    public async Task<IActionResult> GetDisabledProfile([FromQuery] string userId)
    {
       // var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var profile = await _profileService.GetDisabledProfileAsync(userId!);
        if (profile == null) return NotFound();
        return Ok(profile);
    }

    [HttpGet("helper")]
    //[Authorize(Roles = "Helper")]
    public async Task<IActionResult> GetHelperProfile([FromQuery] string userId)
    {
        //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var profile = await _profileService.GetHelperProfileAsync(userId!);
        if (profile == null) return NotFound();
        return Ok(profile);
    }


    [HttpGet("helper/data")]
    [Authorize(Roles = "Helper")]
    public async Task<IActionResult> GetMyHelperProfile()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId)) return Unauthorized();

        var profile = await _profileService.GetHelperProfileAsync(userId);
        if (profile == null) return NotFound();

        return Ok(profile);
    }
    [HttpGet("patient/data")]
    [Authorize(Roles = "Patient")]
    public async Task<IActionResult> GetMyPatientProfile()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId)) return Unauthorized();

        var profile = await _profileService.GetDisabledProfileAsync(userId);
        if (profile == null) return NotFound();

        return Ok(profile);
    }
}
