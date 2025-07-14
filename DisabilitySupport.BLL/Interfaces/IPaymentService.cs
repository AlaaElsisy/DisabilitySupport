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

        Task<WithdrawalResponseDto> ProcessWithdrawalAsync(WithdrawalRequestDto request);

    }
}
