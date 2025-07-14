using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DisabilitySupport.BLL.DTOs;
using DisabilitySupport.BLL.DTOs.helper;
using DisabilitySupport.BLL.Interfaces;
using DisabilitySupport.DAL.Interfaces;

namespace DisabilitySupport.BLL.Services
{
    public class s_helperservise : IHelperService
    {
        public IHelperRepository _helperRepository { get; }
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public s_helperservise(IHelperRepository helperRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _helperRepository = helperRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<int?> GetHelperIdByUserIdAsync(string userId)
        {
            var helper = await _helperRepository.GetByUserIdAsync(userId);
            return helper?.Id ?? 0;
        }

        public async Task<HelperDto> GetByIdAsync(int id)
        {
            try
            {
                var helper = await _unitOfWork._helperRepository.GetByIdAsync(id);

                if (helper == null)
                    throw new KeyNotFoundException($"helper user with ID {id} not found.");

                return _mapper.Map<HelperDto>(helper);
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving the helper user.", ex);
            }
        }

        public Task<decimal?> WithdrawAsync(int helperId, decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
