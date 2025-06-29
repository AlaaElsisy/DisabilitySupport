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
    public class HelperServiceRepository : GenericRepository<HelperService>, IHelperServiceRepository
    {
        public HelperServiceRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }


        public async Task<bool> HelperExists(int id)
        {
            return await _Context.Helpers.AnyAsync(h => h.Id == id);
        }

        public async Task<List<HelperService>> GetServicesByHelperId(int helperId)
        {
            return await _Context.HelperServices
            .Where(s => s.HelperId == helperId)
            .ToListAsync();
        }


        public async Task<bool> ServiceExixts(int id)
        {
            return await _Context.HelperServices.AnyAsync(s => s.Id == id);
        }

        public async Task<(IEnumerable<HelperService> Items, int TotalCount)> GetPagedByHelperIdAsync(
            int helperId,  int pageNumber = 1, int pageSize = 10)
        {
            var query = _Context.HelperServices
                .Where(x => x.HelperId == helperId)
                .OrderBy(x => x.Id);  

            var totalCount = await query.CountAsync();
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }


        public async Task<(List<HelperService> Items, int TotalCount)> GetPagedAsync(  int? helperId,  int? serviceCategoryId,  string? searchWord,  int pageNumber, int pageSize)
        {
            var query = _Context.HelperServices.AsQueryable();

            if (helperId.HasValue)
                query = query.Where(x => x.HelperId == helperId.Value);

            if (serviceCategoryId.HasValue)
                query = query.Where(x => x.ServiceCategoryId == serviceCategoryId.Value);

            if (!string.IsNullOrWhiteSpace(searchWord))
                query = query.Where(x => x.Description != null && x.Description.ToLower().Contains(searchWord.ToLower()));

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(x => x.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }
    }
}
