using DisabilitySupport.DAL.Data;
using DisabilitySupport.DAL.Interfaces;
using DisabilitySupport.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilitySupport.DAL.Repositories
{
    public class DisabledRequestRepository : GenericRepository<DisabledRequest>, IDisabledRequestRepository
    {
        public DisabledRequestRepository(ApplicationDbContext context) : base(context)
        {
        } 

        public async Task<DisabledRequest> GetDetailsById(int id)
        {
            return await _Context.DisabledRequests
         .Include(x => x.HelperService)
             .ThenInclude(hs => hs.ServiceCategory)
         .Include(x => x.HelperService)
             .ThenInclude(hs => hs.Helper)
                 .ThenInclude(h => h.User)

                 .Include(x => x.Disabled) 
            .ThenInclude(d => d.User)
        .FirstOrDefaultAsync(d => d.Id == id);
        }
        public async Task<(IEnumerable<DisabledRequest> Items, int TotalCount)> GetPagedAsync(int? disabledId, int? helperServiceId, string? status, string? searchWord, int pageNumber, int pageSize, int? categoryId)
        {
            var query = _Context.DisabledRequests
            .Include(x => x.HelperService)
            .ThenInclude(hs => hs.Helper)
            .ThenInclude(h => h.User)
            .Include(x => x.Disabled)
            .AsQueryable();



            if (disabledId.HasValue)
                query = query.Where(x => x.DisabledId == disabledId.Value);
            if (helperServiceId.HasValue)
                query = query.Where(x => x.HelperServiceId == helperServiceId.Value);
            if (!string.IsNullOrEmpty(status))
                query = query.Where(x => x.Status.ToString().ToLower() == status.ToLower());
            if (!string.IsNullOrEmpty(searchWord))
                query = query.Where(x => x.Description != null && x.Description.ToLower().Contains(searchWord.ToLower()));
            if (categoryId.HasValue)
                query = query.Where(x => x.HelperService.ServiceCategoryId == categoryId.Value);

            var totalCount = await Task.FromResult(query.Count());
            var items = await Task.FromResult(query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList());

            return (items, totalCount);
        }
    }
}
