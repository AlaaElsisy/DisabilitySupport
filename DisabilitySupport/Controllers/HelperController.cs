using System.Security.Claims;
using DisabilitySupport.BLL.Interfaces;
using DisabilitySupport.BLL.Services;
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


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _helperService.GetByIdAsync(id);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Unexpected error.", details = ex.Message });
            }
        }
    }
}
