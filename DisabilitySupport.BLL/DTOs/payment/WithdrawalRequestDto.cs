using System.ComponentModel.DataAnnotations;

namespace DisabilitySupport.BLL.DTOs.payment
{
    public class WithdrawalRequestDto
    {
        [Required]
        public string UserId { get; set; }
        
        [Required]
        [Range(200, double.MaxValue, ErrorMessage = "Minimum withdrawal amount is 200 EGP")]
        public decimal Amount { get; set; }
        
        [Required]
        public string BankAccountNumber { get; set; }
        
        [Required]
        public string BankName { get; set; }
        
        [Required]
        public string AccountHolderName { get; set; }
        
        public string? Currency { get; set; } = "egp";
    }
} 