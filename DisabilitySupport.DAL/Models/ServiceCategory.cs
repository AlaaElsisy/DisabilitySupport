using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilitySupport.DAL.Models
{
    public class ServiceCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        // Navigation properties
        public virtual List<HelperService>? HelperServices { get; set; } = new List<HelperService>();
        public virtual List<DisabledOffer>? DisabledOffers { get; set; } = new List<DisabledOffer>();
    }

}
