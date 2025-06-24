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
    public class HelperRepository : GenericRepository<HelperRequest>, IHelperRepository
    {
        private readonly ApplicationDbContext _context;
        public HelperRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async Task<List<HelperRequest>> GetHelperRequestByHelperId(int helperId)
        {
           return await _context.HelperRequests
                .Include(x => x.DisabledOffer)
                 .Where(r => r.HelperId == helperId)
                .ToListAsync();
        }

        public async Task<List<HelperService>> GetServicesByHelperId(int helperId)
        {
            return await _context.HelperServices
            .Where(s => s.HelperId == helperId)
            .ToListAsync();
        }
    }
 
}
