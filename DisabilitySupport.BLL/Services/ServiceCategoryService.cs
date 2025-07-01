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
    public class ServiceCategoryService: IServiceCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServiceCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ServiceCategory>> GetAllAsync()
        {
            return await _unitOfWork._serviceCategoryRepository.GetAll();
        }
    }
}

