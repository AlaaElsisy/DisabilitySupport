using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisabilitySupport.DAL.Models.Enumerations;

namespace DisabilitySupport.DAL.Models
{
    public class HelperRequest
    {
        public int Id { get; set; }
        public DateTime ApplicationDate { get; set; }
        public HelperRequestStatus Status { get; set; }
        public string? Message { get; set; }
        public decimal? TotalPrice { get; set; }
        [ForeignKey("Helper")]
        public int? HelperId { get; set; }
        public virtual Helper? Helper { get; set; }
        [ForeignKey("DisabledOffer")]
        public int? DisabledOfferId { get; set; }
        public virtual DisabledOffer? DisabledOffer { get; set; }
    }
}
