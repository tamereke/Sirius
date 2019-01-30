using Sirius.Entities;
using Sirius.Web.Framework.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sirius.Web.Framework
{
    [Authorize()]
    public class BaseController:Controller
    {
        private User _CurrentUser;

        public User CurrentUser
        {
            get
            {
                if (_CurrentUser == null)
                    _CurrentUser = HttpContext.GetCurrentUser();
                return _CurrentUser;
            }
        }
    }
}
