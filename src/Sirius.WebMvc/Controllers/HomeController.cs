using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sirius.Core;
using Sirius.Services.CoreService;
using Sirius.WebMvc.Models;

namespace Sirius.WebMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAppLogger<HomeController> logger;
        private readonly IUserService _userService;

        public HomeController(IAppLogger<HomeController> logger,IUserService userService)
        { 
            this.logger = logger;
            _userService = userService;
        }
        public IActionResult Index()
        {  
            logger.Log("first log");
           var a = _userService.GetItems(x => x.UserName == "xxxx");
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
