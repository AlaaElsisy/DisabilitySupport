using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisabilitySupport.DAL.Models;

namespace DisabilitySupport.BLL.DTOs.payment.pay
{
    public class PaymentSuccess2Dto
    {
        public int? HelperRequestId { get; set; }
        public int? DisabledRequestId { get; set; }
        public decimal AmountPaid { get; set; }
        public string TransactionId { get; set; }
        public HelperRequest? _helperRequest { get; set; }
        public DisabledRequest? _disabledRequest { get; set; }
    }
}
