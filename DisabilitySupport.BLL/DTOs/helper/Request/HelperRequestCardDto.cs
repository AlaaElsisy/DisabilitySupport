using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilitySupport.BLL.DTOs.helper.Request
{
    public class HelperRequestCardDto
    {
        public int Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? Message { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime ApplicationDate { get; set; }

        public int DisabledOfferId { get; set; }
        public string OfferDescription { get; set; }
        public DateTime? StartServiceTime { get; set; }
        public DateTime? EndServiceTime { get; set; }
        public decimal? Budget { get; set; }

        public string? CategoryName { get; set; }

        public string? PosterName { get; set; }
        public string? PosterImage { get; set; }
        public string? PosterUserId { get; set; }
    }
}
