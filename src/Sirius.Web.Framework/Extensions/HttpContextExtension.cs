using Sirius.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sirius.Services.CoreService;

namespace Sirius.Web.Framework.Extensions
{
    public static class HttpContextExtension
    {
        public static User GetCurrentUser(this HttpContext context)
        {
            var userId = Convert.ToInt32(context.User.Identity.Name);
            if (userId == 0)
                throw new Exception("User not found in Current Request");
            var provider = context.RequestServices;
            var userService = (IUserService)provider.GetService(typeof(IUserService));
            var user = userService.GetUsers().Item.FirstOrDefault(x=>x.Id == userId);
            return user;
        }
    }
}
