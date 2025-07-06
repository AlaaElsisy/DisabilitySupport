using AutoMapper;
using DisabilitySupport.BLL.DTOs.Disabled;
using DisabilitySupport.BLL.Interfaces;
using DisabilitySupport.DAL.Interfaces;
using DisabilitySupport.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilitySupport.BLL.Services
{
    public class DisabledService : IDisabledService
    {
        private readonly IDisabledRepository _disabledRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DisabledService(IDisabledRepository disabledRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _disabledRepo = disabledRepository;

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Disabled?> GetDisabledByUserIdAsync(string userId)
        {
            return await _disabledRepo.GetByUserIdAsync(userId);
        }
        public async Task<Disabled?> GetByUserIdAsync(string userId) 
        {
            return await _disabledRepo.GetByUserIdAsync(userId);
        }
        public async Task<DisabledDto> GetByIdAsync(int id)
        {
            try
            {
                var disabled = await _unitOfWork._disabledRepository.GetByIdAsync(id);

                if (disabled == null)
                    throw new KeyNotFoundException($"Disabled user with ID {id} not found.");

                return _mapper.Map<DisabledDto>(disabled);
            }
            catch (KeyNotFoundException)
            {
                throw; 
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving the disabled user.", ex);
            }
        }

    }
}
