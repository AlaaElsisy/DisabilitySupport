namespace DisabilitySupport.BLL.DTOs.payment
{
    public class WithdrawalResponseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string? TransactionId { get; set; }
        public decimal Amount { get; set; }
        public string? BankAccountNumber { get; set; }
        public DateTime? ProcessedDate { get; set; }
    }
} 