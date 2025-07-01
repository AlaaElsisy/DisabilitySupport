using System.Security.Claims;
using DisabilitySupport.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DisabilitySupport.Api.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
    public class HelperController : ControllerBase
    {
        public IHelperService _helperService { get; }

        public HelperController(IHelperService helperService)
        {
            _helperService = helperService;
        }
        [Authorize(Roles = "Helper")]
        [HttpGet("id")]
        public async Task<IActionResult> GetHelperId()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); 

            if (string.IsNullOrEmpty(userId))
                return Unauthorized("Invalid token.");

            var helperId = await _helperService.GetHelperIdByUserIdAsync(userId);

            if (helperId == null)
                return NotFound("Helper not found.");

            return Ok(new { helperId });
        }
    }
}
