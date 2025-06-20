using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilitySupport.DAL.Models
{
    public class Helper
    {
        public int Id { get; set; }
        public string? Bio { get; set; }

        [ForeignKey("User")]
        public string? UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }
        public virtual List<HelperService>? HelperServices { get; set; } = new List<HelperService>();
        public virtual List<HelperRequest>? HelperRequests { get; set; } = new List<HelperRequest>();
    }
}
