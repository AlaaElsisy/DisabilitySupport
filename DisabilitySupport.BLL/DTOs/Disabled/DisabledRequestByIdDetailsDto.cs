using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilitySupport.BLL.DTOs.Disabled
{
    public class DisabledRequestByIdDetailsDto
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
        public int? CategoryId { get; set; }
        public string? HelperName { get; set; }
        public string? HelperImage { get; set; }
        public string? serviceDescription { get; set; }
        public decimal? pricePerHour { get; set; }
        public string? CategoryName { get; set; }
        public DateTime? availableDateFrom { get; set; }
        public DateTime? availableDateTo { get; set; }

        public string? PatientName { get; set; }

    }
}
