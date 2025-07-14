using System.Security.Claims;
using DisabilitySupport.BLL.Interfaces;
using DisabilitySupport.BLL.Services;
using DisabilitySupport.BLL.DTOs.payment;
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
        public IPaymentService _paymentService { get; }

        public HelperController(IHelperService helperService, IPaymentService paymentService)
        {
            _helperService = helperService;
            _paymentService = paymentService;
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

        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] WithdrawalRequestDto request)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userId))
                    return Unauthorized("Invalid token.");

                request.UserId = userId;

                var result = await _paymentService.ProcessWithdrawalAsync(request);
                
                if (result.Success)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        public class WithdrawRequest
        {
            public int HelperId { get; set; }
            public decimal Amount { get; set; }
        }
    }
}
