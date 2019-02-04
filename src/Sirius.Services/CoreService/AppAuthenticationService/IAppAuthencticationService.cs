using Sirius.Core.DependencyInjection;
using Sirius.Core.Models;
using Sirius.Entities;
using Sirius.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sirius.Services.CoreService
{
    [ServiceRegister(RegisterTypes.PerLifetimeScope, typeof(AppAuthenticationService))]
    public interface IAppAuthencticationService
    {
        OperationResult<User> Login(LoginModel loginModel);
        OperationResult<User> LoginWithJwtToken(LoginModel loginModel);
        OperationResult LogOut();
    }
}
