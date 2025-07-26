using SmServiceCommerce.DataAccess.Data;
using SmServiceCommerce.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmServiceCommerce.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IServiceRepository Service { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public IServiceProviderInfoRepository ServiceProviderInfo { get; private set; }
        public IBookingRepository Booking { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Service = new ServiceRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
            ServiceProviderInfo = new ServiceProviderInfoRepository(_db);
            Booking = new BookingRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
