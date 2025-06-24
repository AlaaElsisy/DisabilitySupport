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
    }
}
