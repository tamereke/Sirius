using Sirius.Core.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sirius.Services.TestService
{
    [ServiceRegister(RegisterTypes.PerLifetimeScope, typeof(TestService))]
    public interface ITestService
    {
        int GetValue();
    }
}
