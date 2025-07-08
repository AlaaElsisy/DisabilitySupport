using DisabilitySupport.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilitySupport.DAL.Interfaces
{
    public interface IHelperRepository:IGenericRepository<Helper>
    {
        Task<Helper?> GetByUserIdAsync(string userId);
        Task<Helper> GetByIdAsync(int id);
    }

}
