using Microsoft.AspNetCore.Mvc;
using SmServiceCommerce.DataAccess.Repository.IRepository;
using SmServiceCommerce.Models;
using System.Security.Claims;

namespace SmServiceCommerce.Areas.ServiceProvider.Controllers
{
    [Area("ServiceProvider")]
    public class DashboardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public DashboardController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Bookingdata()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            List<Booking> BookingList = _unitOfWork.Booking.GetAll(u => u.ServiceProviderId == userId, includeProperties: "User").ToList();

            return View(BookingList);
        }
        public IActionResult RevenueData()
        {

            var allBookings = _unitOfWork.Booking.GetAll().ToList();

            // --- Bar Chart Data: Last 7 Days ---
            var today = DateOnly.FromDateTime(DateTime.Today);
            var last7Days = Enumerable.Range(0, 7)
                .Select(i => today.AddDays(-i))
                .OrderBy(d => d)
                .ToList();

            var bookingPerDay = last7Days.Select(date => new
            {
                Date = date.ToString("dd-MM-yyyy"),
                Count = allBookings.Count(b => b.BookingDate == date)
            }).ToList();

            // --- Pie Chart Data: Status Count ---
            var statusCounts = allBookings
                .GroupBy(b => b.Status)
                .Select(g => new
                {
                    Status = g.Key,
                    Count = g.Count()
                }).ToList();

            // Send to View
            ViewBag.BookingChartData = bookingPerDay;
            ViewBag.StatusPieData = statusCounts;
            return View();
        }
        public IActionResult BookingAccept(int? id)
        {
            Booking booking = _unitOfWork.Booking.Get(i=>i.Id==id);
            booking.Status = "Confirmed";
            _unitOfWork.Booking.Update(booking);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Bookingdata));
        }

        #region Api calls
        [HttpDelete]
        public IActionResult BookingCancel(int? id)
        {
            if (id == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            Booking booking = _unitOfWork.Booking.Get(i => i.Id == id);
            booking.Status = "Cancelled";
            _unitOfWork.Booking.Update(booking);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Booking rejected" });
        }

        #endregion
    }
}
