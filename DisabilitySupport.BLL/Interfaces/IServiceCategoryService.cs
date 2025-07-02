using DisabilitySupport.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisabilitySupport.BLL.DTOs.ServiceCategory;

namespace DisabilitySupport.BLL.Interfaces
{
    public interface IServiceCategoryService
    {
        Task<List<ServiceCategory>> GetAllAsync();
        Task<List<ServiceCategoryDto>> GetAllCategoriesAsync();
        Task<List<ServiceCategoryDiscDto>> GetAllCategoriesDiscAsync();
    }
}
