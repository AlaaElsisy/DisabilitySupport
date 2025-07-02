using DisabilitySupport.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DisabilitySupport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceCategoryController : ControllerBase
    {
        private readonly IServiceCategoryService _serviceCategoryService;

        public ServiceCategoryController(IServiceCategoryService serviceCategoryService)
        {
            _serviceCategoryService = serviceCategoryService;

        }

        [HttpGet("dropdown")]
        public async Task<IActionResult> GetDropdownCategories()
        {
            try
            {
                var result = await _serviceCategoryService.GetAllCategoriesAsync();
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (ApplicationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
            }
        }

        [HttpGet("serviceCategory")]
        public async Task<IActionResult> GetserviceCategorieswithdis()
        {
            try
            {
                var result = await _serviceCategoryService.GetAllCategoriesDiscAsync();
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (ApplicationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
        {
                return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
        }
    }

}
}
