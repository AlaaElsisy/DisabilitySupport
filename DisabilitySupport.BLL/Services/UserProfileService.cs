using DisabilitySupport.BLL.DTOs.Disabled;
using DisabilitySupport.BLL.DTOs;
using DisabilitySupport.BLL.Interfaces;
using DisabilitySupport.DAL.Interfaces;
using DisabilitySupport.DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisabilitySupport.DAL.Models.Enumerations;

namespace DisabilitySupport.BLL.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IDisabledRepository _disabledRepo;
        private readonly IHelperRepository _helperRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserProfileService(IDisabledRepository disabledRepo, IHelperRepository helperRepo, UserManager<ApplicationUser> userManager)
        {
            _disabledRepo = disabledRepo;
            _helperRepo = helperRepo;
            _userManager = userManager;
        }

        public async Task<Disabled?> GetDisabledProfileAsync(string userId)
        {
            return await _disabledRepo.GetByUserIdAsync(userId);
        }

        public async Task<Helper?> GetHelperProfileAsync(string userId)
        {
            return await _helperRepo.GetByUserIdAsync(userId);
        }
        public async Task<bool> UpdatePatientProfileAsync(string userId, EditPatientProfileDto dto)
        {
            //var user = await _userManager.FindByIdAsync(userId);
            //var disabled = await _disabledRepo.GetByUserIdAsync(userId);
            Console.WriteLine($"Incoming userId: {userId}");
            var user = await _userManager.FindByIdAsync(userId);
            Console.WriteLine($"User found: {user != null}");

            var disabled = await _disabledRepo.GetByUserIdAsync(userId);
            Console.WriteLine($"Disabled found: {disabled != null}");

            if (user == null || disabled == null) return false;

            user.FullName = dto.FullName ?? user.FullName;
            user.PhoneNumber = dto.PhoneNumber ?? user.PhoneNumber;
            user.DateOfBirth = dto.DateOfBirth ?? user.DateOfBirth;
            if (dto.Gender.HasValue)
                user.Gender = (Gender)dto.Gender.Value; user.Address = dto.Address ?? user.Address;
            user.Zone = dto.Zone ?? user.Zone;
            user.ProfileImage = dto.ProfileImage ?? user.ProfileImage;

            if (!string.IsNullOrEmpty(dto.Email) && dto.Email != user.Email)
            {
                var emailResult = await _userManager.SetEmailAsync(user, dto.Email);
                var usernameResult = await _userManager.SetUserNameAsync(user, dto.Email);
                if (!emailResult.Succeeded || !usernameResult.Succeeded)
                {
                    return false;
                }
            }

            disabled.DisabilityType = dto.DisabilityType ?? disabled.DisabilityType;
            disabled.MedicalConditionDescription = dto.MedicalConditionDescription ?? disabled.MedicalConditionDescription;
            disabled.EmergencyContactName = dto.EmergencyContactName ?? disabled.EmergencyContactName;
            disabled.EmergencyContactPhone = dto.EmergencyContactPhone ?? disabled.EmergencyContactPhone;
            disabled.EmergencyContactRelation = dto.EmergencyContactRelation ?? disabled.EmergencyContactRelation;
             await _userManager.UpdateAsync(user);
            await _disabledRepo.UpdateAsync(disabled);

            return true;
        }



        public async Task<bool> UpdateHelperProfileAsync(string userId, EditHelperProfileDto dto)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var helper = await _helperRepo.GetByUserIdAsync(userId);

            if (user == null || helper == null) return false;

            user.FullName = dto.FullName ?? user.FullName;
            user.PhoneNumber = dto.PhoneNumber ?? user.PhoneNumber;
            user.DateOfBirth = dto.DateOfBirth ?? user.DateOfBirth;
            if (dto.Gender.HasValue)
                user.Gender = (Gender)dto.Gender.Value;
            user.Address = dto.Address ?? user.Address;
            user.Zone = dto.Zone ?? user.Zone;
            user.ProfileImage = dto.ProfileImage ?? user.ProfileImage;

            if (!string.IsNullOrEmpty(dto.Email) && dto.Email != user.Email)
            {
                var emailResult = await _userManager.SetEmailAsync(user, dto.Email);
                var usernameResult = await _userManager.SetUserNameAsync(user, dto.Email);
                if (!emailResult.Succeeded || !usernameResult.Succeeded)
                {
                    return false;
                }
            }

            helper.Bio = dto.Bio ?? helper.Bio;

            await _userManager.UpdateAsync(user);
            await _helperRepo.Update(helper);  
            await _helperRepo.Save();         

            return true;
        }



    }

}
