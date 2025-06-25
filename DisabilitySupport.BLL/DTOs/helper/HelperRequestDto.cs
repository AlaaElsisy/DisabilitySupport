using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilitySupport.BLL.DTOs.helper
{
    public class HelperRequestDto
    {
        public int Id { get; set; }
        public string? Message { get; set; }
        [Range(typeof(decimal), "0", "9999999", ErrorMessage = "Price must be a positive number.")]
        public decimal? TotalPrice { get; set; }
        public int HelperId { get; set; }
        public int DisabledOfferId { get; set; }
    }
}
