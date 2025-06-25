using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilitySupport.BLL.DTOs.helper.service
{
    public class HelperServiceDto
    {
        public int? Id { get; set; }
        public string? Description { get; set; }
        [Range(typeof(decimal), "0", "9999999", ErrorMessage = "Price must be a positive number.")]
        public decimal? PricePerHour { get; set; }
        public DateTime? AvailableDateFrom { get; set; }
        public DateTime? AvailableDateTo { get; set; }
        public int? HelperId { get; set; }
        public int ServiceCategoryId { get; set; }
    }
}
