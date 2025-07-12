using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisabilitySupport.DAL.Data;
using DisabilitySupport.DAL.Interfaces;
using DisabilitySupport.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DisabilitySupport.DAL.Repositories
{
    public class HelperRequestRepository : GenericRepository<HelperRequest>, IHelperRequestRepository
    {
        
        public HelperRequestRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
           
        }

        public async Task<List<HelperRequest>> GetHelperRequestByHelperId(int helperId)
        {
           return await _Context.HelperRequests
                .Include(x => x.DisabledOffer)
                 .Where(r => r.HelperId == helperId)
                .ToListAsync();
        }


        public async Task<HelperRequest> GetById(int id)
        {
            return await _Context.HelperRequests
                .Include(x => x.DisabledOffer)
                    .ThenInclude(o => o.Disabled)
                        .ThenInclude(d => d.User)
                .Include(x => x.Helper)
                    .ThenInclude(h => h.User)
                .FirstOrDefaultAsync(h => h.Id == id);
        }




        public async Task<bool> HelperExists(int id)
        {
            return await _Context.Helpers.AnyAsync(h => h.Id == id);
        }

        public async Task<bool> DisabledOffersExixts(int id)
        {
            return await _Context.DisabledOffers.AnyAsync(h => h.Id == id);
        }
        public async Task<bool> RequestExixts(int id)
        {
            return await _Context.HelperRequests.AnyAsync(s => s.Id == id);
        }


        public async Task<(IEnumerable<HelperRequest> Items, int TotalCount)> GetPagedByHelperIdAsync(
           int helperId, int pageNumber = 1, int pageSize = 10)
        {
            var query = _Context.HelperRequests
                .Where(x => x.HelperId == helperId)
                .OrderBy(x => x.Id);

            var totalCount = await query.CountAsync();
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }

        public async Task<(List<HelperRequest> Items, int TotalCount)> GetPagedAsync(
            int? helperId,
            int? disabledOfferId,
            string? status,
            string? searchWord,
            int? minTotalPrice,
            int? maxTotalPrice,
            string? orderBy,
            int pageNumber,
            int pageSize)
        {
            var query = _Context.HelperRequests.Include(x => x.Helper).ThenInclude(y => y.User).AsQueryable();

            if (helperId.HasValue)
                query = query.Where(x => x.HelperId == helperId.Value);

            if (disabledOfferId.HasValue)
                query = query.Where(x => x.DisabledOfferId == disabledOfferId.Value);

            if (!string.IsNullOrEmpty(status))
                query = query.Where(x => x.Status.ToString().ToLower() == status.ToLower());

            if (!string.IsNullOrEmpty(searchWord))
                query = query.Where(x => x.Message != null && x.Message.ToLower().Contains(searchWord.ToLower()));

            if (minTotalPrice.HasValue)
                query = query.Where(x => x.TotalPrice >= minTotalPrice.Value);

            if (maxTotalPrice.HasValue)
                query = query.Where(x => x.TotalPrice <= maxTotalPrice.Value);

            // Default ordering: ApplicationDate desc
            if (!string.IsNullOrEmpty(orderBy))
            {
                if (orderBy.ToLower() == "totalprice")
                    query = query.OrderBy(x => x.TotalPrice);
                else if (orderBy.ToLower() == "-totalprice")
                    query = query.OrderByDescending(x => x.TotalPrice);
                else
                    query = query.OrderByDescending(x => x.ApplicationDate);
            }
            else
            {
                query = query.OrderByDescending(x => x.ApplicationDate);
            }

            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }
        public async Task<(List<HelperRequest> Items, int TotalCount)> GetRequestCardsByHelperIdAsync(int helperId, int pageNumber = 1, int pageSize = 10)
        {
            var query = _Context.HelperRequests
                .Include(x => x.DisabledOffer)
                    .ThenInclude(o => o.ServiceCategory)
                .Include(x => x.DisabledOffer)
                    .ThenInclude(o => o.Disabled)
                        .ThenInclude(d => d.User)
                .Where(x => x.HelperId == helperId)
                .OrderByDescending(x => x.ApplicationDate);

            var totalCount = await query.CountAsync();
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }


    }

}
