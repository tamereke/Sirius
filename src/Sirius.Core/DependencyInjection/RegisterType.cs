using System;
using System.Collections.Generic;
using System.Text;

namespace Sirius.Core.DependencyInjection
{
    public enum RegisterTypes
    {
        PerDependency = 1,
        PerRequest = 2,
        SingleInstance = 3,
        PerLifetimeScope=4,
        PerMatchingLifetimeScope = 5,
        PerOwned = 6,
        ThreadScope = 7,  
    }
}
