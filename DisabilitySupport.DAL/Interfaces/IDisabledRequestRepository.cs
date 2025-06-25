using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisabilitySupport.DAL.Models;

namespace DisabilitySupport.DAL.Interfaces
{
    public interface IDisabledRequestRepository : IGenericRepository<DisabledRequest>
    {
        Task<(IEnumerable<DisabledRequest> Items, int TotalCount)> GetPagedAsync(int? disabledId, int? helperServiceId, string status, string? searchWord, int pageNumber, int pageSize);
    }
}
