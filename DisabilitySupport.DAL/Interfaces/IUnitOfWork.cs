using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisabilitySupport.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        public IDisabledRequestRepository _disabledRequestRepository { get;}
        public IDisabledOfferRepository _disabledOfferRepository { get; }
        public IHelperServiceRepository _helperServiceRepository { get;}
        public IHelperRequestRepository _helperRequestRepository { get; }

        Task Save();
    }
}
