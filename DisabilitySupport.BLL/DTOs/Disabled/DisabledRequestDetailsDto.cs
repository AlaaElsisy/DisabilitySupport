using System;
using System.ComponentModel.DataAnnotations;

namespace DisabilitySupport.BLL.DTOs.Disabled
{
    public class DisabledRequestDetailsDto
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
        public string? UserId {get; set; }
    }
}