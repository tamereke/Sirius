using Autofac;
using Sirius.Core.Cache;
using Sirius.Core.DependencyInjection;
using Sirius.Core.Services.ReflectionService;
using Sirius.Core.Services.SessionServices;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Sirius.Core
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public int Order => 1;

        public void Register(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(NLogLogger<>)).As(typeof(IAppLogger<>)).SingleInstance();
            builder.RegisterType(typeof(ReflectionService)).As(typeof(IReflectionService)).SingleInstance();
            builder.RegisterType(typeof(MemoryCacheService)).As(typeof(ICacheService)).SingleInstance();
            builder.RegisterType(typeof(SessionService)).As(typeof(ISessionService)).InstancePerLifetimeScope(); 
        }
    }
}
