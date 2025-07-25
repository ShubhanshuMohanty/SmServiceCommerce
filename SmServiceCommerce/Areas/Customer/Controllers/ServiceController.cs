﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmServiceCommerce.DataAccess.Repository.IRepository;
using SmServiceCommerce.Models;
using SmServiceCommerce.Models.ViewModels;
using System.Security.Claims;

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
            List<ApplicationUser> serviceProviderList = _unitOfWork.ApplicationUser.GetAll(includeProperties: "Service").Where(i => i.Service?.ServiceName.ToLower() == service.ToLower() && i.City?.ToLower() == location.ToLower()).ToList();
            return View(serviceProviderList);
        }
        public IActionResult BookServiceDetail(string id)
        {
            ServiceProviderInfo serviceProviderInfo = _unitOfWork.ServiceProviderInfo.Get(u => u.ApplicationUserId == id, includeProperties: "User,User.Service");
            if (serviceProviderInfo == null)
            {
                return NotFound();
            }          
            return View(serviceProviderInfo);
        }

        [HttpPost]
        public IActionResult BookService(BookingVM bookingVM)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            var date = DateOnly.Parse(bookingVM.BookingDate);
            var time = TimeOnly.Parse(bookingVM.BookingTime);
            Booking booking = new Booking
            {
                ApplicationUserId = userId,
                ServiceProviderId = bookingVM.ServiceProviderId,
                BookingDate = date,
                BookingTime = time,
                Status = "Pending"
            };
            if (!string.IsNullOrEmpty(bookingVM.Notes))
            {
                booking.Notes = bookingVM.Notes;
            }
            _unitOfWork.Booking.Add(booking);
            _unitOfWork.Save();
            return RedirectToAction("Index", "Home");

        }
    }
}
