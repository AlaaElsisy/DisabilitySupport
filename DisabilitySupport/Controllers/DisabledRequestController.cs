using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DisabilitySupport.BLL.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using DisabilitySupport.DAL.Models.Enumerations;
using DisabilitySupport.DAL.Models;
using DisabilitySupport.BLL.DTOs.Disabled;

namespace DisabilitySupport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisabledRequestController : ControllerBase
    {
        private readonly IServiceRequestService _service;

        public DisabledRequestController(IServiceRequestService service)
        {
            _service = service;
        }


        // To get all requests by DisabledId:
        // GET /api/DisabledRequest?disabledId=5
        //
        // To get all requests by HelperServiceId:
        // GET /api/DisabledRequest?helperServiceId=10
       
        [HttpGet]
        public async Task<IActionResult> GetPaged([FromQuery] DisabledRequestQueryDto query)
        {
            var result = await _service.GetPagedAsync(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DisabledRequestDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DisabledRequestDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != dto.Id) return BadRequest("IDs are not equal");
            var updated = await _service.UpdateAsync(dto);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }



        [HttpPatch("request/status")]
        public async Task<IActionResult> UpdateStatus([FromQuery] int requestId, [FromQuery] RequestStatus status)
        {
            if (requestId <= 0)
                return BadRequest("Invalid request ID.");
            try
            {
                var updated = await _service.UpdateStatusAsync(requestId, status);
                return Ok(updated);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
