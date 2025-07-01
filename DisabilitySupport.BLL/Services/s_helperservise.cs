using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisabilitySupport.BLL.Interfaces;
using DisabilitySupport.DAL.Interfaces;

namespace DisabilitySupport.BLL.Services
{
    public class s_helperservise : IHelperService
    {
        public IHelperRepository _helperRepository { get; }

        public s_helperservise(IHelperRepository helperRepository)
        {
            _helperRepository = helperRepository;
        }


        public async Task<int?> GetHelperIdByUserIdAsync(string userId)
        {
            var helper = await _helperRepository.GetByUserIdAsync(userId);
            return helper?.Id ?? 0;
        }
    }
}
