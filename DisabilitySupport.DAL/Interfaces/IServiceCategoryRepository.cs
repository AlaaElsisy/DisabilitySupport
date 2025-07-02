using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisabilitySupport.DAL.Models;

namespace DisabilitySupport.DAL.Interfaces
{
    public interface IServiceCategoryRepository
    {
        Task<List<ServiceCategory>> GetAllAsync();
    }
}
