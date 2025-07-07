using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilitySupport.BLL.DTOs.payment
{
    public class PaymentDetailsDto
    {
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string? PaymentMethod { get; set; }
        public string? Status { get; set; }

        public int? HelperId { get; set; }
        public string? HelperName { get; set; }

        public int? DisabledId { get; set; }
        public string? DisabledName { get; set; }

        //public string? ServiceName { get; set; }
        public string? RequestStatus { get; set; }
        public DateTime? RequestDate { get; set; }
        public decimal? RequestPrice { get; set; }
        public string? RequestDescription { get; set; }
    }
}
