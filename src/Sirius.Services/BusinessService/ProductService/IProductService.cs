using Sirius.Core.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sirius.Services.BusinessService
{
    [ServiceRegister(RegisterTypes.PerLifetimeScope, typeof(ProductService))]
    public interface  IProductService
    {
    }
}
