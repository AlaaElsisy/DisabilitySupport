using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisabilitySupport.DAL.Models;

namespace DisabilitySupport.DAL.Interfaces
{
    public interface IPaymentRepository : IGenericRepository<Payment>
    {
        Task<List<Payment>> GetByHelperId(int id);
        Task<List<Payment>> GetByDisabledId(int id);
        //Task<List<Payment>> GetPaymentsByDisabledIdAsync(int disabledId);
        Task<HelperRequest> GetHelperRequestWithDetailsAsync(int id);
        Task<DisabledRequest> GetDisabledRequestWithDetailsAsync(int id);
    }
}
