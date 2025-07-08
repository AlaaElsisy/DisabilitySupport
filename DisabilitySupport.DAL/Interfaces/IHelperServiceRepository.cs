using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using DisabilitySupport.DAL.Models;

namespace DisabilitySupport.DAL.Interfaces
{
    public interface IHelperServiceRepository:IGenericRepository<HelperService>
    {
        Task<bool> HelperExists(int id);
        Task<bool> ServiceExixts(int id);
        Task<List<HelperService>> GetServicesByHelperId(int helperId);
        Task<(IEnumerable<HelperService> Items, int TotalCount)> GetPagedByHelperIdAsync(int helperId,int pageNumber, int pageSize);

        Task<(List<HelperService> Items, int TotalCount)> GetPagedAsync( int? helperId,  int? serviceCategoryId,  string? searchWord, decimal? minBudget, decimal? maxBudget, string? sortBy, int pageNumber,  int pageSize, string? status );
    }
}
