using DisabilitySupport.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilitySupport.DAL.Interfaces
{
    public interface IDisabledRepository
    {
        Task<Disabled?> GetByUserIdAsync(string userId);
    }

}
