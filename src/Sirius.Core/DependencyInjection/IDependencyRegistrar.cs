using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sirius.Core.DependencyInjection
{
    public interface IDependencyRegistrar
    {
        int Order { get; }

        void Register(ContainerBuilder builder    );
    }
}
