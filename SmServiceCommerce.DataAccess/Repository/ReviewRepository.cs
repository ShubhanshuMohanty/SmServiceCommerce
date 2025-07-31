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
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        private readonly ApplicationDbContext _db;
        public ReviewRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Review review)
        {
            _db.Reviews.Update(review);
        }
    }
}
