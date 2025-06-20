using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisabilitySupport.DAL.Models.Enumerations;

namespace DisabilitySupport.DAL.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string? PaymentMethod { get; set; }
        public PaymentStatus? Status { get; set; }

        [ForeignKey("HelperRequest")]
        public int? HelperRequestId { get; set; }
        public virtual HelperRequest? HelperRequest { get; set; }

        [ForeignKey("DisabledRequest")]
        public int? DisabledRequestId { get; set; }
        public virtual DisabledRequest? DisabledRequest { get; set; }
    }
}
