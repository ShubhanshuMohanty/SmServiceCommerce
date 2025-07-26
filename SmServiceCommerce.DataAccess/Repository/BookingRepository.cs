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
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        private readonly ApplicationDbContext _db;
        public BookingRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Booking booking)
        {
            _db.Bookings.Update(booking);
        }
    }
}
