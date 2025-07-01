using DisabilitySupport.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DisabilitySupport.DAL.Interfaces
{
    public interface IServiceCategoryRepository
    {
        Task<List<ServiceCategory>> GetAll();
    }
}
