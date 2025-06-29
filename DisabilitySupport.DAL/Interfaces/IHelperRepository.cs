using DisabilitySupport.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilitySupport.DAL.Interfaces
{
    public interface IHelperRepository
    {
        Task<Helper?> GetByUserIdAsync(string userId);
    }

}
