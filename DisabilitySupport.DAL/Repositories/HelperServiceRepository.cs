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
    }
}
