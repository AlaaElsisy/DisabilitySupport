using DisabilitySupport.DAL.Data;
using DisabilitySupport.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilitySupport.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IDisabledRequestRepository _disabledRequestRepository {  get; set; }
  
        public UnitOfWork(ApplicationDbContext context , IDisabledRequestRepository disabledRequestRepository)
        {
            _context = context;
            _disabledRequestRepository = disabledRequestRepository;
        }

    }
}
