using System;
using System.ComponentModel.DataAnnotations;

namespace DisabilitySupport.BLL.DTOs
{
    public class DisabledOfferDto
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(2000, ErrorMessage = "Description can't be longer than 2000 characters.")]
        public string? Description { get; set; }

        [Required]
        public DateTime OfferPostDate { get; set; }

        public DateTime? ServiceTime { get; set; }

        public string? Status { get; set; }

        public decimal? Budget { get; set; }

        [Required]
        public int? DisabledId { get; set; }

        [Required]
        public int? ServiceCategorId { get; set; }
    }
}
