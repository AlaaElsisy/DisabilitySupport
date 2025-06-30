using DisabilitySupport.BLL.Interfaces;
using DisabilitySupport.DAL.Interfaces;
using DisabilitySupport.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilitySupport.BLL.Services
{
    public class DisabledService : IDisabledService
    {
        private readonly IDisabledRepository _disabledRepo;

        public DisabledService(IDisabledRepository disabledRepository)
        {
            _disabledRepo = disabledRepository;
        }
        public async Task<Disabled?> GetDisabledByUserIdAsync(string userId)
        {
            return await _disabledRepo.GetByUserIdAsync(userId);
        }
    }
}
