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
        public IServiceCategoryRepository _serviceCategoryRepository { get; }
        public IDisabledRepository _disabledRepository { get; }
        public IHelperRepository _helperRepository{ get; }
        public IPaymentRepository _paymentRepository { get; }

        public INotificationRepository _notificationRepository { get; }

        public UnitOfWork(ApplicationDbContext context, IDisabledRequestRepository disabledRequestRepository
            , IHelperServiceRepository helperServiceRepository, IHelperRequestRepository helperRequestRepository, IServiceCategoryRepository serviceCategoryRepository, IDisabledRepository disabledRepository, IHelperRepository helperRepository, IPaymentRepository paymentRepository, INotificationRepository notificationRepository)
        {
            _context = context;
            _disabledRequestRepository = disabledRequestRepository;
            _helperServiceRepository = helperServiceRepository;
            _helperRequestRepository = helperRequestRepository;
            _serviceCategoryRepository = serviceCategoryRepository;
            _disabledRepository = disabledRepository;
            _helperRepository = helperRepository;
            _paymentRepository = paymentRepository;
            _notificationRepository = notificationRepository;
        }


        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
