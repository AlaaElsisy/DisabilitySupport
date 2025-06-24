using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilitySupport.DAL.Models.Authentication.SignUp
{
    public class RegisterUser
    {
        [Required(ErrorMessage ="Please Enter Your Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please Enter Your Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Valid Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter Password Again")]
        public string ConfirmPassword { get; set; }
        public string? Phone { get; set; }
        public string? Region { get; set; }
        public string? Address { get; set; }
        public string? Birthday { get; set; }

        [Required(ErrorMessage = "Please Select Your Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please Select Valid Choice")]
        public bool IsDisabled { get; set; }
        public string? Description { get; set; }
        public string? DesabilityType { get; set; }
        public string? MedicalCondition { get; set; }
        public string? EmergencyContactName { get; set; }
        public string? EmergencyContactPhone { get; set; }
        public string? EmergencyContactRelation { get; set; }
        
    }
}
