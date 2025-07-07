using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilitySupport.BLL.DTOs.payment
{
    public class PaymentRequestDto
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "egp";
        //public string Token { get; set; } = string.Empty;
        public int? HelperRequestId { get; set; }
        public int? DisabledRequestId { get; set; }

        public string CardNumber { get; set; }
        //public string ExpMonth { get; set; }
        //public string ExpYear { get; set; }
        //public string Cvc { get; set; }

    }
}
