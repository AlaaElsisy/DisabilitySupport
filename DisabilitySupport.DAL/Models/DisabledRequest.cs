using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisabilitySupport.DAL.Models.Enumerations;

namespace DisabilitySupport.DAL.Models
{
    public class DisabledRequest
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime RequestDate { get; set; }
        public RequestStatus? Status { get; set; }

        [ForeignKey("Disabled")]
        public int? DisabledId { get; set; }
        public virtual Disabled? Disabled { get; set; }

        [ForeignKey("HelperService")]
        public int? HelperServiceId { get; set; }
        public virtual HelperService? HelperService { get; set; }
    }
}
