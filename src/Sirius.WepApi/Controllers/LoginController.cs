using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sirius.Entities.Models;
using Sirius.Services.CoreService;

namespace Sirius.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAppAuthencticationService _appAuthencticationService;

        public LoginController(IAppAuthencticationService appAuthencticationService)
        {
            _appAuthencticationService = appAuthencticationService;
        }

        [HttpPost("login")]
        public IActionResult Post([FromBody]LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = _appAuthencticationService.LoginFromWebApi(loginModel);
            if (!response.Ok)
                return BadRequest(response);
            return Ok(response);
        }
    }
}
