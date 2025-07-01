using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DisabilitySupport.BLL.DTOs;
using DisabilitySupport.BLL.DTOs.helper.service;
using DisabilitySupport.BLL.Interfaces;
using DisabilitySupport.DAL.Interfaces;
using DisabilitySupport.DAL.Models;

using DisabilitySupport.DAL.Repositories;
using MimeKit;

namespace DisabilitySupport.BLL.Services
{
    public class HelperServicesService : IHelperServicesService
    {
        
        private readonly IMapper _mapper;
        public IUnitOfWork _unitOfWork { get; }
        public HelperServicesService(IMapper mapper,IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<HelperServiceDto> AddAsync(HelperServiceDto dto)
        {
            try
            {
                var service = _mapper.Map<HelperService>(dto);
                service.CreatedAt = DateTime.UtcNow;

                await _unitOfWork._helperServiceRepository.Add(service);
                await _unitOfWork.Save();

               return _mapper.Map<HelperServiceDto>(service);
                //return service;


            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while adding the helper Service.", ex);
            }
        }

        public async Task<List<HelperService>> GetByHelperIdAsync(int helperId)
        {
            try
            {
                var exists = await _unitOfWork._helperServiceRepository.HelperExists(helperId);
                if (!exists)
                    throw new KeyNotFoundException($"Helper with ID {helperId} does not exist.");

                var services = await _unitOfWork._helperServiceRepository.GetServicesByHelperId(helperId);
                if (services == null)
                    throw new KeyNotFoundException("No services for that helper");
                    
                return services.ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving the helper services.", ex);
            }
        }


        public async Task<HelperServiceDto> GetByIdAsync(int id)
        {
            var exists = await _unitOfWork._helperServiceRepository.ServiceExixts(id);
            if (!exists)
                throw new KeyNotFoundException($"Service with ID {id} does not exist.");

            var service = await _unitOfWork._helperServiceRepository.GetById(id);  

            if (service == null)
                throw new KeyNotFoundException("No service with that ID");

            return _mapper.Map<HelperServiceDto>(service);  
        }


        public async Task<HelperServiceDto> UpdateAsync(UpdateHelperServiceDto dto)
        {
              var service = await _unitOfWork._helperServiceRepository.GetById(dto.Id);

                if (service == null)
                    throw new KeyNotFoundException("No service with that id");

                 var result= _mapper.Map(dto, service);
                if (result == null)
                    throw new ApplicationException("error in mapping result is null ");
                await _unitOfWork._helperServiceRepository.Update(result);
                await _unitOfWork.Save();


            return _mapper.Map<HelperServiceDto>(result);


        }

        public async Task<bool> DeleteAsync(int id)
        { 
                var service = await _unitOfWork._helperServiceRepository.GetById(id);

                if (service == null)
                    throw new KeyNotFoundException("No service with that ID");

                await _unitOfWork._helperServiceRepository.Delete(id);
                await _unitOfWork.Save();

                return true;  
        
        }


        public async Task<PaginatedResult<HelperServiceDto>> GetPagedByHelperIdAsync(
                 int helperId, int pageNumber = 1, int pageSize = 10)
        {
            
                if (!await _unitOfWork._helperServiceRepository.HelperExists(helperId))
                    throw new KeyNotFoundException($"Helper with ID {helperId} does not exist.");

                var (items, totalCount) = await _unitOfWork._helperServiceRepository
                    .GetPagedByHelperIdAsync(helperId, pageNumber, pageSize);

                if (items == null || !items.Any())
                    throw new KeyNotFoundException("No services found for this helper");

                var result = new PaginatedResult<HelperServiceDto>
                {
                    Items = _mapper.Map<List<HelperServiceDto>>(items),
                    TotalCount = totalCount
                };

                return result;
             
        }

        public async Task<PaginatedResult<HelperServiceDetailsDto>> GetPagedAsync(HelperServiceQueryDto query)
        {
            if (query.HelperId.HasValue)
            {
                var exists = await _unitOfWork._helperServiceRepository.HelperExists(query.HelperId.Value);
                if (!exists)
                    throw new KeyNotFoundException($"Helper with ID {query.HelperId} does not exist.");
            }

            var (entities, totalCount) = await _unitOfWork._helperServiceRepository.GetPagedAsync(
                query.HelperId,
                query.ServiceCategoryId,
                query.SearchWord,
                query.MinBudget,
                query.MaxBudget,
                query.SortBy,
                query.PageNumber,
                query.PageSize
            );

            var items = _mapper.Map<List<HelperServiceDetailsDto>>(entities);

            return new PaginatedResult<HelperServiceDetailsDto>
            {
                Items = items,
                TotalCount = totalCount
            };
        }

        Task<List<DAL.Models.HelperService>> IHelperServicesService.GetByHelperIdAsync(int helperId)
        {
            throw new NotImplementedException();
        }
    }
}
