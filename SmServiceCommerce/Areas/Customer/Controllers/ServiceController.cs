using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmServiceCommerce.DataAccess.Repository.IRepository;
using SmServiceCommerce.Models;

namespace SmServiceCommerce.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ServiceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ServiceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SearchResult(string service, string location)
        {
            //List<Service> serviceList=_unitOfWork.;
            return View(service);
        }
        
    }
}
