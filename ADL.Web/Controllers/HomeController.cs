using ADL.Data.Entities;
using ADL.Services;
using ADL.Services.Implementations;
using ADL.Services.Interfaces;
using ADL.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using ADL.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using ADL.Web.AppUtils;

namespace ADL.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        private readonly ICalloutService calloutService;
        private readonly ICategoryService categoryService;
        private readonly IEmailService emailService;
        private readonly ApplicationContext db;

        public HomeController(ILogger<HomeController> logger, ICalloutService calloutService, ICategoryService categoryService, ApplicationContext db, IEmailService emailService)
        {
            _logger = logger;
            this.calloutService = calloutService;
            this.categoryService = categoryService;
            this.db = db;
            this.emailService = emailService;
        }

        public IActionResult Index()
        {
            CalloutViewModel viewModel = new CalloutViewModel
            {
                Categories = categoryService.GetCategories().Select(c => new SelectListItem() { Text = c.CategoryName.ToString(), Value = c.Id.ToString() })
            };

            return View(viewModel);
        }
        [HttpGet]
        public JsonResult GetSchedule(string day, string date)
        {
            var timings = db.Schedule.Where(s => s.DayName == day).ToList();
            var dateCheck = DateTime.Parse(date).Date;
            var bookings = db.Callout.Where(c => c.DateBookedStart.Date == dateCheck).ToList();
            return Json(new { success = true, data = timings, existingBookings = bookings});
        }
        [HttpPost]
        public IActionResult Insert(CalloutViewModel calloutViewModel)
        {
            CalloutViewModel viewModel = new CalloutViewModel
            {
                Categories = categoryService.GetCategories().Select(c => new SelectListItem() { Text = c.CategoryName.ToString(), Value = c.Id.ToString() })
            };
            if (ModelState.IsValid)
            {
                var date = DateTime.Parse(calloutViewModel.DateBooked);
                var time = TimeSpan.Parse(calloutViewModel.TimeSlot);

                var startDate = date.Add(time);

                Callout callout = new Callout()
                {

                    FirstName = calloutViewModel.FirstName,
                    LastName = calloutViewModel.LastName,
                    EmailAddress = calloutViewModel.EmailAddress,
                    ContactNumber = calloutViewModel.ContactNumber,
                    Address = calloutViewModel.Address,
                    VehicleReg = calloutViewModel.VehicleReg,
                    CategoryID = calloutViewModel.Category,
                    Notes = calloutViewModel.Notes,
                    DateBookedStart = startDate,
                    DateBookedEnd = startDate.AddHours(2),
                };
                
                

                calloutService.InsertCallout(callout);
               
                viewModel.JsonFile = Utils.createJSONFile(callout);
                viewModel.XmlFile = Utils.createXMLFile(callout);

                var calloutData = db.Callout.Where(c => c.Id == callout.Id).FirstOrDefault();
                string emailBody = $"First Name: {calloutData.FirstName}<br />Last Name: {calloutData.LastName}<br />Email: {calloutData.EmailAddress}<br >Phone: {calloutData.ContactNumber}<br />Address: {calloutData.Address}<br />" +
                    $"Vehicle Reg: {calloutData.VehicleReg}<br />Category: {calloutData.Category.CategoryName}<br />Date Booked: {calloutData.DateBookedStart} - {calloutData.DateBookedEnd}<br /><br />Notes: {calloutData.Notes}";
                var message = new Message(new string[] { "adl@test.com" }, "New Engineer Callout", emailBody);
                //emailService.SendEmail(message);
                viewModel.Success = true;
                

                return View("Index", viewModel);

            }
            else
            {
                viewModel.Success = false;
                return View("Index", viewModel);
            }
            
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}