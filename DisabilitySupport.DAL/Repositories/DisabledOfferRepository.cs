using DisabilitySupport.DAL.Data;
using DisabilitySupport.DAL.Interfaces;
using DisabilitySupport.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DisabilitySupport.DAL.Repositories
{
    public class DisabledOfferRepository : GenericRepository<DisabledOffer>, IDisabledOfferRepository
    {
        public DisabledOfferRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<(IEnumerable<DisabledOffer> Items, int TotalCount)> GetPagedAsync(
            int? disabledId, int? serviceCategoryId, string? status, string? searchWord, int pageNumber, int pageSize)
        {
            var query = _Context.DisabledOffers
                .Include(o => o.Disabled)
                .Include(o => o.ServiceCategory)
                .AsQueryable();

            if (disabledId.HasValue)
                query = query.Where(o => o.DisabledId == disabledId.Value);

            if (serviceCategoryId.HasValue)
                query = query.Where(o => o.ServiceCategorId == serviceCategoryId.Value);

            if (!string.IsNullOrEmpty(status))
                query = query.Where(o => o.Status.ToString().ToLower().Contains(status.ToLower()));

            if (!string.IsNullOrEmpty(searchWord))
                query = query.Where(o => o.Description != null && o.Description.ToLower().Contains(searchWord.ToLower()));

            var totalCount = await query.CountAsync();
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }
    }
}
