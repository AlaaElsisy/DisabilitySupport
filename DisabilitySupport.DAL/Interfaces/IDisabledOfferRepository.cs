using DisabilitySupport.DAL.Models;

namespace DisabilitySupport.DAL.Interfaces
{
    public interface IDisabledOfferRepository : IGenericRepository<DisabledOffer>
    {
        Task<(IEnumerable<DisabledOffer> Items, int TotalCount)> GetPagedAsync(
            int? disabledId, int? serviceCategoryId, string? status, string? searchWord, int pageNumber, int pageSize);
    }
}
