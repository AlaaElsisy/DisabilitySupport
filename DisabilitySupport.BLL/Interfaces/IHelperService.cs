using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisabilitySupport.BLL.DTOs;
using DisabilitySupport.DAL.Models;

namespace DisabilitySupport.BLL.Interfaces
{
    public interface IHelperService
    {
        Task AddHelperServiceAsync(HelperServiceDto dto);
        Task<List<HelperService>> GetServicesByHelperIdAsync(int helperId);
        Task AddHelperRequestAsync(HelperRequestDto dto);
        Task<List<HelperRequest>> GetRequestsByHelperIdAsync(int helperId);
    }
}
