using DisabilitySupport.BLL.DTOs;
using DisabilitySupport.BLL.Interfaces;
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
        [HttpPost("service")]
        public async Task<IActionResult> AddHelperService([FromBody] HelperServiceDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  
            }

            try
            {
                await _helperService.AddHelperServiceAsync(dto);
                return Ok("Service posted.");
            }
            catch (Exception ex)
            { 
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
