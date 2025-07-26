using SmServiceCommerce.DataAccess.Data;
using SmServiceCommerce.DataAccess.Repository.IRepository;
using SmServiceCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmServiceCommerce.DataAccess.Repository
{
    public class ServiceProviderInfoRepository : Repository<ServiceProviderInfo>, IServiceProviderInfoRepository
    {
        private readonly ApplicationDbContext _db;
        public ServiceProviderInfoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(ServiceProviderInfo serviceProviderInfo)
        {
            _db.ServiceProviders.Update(serviceProviderInfo);
        }
    }
}
