using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilitySupport.DAL.Models
{
    public class HelperService
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public decimal? PricePerHour { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? AvailableDateFrom { get; set; }
        public DateTime? AvailableDateTo { get; set; }

        [ForeignKey("Helper")]
        public int? HelperId { get; set; }
        public virtual Helper? Helper { get; set; }
        [ForeignKey("ServiceCategory")]
        public int ServiceCategoryId { get; set; }
        public ServiceCategory ServiceCategory { get; set; }

        public virtual List<DisabledRequest>? DisabledRequests { get; set; } = new List<DisabledRequest>();
    }
}
