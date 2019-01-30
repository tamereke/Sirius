using Autofac;
using Sirius.Core;
using Sirius.Core.Data;
using Sirius.Core.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Sirius.Data
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public int Order => 2;

        public void Register(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(MainRepository<>)).As(typeof(IMainRepository<>)).InstancePerLifetimeScope(); 
        }
    }
}
