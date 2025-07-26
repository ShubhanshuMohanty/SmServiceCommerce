using SmServiceCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmServiceCommerce.DataAccess.Repository.IRepository
{
    public interface IServiceProviderInfoRepository : IRepository<ServiceProviderInfo>
    {
        void Update(ServiceProviderInfo serviceProviderInfo);
    }
}
