using DisabilitySupport.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DisabilitySupport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class DisabledController : ControllerBase
    { 
        private readonly IDisabledService _disabledService;

        public DisabledController(IDisabledService disabledService)
        {
            _disabledService = disabledService;
        }

        [HttpGet("disabled-id")]
        public async Task<IActionResult> GetDisabledIdForCurrentUser()
        {
         
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId)) return Unauthorized();
            var disabled = await _disabledService.GetDisabledByUserIdAsync(userId);
            if (disabled == null) return NotFound();
            return Ok(disabled.Id);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _disabledService.GetByIdAsync(id);
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












