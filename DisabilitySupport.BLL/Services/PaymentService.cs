using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DisabilitySupport.BLL.DTOs.payment;
using DisabilitySupport.BLL.Interfaces;
using DisabilitySupport.DAL.Interfaces;
using DisabilitySupport.DAL.Models.Enumerations;
using DisabilitySupport.DAL.Models;
using Microsoft.Extensions.Configuration;
using Stripe;
using DisabilitySupport.DAL.Repositories;
using DisabilitySupport.BLL.DTOs.payment.pay;
using Stripe.Checkout;

namespace DisabilitySupport.BLL.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly string _stripeApiKey;

        public PaymentService(IMapper mapper,IUnitOfWork unitOfWork ,IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _stripeApiKey = configuration["Stripe:SecretKey"];
            StripeConfiguration.ApiKey = _stripeApiKey;
        }



        public async Task<PaymentResponseDto> ProcessPaymentAsync(PaymentRequestDto request)
        {
            
            if (request.HelperRequestId == null && request.DisabledRequestId == null)
            {
                return new PaymentResponseDto { Success = false, Message = "Must specify request ID" };
            }

         
            var payment = new Payment
            {
                Amount = request.Amount,
                Date = DateTime.UtcNow,
                PaymentMethod = "Card",
                Status = PaymentStatus.Pending,
                HelperRequestId = request.HelperRequestId,
                DisabledRequestId = request.DisabledRequestId
            };

            await _unitOfWork._paymentRepository.Add(payment);
            await _unitOfWork.Save();

            try
            {
                
                string tokenId = GetTestToken(request.CardNumber);

                 
                var chargeOptions = new ChargeCreateOptions
                {
                    Amount = (long)(request.Amount * 100),
                    Currency = request.Currency?.ToLower() ?? "egp",
                    Description = "Disability Support Payment",
                    Source = tokenId  
                };

                var chargeService = new ChargeService();
                var charge = chargeService.Create(chargeOptions);

                payment.Status = charge.Status == "succeeded" ? PaymentStatus.Paid : PaymentStatus.Failed;
                _unitOfWork._paymentRepository.Update(payment);
                await _unitOfWork.Save();
                if (payment.Status == PaymentStatus.Paid && payment.HelperRequestId.HasValue)
                {
                    var helperRequest = await _unitOfWork._helperRequestRepository.GetByIdAsync(payment.HelperRequestId.Value);
                    if (helperRequest?.HelperId != null)
                    {
                        var helper = await _unitOfWork._helperRepository.GetByIdAsync(helperRequest.HelperId.Value);
                        if (helper != null)
                        {
                            helper.Balance = (helper.Balance ?? 0) + payment.Amount;
                            _unitOfWork._helperRepository.Update(helper);
                            await _unitOfWork.Save();
                        }
                    }
                }
                else if (payment.Status == PaymentStatus.Paid && payment.DisabledRequestId.HasValue)
                {
                    var disabledRequest = await _unitOfWork._disabledRequestRepository.GetDetailsById(payment.DisabledRequestId.Value);
                    var helperService = disabledRequest?.HelperService;
                    var helperId = helperService?.HelperId;
                    if (helperId != null)
                    {
                        var helper = await _unitOfWork._helperRepository.GetByIdAsync(helperId.Value);
                        if (helper != null)
                        {
                            helper.Balance = (helper.Balance ?? 0) + payment.Amount;
                            _unitOfWork._helperRepository.Update(helper);
                            await _unitOfWork.Save();
                        }
                    }
                }

                return new PaymentResponseDto
                {
                    Success = payment.Status == PaymentStatus.Paid,
                    Message = payment.Status == PaymentStatus.Paid ? "Payment successful" : "Payment failed",
                    PaymentId = payment.Id
                };
            }
            catch (StripeException ex)
            {
                payment.Status = PaymentStatus.Failed;
                _unitOfWork._paymentRepository.Update(payment);
                await _unitOfWork.Save();

                return new PaymentResponseDto
                {
                    Success = false,
                    Message = $"Payment failed: {ex.StripeError?.Message ?? ex.Message}",
                    PaymentId = payment.Id
                };
            }
        }

        public async Task<WithdrawalResponseDto> ProcessWithdrawalAsync(WithdrawalRequestDto request)
        {
            try
            {
                // Get helper by userId
                var helper = await _unitOfWork._helperRepository.GetByUserIdAsync(request.UserId);
                if (helper == null)
                {
                    return new WithdrawalResponseDto 
                    { 
                        Success = false, 
                        Message = "Helper not found" 
                    };
                }

                if (helper.Balance < request.Amount)
                {
                    return new WithdrawalResponseDto 
                    { 
                        Success = false, 
                        Message = "Insufficient balance" 
                    };
                }

                if (request.Amount < 200)
                {
                    return new WithdrawalResponseDto 
                    { 
                        Success = false, 
                        Message = "Minimum withdrawal amount is 200 EGP" 
                    };
                }

                
                try
                {
                    
                    bool transferSuccess = true;
                    string transactionId = $"wd_{DateTime.UtcNow.Ticks}";
                    
                    if (transferSuccess)
                    {
                        // Deduct from helper's balance
                        helper.Balance -= request.Amount;
                        _unitOfWork._helperRepository.Update(helper);
                        await _unitOfWork.Save();

                        return new WithdrawalResponseDto
                        {
                            Success = true,
                            Message = "Withdrawal processed successfully",
                            TransactionId = transactionId,
                            Amount = request.Amount,
                            BankAccountNumber = request.BankAccountNumber,
                            ProcessedDate = DateTime.UtcNow
                        };
                    }
                    else
                    {
                        return new WithdrawalResponseDto
                        {
                            Success = false,
                            Message = "Transfer failed"
                        };
                    }
                }
                catch (Exception ex)
                {
                    return new WithdrawalResponseDto
                    {
                        Success = false,
                        Message = $"Transfer failed: {ex.Message}"
                    };
                }
            }
            catch (Exception ex)
            {
                return new WithdrawalResponseDto
                {
                    Success = false,
                    Message = $"Withdrawal failed: {ex.Message}"
                };
            }
        }

        private string GetTestToken(string cardNumber)
        {
           
            var testCards = new Dictionary<string, string>
            {
                ["4242424242424242"] = "tok_visa",  
                ["4000000000000002"] = "tok_chargeDeclined",  
                ["4000000000000069"] = "tok_visa_chargeDeclinedExpiredCard",  
                ["4000002500003155"] = "tok_visa_chargeDeclinedInsufficientFunds",  
                ["4000000000000127"] = "tok_visa_chargeDeclinedProcessingError"  
            };

            
            return testCards.TryGetValue(cardNumber?.Replace(" ", ""), out var token)
                ? token
                : "tok_visa";
        }


        public async Task<List<PaymentDetailsDto>> GetPaymentsByDisabledIdAsync(int disabledId)
        {
            var payments = await _unitOfWork._paymentRepository.GetByDisabledId(disabledId);

            return payments.Select(p => new PaymentDetailsDto
            {
                PaymentId = p.Id,
                Amount = p.Amount,
                Date = p.Date,
                PaymentMethod = p.PaymentMethod,
                Status = p.Status?.ToString(),

                DisabledId = p.DisabledRequest?.Disabled?.Id,
                DisabledName = p.DisabledRequest?.Disabled?.User?.FullName,

                HelperId = p.DisabledRequest?.HelperService?.Helper?.Id,
                HelperName = p.DisabledRequest?.HelperService?.Helper?.User?.FullName,

                RequestStatus = p.DisabledRequest?.Status?.ToString(),
                RequestDate = p.DisabledRequest?.RequestDate,
                RequestPrice = p.DisabledRequest?.price,
                RequestDescription = p.DisabledRequest?.Description
            }).ToList();
        }

       
    }
}
