using Autofac;
using Sirius.Core;
using Sirius.Core.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Sirius.Services
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public int Order => 3;

        public void Register(ContainerBuilder builder)
        { 
            SiriusCore.Instance.RegisterFromAttribute(builder, Assembly.GetExecutingAssembly());
        }
    }
}
