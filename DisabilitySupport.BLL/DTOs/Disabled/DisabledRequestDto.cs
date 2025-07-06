using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilitySupport.BLL.DTOs.Disabled
{
    public class DisabledRequestDto
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(2000, ErrorMessage = "Description can't be longer than 2000 characters.")]
        public string? Description { get; set; }

        [Required]
        public DateTime RequestDate { get; set; }

        public string? Status { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public decimal? price { get; set; }

        [Required]
        public int? DisabledId { get; set; }
        [Required]
        public int? HelperServiceId { get; set; }

    }
}
