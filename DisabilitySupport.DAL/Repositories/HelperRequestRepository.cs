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

       
    }
 
}
