using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilitySupport.BLL.Interfaces
{
    public interface IHelperService
    {

        Task<int?> GetHelperIdByUserIdAsync(string userId);
    }
}
