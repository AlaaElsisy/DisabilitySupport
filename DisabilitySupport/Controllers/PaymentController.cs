using DisabilitySupport.BLL.DTOs.payment;
using DisabilitySupport.BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DisabilitySupport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {

        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
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
