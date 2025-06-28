using Microsoft.AspNetCore.Mvc;
using DisabilitySupport.BLL.Interfaces;
using DisabilitySupport.BLL.DTOs;

namespace DisabilitySupport.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DisabledOfferController : ControllerBase
    {
        private readonly IDisabledOfferService _service;

        public DisabledOfferController(IDisabledOfferService service)
        {
            _service = service;
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
        public async Task<IActionResult> Create([FromBody] DisabledOfferDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

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
