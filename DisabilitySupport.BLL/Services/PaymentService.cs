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




        /////////////////////////////////////
        ///
        public async Task<PaymentResponse2Dto> CreateStripeSessionAsync(PaymentRequest2Dto dto, string userEmail)
        {
            string itemName;
            decimal amountToCharge;

            if (dto.HelperRequestId.HasValue)
            {
                var helperRequest = await _unitOfWork. _helperRequestRepository.GetById(dto.HelperRequestId.Value);
                if (helperRequest == null) throw new Exception("Helper request not found");

                itemName = "Helper Service";
                amountToCharge = (decimal)helperRequest.TotalPrice;
            }
            else if (dto.DisabledRequestId.HasValue)
            {
                var disabledRequest = await _unitOfWork. _disabledRequestRepository.GetById(dto.DisabledRequestId.Value);
                if (disabledRequest == null) throw new Exception("Disabled request not found");

                itemName = "Disabled Service";
                amountToCharge = (decimal)disabledRequest.price;
            }
            else
            {
                throw new Exception("No valid request provided");
            }

            var lineItem = new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmount = (long)(amountToCharge * 100),
                    Currency = "egp",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = itemName
                    }
                },
                Quantity = 1
            };

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions> { lineItem },
                Mode = "payment",
                SuccessUrl = "http://localhost:4200/payment-success?sessionId={CHECKOUT_SESSION_ID}",
                CancelUrl = "http://localhost:4200/payment-failed",
                CustomerEmail = userEmail,
                Metadata = new Dictionary<string, string>
            {
                { "HelperRequestId", dto.HelperRequestId?.ToString() ?? "" },
                { "DisabledRequestId", dto.DisabledRequestId?.ToString() ?? "" },
                { "Amount", amountToCharge.ToString() }
            }
            };

            var service = new SessionService();
            var session = await service.CreateAsync(options);

            return new PaymentResponse2Dto { SessionUrl = session.Url };
        }

        public async Task<PaymentSuccess2Dto> ProcessPaymentSuccessAsync(string sessionId)
        {
            var service = new SessionService();
            var session = await service.GetAsync(sessionId);

            if (session.PaymentStatus != "paid")
                throw new Exception("Payment failed");

            int? helperRequestId = int.TryParse(session.Metadata["HelperRequestId"], out var hrId) ? hrId : (int?)null;
            int? disabledRequestId = int.TryParse(session.Metadata["DisabledRequestId"], out var drId) ? drId : (int?)null;
            decimal amountPaid = decimal.Parse(session.Metadata["Amount"]);

            var payment = new Payment
            {
                HelperRequestId = helperRequestId,
                DisabledRequestId = disabledRequestId,
                Amount = amountPaid,
                Date = DateTime.Now,
                PaymentMethod = "Stripe",
                Status = PaymentStatus.Paid
            };

            await _unitOfWork. _paymentRepository.Add(payment);
            await _unitOfWork.Save();

            var helperRequest = new HelperRequest();
            var disabledRequest = new DisabledRequest();
            if (helperRequestId.HasValue)
            {
               helperRequest = await _unitOfWork._helperRequestRepository.GetById(helperRequestId.Value);
                if (helperRequest == null) throw new Exception("Helper request not found");

                
            }
            else if (disabledRequestId.HasValue)
            {
                disabledRequest = await _unitOfWork._disabledRequestRepository.GetById(disabledRequestId.Value);
                if (disabledRequest == null) throw new Exception("Disabled request not found");

                
            }
            return new PaymentSuccess2Dto
            {
                HelperRequestId = helperRequestId,
                DisabledRequestId = disabledRequestId,
                AmountPaid = amountPaid,
                TransactionId = session.Id,
                _helperRequest= helperRequest,
                _disabledRequest= disabledRequest
            };
        }
    }
}
