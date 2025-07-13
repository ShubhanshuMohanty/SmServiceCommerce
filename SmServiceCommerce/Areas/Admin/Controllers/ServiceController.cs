using Microsoft.AspNetCore.Mvc;
using SmServiceCommerce.DataAccess.Data;
using SmServiceCommerce.DataAccess.Repository.IRepository;
using SmServiceCommerce.Models;

namespace SmServiceCommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        //private readonly ApplicationDbContext _db;
        private readonly IUnitOfWork _unitOfWork;
        public ServiceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            //List<Service> serviceList = _db.services.ToList();
            IEnumerable<Service> serviceList = _unitOfWork.Service.GetAll();
            return View(serviceList);
        }
    }
}
