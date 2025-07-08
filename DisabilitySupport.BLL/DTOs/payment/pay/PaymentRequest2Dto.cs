using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilitySupport.BLL.DTOs.payment.pay
{
    public class PaymentRequest2Dto
    {
        public int? HelperRequestId { get; set; }
        public int? DisabledRequestId { get; set; }
    }
}
