﻿using System;
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
        public IServiceCategoryRepository _serviceCategoryRepository { get; }

        public IDisabledRepository _disabledRepository { get; }
        public IHelperRepository _helperRepository { get; }


        Task Save();
    }
}
