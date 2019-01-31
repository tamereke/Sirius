using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sirius.Entities.Models;
using Sirius.Services.CoreService;

namespace Sirius.WebMvc.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAppAuthencticationService _service;

        public LoginController(IAppAuthencticationService service)
        { 
            _service = service;
        } 

        public IActionResult Index()
        {
            return View(new LoginModel());
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
               var result =  _service.Login(model);
                if (result.Ok)
                {
                    RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }


    }
}