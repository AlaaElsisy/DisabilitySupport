using DisabilitySupport.BLL.DTOs.helper.Request;
using DisabilitySupport.BLL.DTOs.helper.service;
using DisabilitySupport.BLL.Interfaces;
using DisabilitySupport.DAL.Models.Enumerations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DisabilitySupport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelperRequestController : ControllerBase
    {

        public IHelperRequestsService _helperRequest { get; }

        public HelperRequestController(IHelperRequestsService helperRequest)
        {
            _helperRequest = helperRequest;
        }
        [HttpPost("request")]
        public async Task<IActionResult> AddService([FromBody] HelperRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var Request = await _helperRequest.AddAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = Request.Id }, Request);

               
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }
       
        [HttpPut("request/{id}")]
        public async Task<IActionResult> UpdateService(int id, [FromBody] UpdateHelperRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var Request = await _helperRequest.UpdateAsync(dto);
                if (id != dto.Id)

                    return BadRequest("Id are not equal");
                return Ok(new
                {
                    message = "Request updated.",
                    data = Request
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("request/{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid service ID.");

            try
            {
                var exists = await _helperRequest.GetByIdAsync(id);
                if (exists == null)
                    return NotFound($"Request with ID {id} does not exist.");

                var result = await _helperRequest.DeleteAsync(id);
                if (!result)
                    return StatusCode(500, "Failed to delete the Request.");

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("request/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid service ID.");

            try
            {
                var Request = await _helperRequest.GetByIdAsync(id);

                if (Request == null)
                    return NotFound($"Request with ID {id} does not exist.");

                return Ok(Request);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPatch("request/status")]
        public async Task<IActionResult> UpdateStatus([FromQuery] int requestId, [FromQuery] HelperRequestStatus status)
        {
            if (requestId <= 0)
                return BadRequest("Invalid request ID.");
            try
            {
                var updated = await _helperRequest.UpdateStatusAsync(requestId, status);
                return Ok(new
                {
                    message = "Status updated successfully.",
                    data = updated
                });
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




        [HttpGet("pagedByHelper/{helperId}")]
        public async Task<IActionResult> GetPagedByHelperId(int helperId, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var result = await _helperRequest.GetPagedByHelperIdAsync(helperId, page, pageSize);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", details = ex.Message });
            }
        }


        [HttpGet("paged")]
        public async Task<IActionResult> GetPaged([FromQuery] HelperRequestQueryDto query)
        {
            try
            {
                var result = await _helperRequest.GetPagedAsync(query);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
