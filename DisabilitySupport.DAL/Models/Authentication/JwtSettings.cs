using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilitySupport.DAL.Models.Authentication
{
    public class JwtSettings
    {
        public string SecretKey { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public int ExpirationMinutes { get; set; } = 60;

        public string GenerateSecurityKey()
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(SecretKey));
        }
    }
}
