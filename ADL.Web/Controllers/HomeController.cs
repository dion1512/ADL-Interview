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
using ADL.Web.Utils;

namespace ADL.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        private readonly ICalloutService calloutService;
        private readonly ICategoryService categoryService;
        private readonly ApplicationContext db;

        public HomeController(ILogger<HomeController> logger, ICalloutService calloutService, ICategoryService categoryService, ApplicationContext db)
        {
            _logger = logger;
            this.calloutService = calloutService;
            this.categoryService = categoryService;
            this.db = db;
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
                    DateBookedEnd = startDate.AddHours(2)

                };
                
                

                calloutService.InsertCallout(callout);
               
                viewModel.JsonFile = Utils.Utils.createJSONFile(callout);
                viewModel.XmlFile = Utils.Utils.createXMLFile(callout);
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