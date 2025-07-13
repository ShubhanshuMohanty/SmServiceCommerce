using Microsoft.AspNetCore.Mvc;
using SmServiceCommerce.DataAccess.Data;
using SmServiceCommerce.Models;

namespace SmServiceCommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ServiceController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Service> serviceList = _db.services.ToList();
            return View(serviceList);
        }
    }
}
