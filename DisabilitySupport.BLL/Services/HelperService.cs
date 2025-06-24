using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DisabilitySupport.BLL.DTOs;
using DisabilitySupport.BLL.Interfaces;
using DisabilitySupport.DAL.Interfaces;
using DisabilitySupport.DAL.Models;

using DisabilitySupport.DAL.Repositories;

namespace DisabilitySupport.BLL.Services
{
    public class HelperService : IHelperService
    {
        public IHelperRequestRepository _helperRepository { get; }
        public IGenericRepository<HelperService> _helperServiceRepo { get; }

        private readonly IMapper _mapper;
        public HelperService(IMapper mapper, IHelperRequestRepository helperRepository , IGenericRepository<HelperService> helperServiceRepo)
        { 
            _mapper = mapper;
            _helperRepository = helperRepository;
            _helperServiceRepo = helperServiceRepo;
        }

                
        public async Task AddHelperRequestAsync(HelperRequestDto dto)
        {
            try {
                var request = _mapper.Map<HelperRequest>(dto);
                await _helperRepository.Add(request);
                await _helperRepository.Save();

            }
            catch (Exception ex)
            { 
                throw new ApplicationException("An error occurred while adding the helper request.", ex);
            }
        }

        public async Task AddHelperServiceAsync(HelperServiceDto dto)
        {
            try
            {
                var Service = _mapper.Map<HelperService>(dto);
                await _helperServiceRepo.Add(Service);
                await _helperServiceRepo.Save();


            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while adding the helper Service.", ex);
            }
        }

        public async Task<List<HelperRequest>> GetRequestsByHelperIdAsync(int helperId)
        {
           return await _helperRepository.GetHelperRequestByHelperId(helperId);
        }

        public async Task<List<DAL.Models.HelperService>> GetServicesByHelperIdAsync(int helperId)
        {
           return await _helperRepository.GetServicesByHelperId(helperId);
        }
    }
}
