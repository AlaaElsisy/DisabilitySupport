using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DisabilitySupport.DAL.Models.Enumerations;
 using Microsoft.AspNetCore.Identity;


namespace DisabilitySupport.DAL.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FullName { get; set; }
        public string? Address { get; set; }
        public string? Zone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Gender? Gender { get; set; }
        public string? ProfileImage { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
   
}
