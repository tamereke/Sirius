using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sirius.Web.Framework.Events
{    public class ApplicationCookieAuthenticationEvents : CookieAuthenticationEvents
    {
        //private readonly IUserService _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApplicationCookieAuthenticationEvents( IHttpContextAccessor httpContextAccessor)
        {
         
            //_userRepository = provider.GetService<IUserService>();

            _httpContextAccessor = httpContextAccessor;
        }

        public override async Task ValidatePrincipal(CookieValidatePrincipalContext context)
        {
            
        }
    }
}
