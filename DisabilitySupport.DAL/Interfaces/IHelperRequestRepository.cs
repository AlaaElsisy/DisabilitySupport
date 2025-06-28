using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisabilitySupport.DAL.Models;

namespace DisabilitySupport.DAL.Interfaces
{
    public interface IHelperRequestRepository: IGenericRepository<HelperRequest>
    {
        Task<List<HelperRequest>> GetHelperRequestByHelperId(int helperId);



        Task<bool> HelperExists(int id);
        Task<bool> RequestExixts(int id);
        Task<bool> DisabledOffersExixts(int id);

        Task<(IEnumerable<HelperRequest> Items, int TotalCount)> GetPagedByHelperIdAsync(int helperId, int pageNumber, int pageSize);

        Task<(List<HelperRequest> Items, int TotalCount)> GetPagedAsync( int? helperId, int? disabledOfferId, string? status, string? searchWord,  int pageNumber,  int pageSize  );

    }
}





