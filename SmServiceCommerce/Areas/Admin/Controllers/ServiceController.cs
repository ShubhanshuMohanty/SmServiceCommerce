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
        public IActionResult Upsert(int? id)
        {
            Service service = new Service();
            if (id == null || id == 0)
            {
                // Create service
                return View(service);
            }
            else
            {
                // Update service
                service = _unitOfWork.Service.Get(i=>i.Id==id);
                if (service == null)
                {
                    return NotFound();
                }
                return View(service);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Service service)
        {
            string successMessage;
            if (ModelState.IsValid)
            {
                if (service.Id == 0)
                {
                    // Create
                    _unitOfWork.Service.Add(service);
                    successMessage = "Service created successfully";
                }
                else
                {
                    // Update
                    _unitOfWork.Service.Update(service);
                    successMessage = "Service updated successfully";
                }
                _unitOfWork.Save();
                TempData["success"] = successMessage;
                return RedirectToAction("Index");
            }
            return View(service);
        }

        #region Api calls
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var service = _unitOfWork.Service.Get(i => i.Id == id);
            if (service == null)
            {
                TempData["error"] = "Service not found";
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.Service.Remove(service);
            _unitOfWork.Save();
            TempData["success"] = "Service deleted successfully";
            return Json(new { success = true, message = "Service deleted successfully" });
        }

        #endregion
    }
}
