using DisabilitySupport.BLL.DTOs.helper.service;
using DisabilitySupport.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DisabilitySupport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelperServiceController : ControllerBase
    {
        public IHelperServicesService _helperService { get; }

        public HelperServiceController(IHelperServicesService helperService)
        {
            _helperService = helperService;
        }
        [HttpPost("service")]
        public async Task<IActionResult> AddService([FromBody] HelperServiceDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var service = await _helperService.AddAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = service.Id }, service);

                //return Created(string.Empty, new
                //{
                //    message = "Service posted.",
                //    data = service
                //});
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }
        [HttpGet("helper/{helperId}/services")]
        public async Task<IActionResult> GetServicesByHelperIdAsync(int helperId)
        {
            if (helperId <= 0)
            {
                return BadRequest("Invalid helper ID.");
            }

            try
            {
                var services = await _helperService.GetByHelperIdAsync(helperId);

                if (services == null || !services.Any())
                    return NotFound($"No services found for helper with ID {helperId}.");

                return Ok(services);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("service/{id}")]
        public async Task<IActionResult> UpdateService(int id, [FromBody] UpdateHelperServiceDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var service = await _helperService.UpdateAsync(dto);
                if (id != dto.Id)

                    return BadRequest("Id are not equal");
                return Ok(new
                {
                    message = "Service updated.",
                    data = service
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("service/{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid service ID.");

            try
            {
                var exists = await _helperService.GetByIdAsync(id);
                if (exists == null)
                    return NotFound($"Service with ID {id} does not exist.");

                var result = await _helperService.DeleteAsync(id);
                if (!result)
                    return StatusCode(500, "Failed to delete the service.");

                //return Ok(new
                //{
                //    message = "Service deleted successfully.",
                //    deletedId = id
                //});
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("service/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid service ID.");

            try
            {
                var service = await _helperService.GetByIdAsync(id);

                if (service == null)
                    return NotFound($"Service with ID {id} does not exist.");

                return Ok(service);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("paged-by-helper/{helperId}")]
        public async Task<IActionResult> GetPagedByHelperId( int helperId, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var result = await _helperService.GetPagedByHelperIdAsync(helperId, page, pageSize);
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

    }
}
