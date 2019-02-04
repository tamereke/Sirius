using Sirius.Core.DependencyInjection;
using Sirius.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sirius.Services.BusinessService
{
    [ServiceRegister(RegisterTypes.PerLifetimeScope, typeof(CategoryService))]
    public interface ICategoryService : IDatabaseEntityService<Category>
    {
    }
}
