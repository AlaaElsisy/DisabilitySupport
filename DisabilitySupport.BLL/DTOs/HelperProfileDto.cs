using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilitySupport.BLL.DTOs
{
    public class HelperProfileDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Zone { get; set; }
        public string? ProfileImage { get; set; }
        public string? Bio { get; set; }
        public decimal? Balance { get; set; }
    }

}
