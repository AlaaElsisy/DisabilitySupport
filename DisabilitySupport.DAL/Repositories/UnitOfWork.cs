using DisabilitySupport.DAL.Data;
using DisabilitySupport.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public IHelperServiceRepository _helperServiceRepository { get; set; }

        public IDisabledOfferRepository _disabledOfferRepository { get; set; }

        public IHelperRequestRepository _helperRequestRepository { get; set; }


        public UnitOfWork(ApplicationDbContext context , IDisabledRequestRepository disabledRequestRepository
            ,IHelperServiceRepository helperServiceRepository,IHelperRequestRepository helperRequestRepository)
        {
            _context = context;
            _disabledRequestRepository = disabledRequestRepository;
            _helperServiceRepository = helperServiceRepository;

            _helperRequestRepository = helperRequestRepository;


        }


        
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
