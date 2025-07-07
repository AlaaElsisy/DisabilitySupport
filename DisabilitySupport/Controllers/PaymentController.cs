using DisabilitySupport.BLL.DTOs.payment;
using DisabilitySupport.BLL.DTOs.payment.pay;
using DisabilitySupport.BLL.Interfaces;
using DisabilitySupport.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DisabilitySupport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {

        private readonly IPaymentService _paymentService;
        private readonly UserManager<ApplicationUser> _userManager;
        public PaymentController(IPaymentService paymentService, UserManager<ApplicationUser> userManager)
        {
            _paymentService = paymentService;
            _userManager = userManager;
        }
        [HttpPost("charge")]
        public async Task<IActionResult> Charge([FromBody] PaymentRequestDto request)
        {
            var result = await _paymentService.ProcessPaymentAsync(request);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("ByDisabled/{disabledId}")]
        public async Task<IActionResult> GetPaymentsByDisabledId(int disabledId)
        {
            var result = await _paymentService.GetPaymentsByDisabledIdAsync(disabledId);

            if (result == null || result.Count == 0)
                return NotFound($"No payments found for DisabledId: {disabledId}");

            return Ok(result);
        }


       

    }
}
