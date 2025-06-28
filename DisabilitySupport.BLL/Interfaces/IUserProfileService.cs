using DisabilitySupport.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilitySupport.BLL.Interfaces
{
    public interface IUserProfileService
    {
        Task<Disabled?> GetDisabledProfileAsync(string userId);
        Task<Helper?> GetHelperProfileAsync(string userId);
    }

}
