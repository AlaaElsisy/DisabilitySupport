using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisabilitySupport.DAL.Models.Enumerations;

namespace DisabilitySupport.BLL.DTOs.helper
{
    public class HelperDto
    {
        public int Id { get; set; }

        public string? Bio { get; set; }

     
        public string? UserId { get; set; }
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public string? Zone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Gender? Gender { get; set; }
        public string? ProfileImage { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
