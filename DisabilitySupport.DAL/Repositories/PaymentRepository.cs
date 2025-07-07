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
    public class PaymentRepository:GenericRepository<Payment> ,IPaymentRepository
    {
        
        public PaymentRepository(ApplicationDbContext applicationDbContext):base(applicationDbContext) { }

        public async Task<List<Payment>> GetByDisabledId(int id)
        {
            return await _Context.Payments
                 .Where(p => p.DisabledRequest != null && p.DisabledRequest.DisabledId == id)
                 .Include(p => p.DisabledRequest)
                     .ThenInclude(dr => dr.Disabled) 
                        .ThenInclude(u=>u.User)
                 .Include(p => p.DisabledRequest)
                     .ThenInclude(dr => dr.HelperService)          
                         .ThenInclude(hs => hs.Helper)
                            .ThenInclude(u => u.User)
                  .ToListAsync();
        }

        public async Task<List<Payment>> GetByHelperId(int id)
        {
            return await _Context.Payments
          .Where(p => p.HelperRequest != null && p.HelperRequest.HelperId == id)
          .Include(p => p.HelperRequest)
              .ThenInclude(hr => hr.Helper)
                    .ThenInclude(u => u.User)
          .Include(p => p.HelperRequest)
              .ThenInclude(hr => hr.DisabledOffer)  
                  .ThenInclude(doffer => doffer.Disabled)
                    .ThenInclude(u => u.User)
          .ToListAsync();
        }

        public async Task<HelperRequest> GetHelperRequestWithDetailsAsync(int id)
        {
            return await _Context.HelperRequests
                .Include(h => h.Helper).ThenInclude(u => u.User)
                .Include(h => h.DisabledOffer).ThenInclude(d => d.Disabled).ThenInclude(u => u.User)
                .FirstOrDefaultAsync(h => h.Id == id);
        }
        public async Task<DisabledRequest> GetDisabledRequestWithDetailsAsync(int id)
        {
            return await _Context.DisabledRequests
                .Include(d => d.Disabled)   
                    .ThenInclude(u => u.User) 
                 .Include(h => h.HelperService).ThenInclude(h=>h.Helper).ThenInclude(h=>h.User)
                .FirstOrDefaultAsync(d => d.Id == id);
        }
    }
}
