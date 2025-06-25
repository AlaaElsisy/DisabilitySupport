using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilitySupport.DAL.Models.Authentication.LogIn
{
    public class LoginUser
    {
        [Required(ErrorMessage = "Please Enter Your Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Valid Password")]
        public string Password { get; set; }
    }
}
