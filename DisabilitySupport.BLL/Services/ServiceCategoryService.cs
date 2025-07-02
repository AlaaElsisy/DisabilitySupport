using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DisabilitySupport.BLL.DTOs.ServiceCategory;
using DisabilitySupport.BLL.Interfaces;
using DisabilitySupport.DAL.Interfaces;

namespace DisabilitySupport.BLL.Services
{
    public class ServiceCategoryService : IServiceCategoryService
    {
        public IUnitOfWork _unitOfWork { get; }
        private readonly IMapper _mapper;
        public ServiceCategoryService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }



        public async Task<List<ServiceCategoryDto>> GetAllCategoriesAsync()
        {
            try
            {
                var services = await _unitOfWork._serviceCategoryRepository.GetAllAsync();

                if (services == null || !services.Any())
                    throw new KeyNotFoundException("No service categories exist.");

                
                var result = _mapper.Map<List<ServiceCategoryDto>>(services);

                return result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving Service Categories.", ex);
            }
        }

        public async Task<List<ServiceCategoryDiscDto>> GetAllCategoriesDiscAsync()
        {
            try
            {
                var services = await _unitOfWork._serviceCategoryRepository.GetAllAsync();

                if (services == null || !services.Any())
                    throw new KeyNotFoundException("No service categories exist.");

                var result = _mapper.Map<List<ServiceCategoryDiscDto>>(services);

                return result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving Service Categories.", ex);
            }
        }

    }
}
