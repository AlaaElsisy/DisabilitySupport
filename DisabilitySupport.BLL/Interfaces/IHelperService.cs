using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisabilitySupport.BLL.DTOs;
using DisabilitySupport.BLL.DTOs.helper;

namespace DisabilitySupport.BLL.Interfaces
{
    public interface IHelperService
    {

        Task<int?> GetHelperIdByUserIdAsync(string userId);
        Task<HelperDto> GetByIdAsync(int id);
        Task<decimal?> WithdrawAsync(int helperId, decimal amount);
    }
}
