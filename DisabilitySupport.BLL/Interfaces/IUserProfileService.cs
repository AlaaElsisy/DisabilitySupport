using DisabilitySupport.BLL.DTOs.Disabled;
using DisabilitySupport.BLL.DTOs;
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

        Task<bool> UpdatePatientProfileAsync(string userId, EditPatientProfileDto dto);
        Task<bool> UpdateHelperProfileAsync(string userId, EditHelperProfileDto dto);
    }

}
