using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilitySupport.BLL.DTOs.helper.Request
{
    public class HelperRequestDetailsDto
    {
        public int? Id { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? Message { get; set; }
        public decimal? TotalPrice { get; set; }
        public int? HelperId { get; set; }
        public string? HelperName { get; set; }
        public string? HelperImage { get; set; }
        public int? DisabledOfferId { get; set; }
        public string? UserId { get; set; }
    }
}
