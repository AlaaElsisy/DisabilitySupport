﻿using DisabilitySupport.BLL.Interfaces;
using DisabilitySupport.DAL.Interfaces;
using DisabilitySupport.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilitySupport.BLL.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IDisabledRepository _disabledRepo;
        private readonly IHelperRepository _helperRepo;

        public UserProfileService(IDisabledRepository disabledRepo, IHelperRepository helperRepo)
        {
            _disabledRepo = disabledRepo;
            _helperRepo = helperRepo;
        }

        public async Task<Disabled?> GetDisabledProfileAsync(string userId)
        {
            return await _disabledRepo.GetByUserIdAsync(userId);
        }

        public async Task<Helper?> GetHelperProfileAsync(string userId)
        {
            return await _helperRepo.GetByUserIdAsync(userId);
        }
    }

}
