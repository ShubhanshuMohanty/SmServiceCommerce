﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmServiceCommerce.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IServiceRepository Service { get; }
        IApplicationUserRepository ApplicationUser { get; }
        IServiceProviderInfoRepository ServiceProviderInfo { get; }
        IBookingRepository Booking { get; }
        void Save();
    }
}
