﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sirius.Core.Models;
using Sirius.Entities;
using Sirius.Services.Constants;
using Sirius.Services.CoreService;
using Sirius.Web.Framework;
using Sirius.Web.Framework.Attributes;

namespace Sirius.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [ClaimRequirement(ClaimConst.User.Get)]
        [HttpGet("GetUsers")]
        public IActionResult Get()
        {
            return Ok(_userService.GetUsers());
        }

        [ClaimRequirement(ClaimConst.User.Insert)]
        [HttpPost("AddUser")]
        public IActionResult AddUser([FromBody]User user)
        {
            return Ok(_userService.Insert(user));
        }

        [ClaimRequirement(ClaimConst.User.Delete)]
        [HttpDelete("DeleteUser/{id}")] 
        public IActionResult DeleteUser([FromRoute]int id)
        {
            return Ok(_userService.Delete(id));
        }
    }
}
