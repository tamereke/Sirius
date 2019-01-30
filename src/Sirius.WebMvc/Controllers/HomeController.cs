using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sirius.Core;
using Sirius.Services.TestService;
using Sirius.WebMvc.Models;

namespace Sirius.WebMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITestService testservice;
        private readonly IAppLogger<HomeController> logger;

        public HomeController(ITestService testservice, IAppLogger<HomeController> logger)
        {
            this.testservice = testservice;
            this.logger = logger;
        }
        public IActionResult Index()
        {
            var val = testservice.GetValue();

            logger.Log("first log");

            return View();
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
