using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisabilitySupport.BLL.DTOs.payment;
using DisabilitySupport.BLL.DTOs.payment.pay;
using DisabilitySupport.DAL.Models;

namespace DisabilitySupport.BLL.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentResponseDto> ProcessPaymentAsync(PaymentRequestDto request);


        Task<List<PaymentDetailsDto>> GetPaymentsByDisabledIdAsync(int disabledId);
        //Task<List<PaymentDetailesDto>> GetPaymentsByHelperIdAsync(int helperId);

        Task<PaymentResponse2Dto> CreateStripeSessionAsync(PaymentRequest2Dto dto, string userEmail);
        Task<PaymentSuccess2Dto> ProcessPaymentSuccessAsync(string sessionId);

    }
}
