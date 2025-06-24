using DisabilitySupport.DAL.Data;
using DisabilitySupport.DAL.Interfaces;
using DisabilitySupport.DAL.Models;
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
    }
}
