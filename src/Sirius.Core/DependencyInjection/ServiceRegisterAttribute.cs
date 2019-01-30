using System;
using System.Collections.Generic;
using System.Text;

namespace Sirius.Core.DependencyInjection
{
    public class ServiceRegisterAttribute : Attribute
    {
        public ServiceRegisterAttribute(RegisterTypes registerTypes, Type implementationType)
        {
            RegisterType = registerTypes;
            ImplementationType = implementationType;
        }

        public RegisterTypes RegisterType
        { get; private set; }
        public Type ImplementationType
        { get; private set; }

    }
}
