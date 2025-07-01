using Microsoft.AspNetCore.Mvc;
using DisabilitySupport.BLL.Interfaces;
using DisabilitySupport.BLL.DTOs;
using DisabilitySupport.BLL.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace DisabilitySupport.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DisabledOfferController : ControllerBase
    {
        private readonly IDisabledOfferService _service;

        private readonly IDisabledService _disabledService;

        public DisabledOfferController(IDisabledOfferService service, IDisabledService disabledService)
        {
            _service = service;
            _disabledService = disabledService;
        }



        [HttpGet]
        public async Task<IActionResult> GetPaged([FromQuery] DisabledOfferQueryDto query)
        {
            var result = await _service.GetPagedAsync(query);
            return Ok(result);
        }

 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var offer = await _service.GetByIdAsync(id);
            if (offer == null) return NotFound();
            return Ok(offer);
        }


        [HttpPost]
        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> Create([FromBody] DisabledOfferDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
                return Unauthorized("Invalid user.");

            var disabled = await _disabledService.GetByUserIdAsync(userId);
            if (disabled == null)
                return BadRequest("Disabled user not found.");

            dto.DisabledId = disabled.Id;
            dto.OfferPostDate = DateTime.UtcNow;
            dto.Status = "Pending";

            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DisabledOfferDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (dto.Id != id)
                return BadRequest("IDs do not match.");

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
    }
}
