using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilitySupport.BLL.DTOs.helper.Request
{
    public class UpdateHelperRequestDto
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? Message { get; set; }
        public decimal? TotalPrice { get; set; }
        public int? HelperId { get; set; }
        public int? DisabledOfferId { get; set; }
    }
}
