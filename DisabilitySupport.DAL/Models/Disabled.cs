using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilitySupport.DAL.Models
{
    public class Disabled
    {
        public int Id { get; set; }
        public string? MedicalConditionDescription { get; set; }
        public string DisabilityType { get; set; }
        public string? EmergencyContactName { get; set; }
        public string? EmergencyContactPhone { get; set; }
        public string? EmergencyContactRelation { get; set; }
        [ForeignKey("User")]
        public string? UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }
        public virtual List<DisabledOffer>? DisabledOffers { get; set; } = new List<DisabledOffer>();
        public virtual List<DisabledRequest>? DisabledRequests { get; set; } = new List<DisabledRequest>();
    }
}
