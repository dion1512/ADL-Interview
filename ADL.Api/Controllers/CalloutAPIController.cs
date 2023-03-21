using ADL.Data.Entities;
using ADL.Repositories.Context;
using ADL.Services.Interfaces;
using ADL.Web.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ADL.Api.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class CalloutAPIController : Controller
    {
        private readonly ILogger<CalloutAPIController> _logger;

        private readonly ICalloutService calloutService;
        private readonly ApplicationContext db;

        public CalloutAPIController(ILogger<CalloutAPIController> logger, ICalloutService calloutService, ApplicationContext db)
        {
            _logger = logger;
            this.calloutService = calloutService;
            this.db = db;

        }
        [HttpGet]
        [Route("GetCallouts")]
        public IActionResult GetAll()
        {
            var callouts = calloutService.GetCallouts().ToList();

            return Ok(callouts);
        }
        [HttpGet]
        [Route("GetCallout")]
        public IActionResult Get(long id)
        {
            var callout = calloutService.GetCallout(id);

            return Ok(callout);
        }



    }
}
