using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisabilitySupport.DAL.Models.Enumerations;

namespace DisabilitySupport.DAL.Models
{
    public class DisabledOffer
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime OfferPostDate { get; set; }
        public DateTime? StartServiceTime { get; set; }
        public DateTime? EndServiceTime { get; set; }
        public DisabledOfferStatus Status { get; set; }
        public decimal? Budget { get; set; }

        [ForeignKey("Disabled")]
        public int? DisabledId { get; set; }
        public virtual Disabled? Disabled { get; set; }
        [ForeignKey("ServiceCategory")]
        public int? ServiceCategorId { get; set; }
        public virtual ServiceCategory? ServiceCategory { get; set; }
    }
}
