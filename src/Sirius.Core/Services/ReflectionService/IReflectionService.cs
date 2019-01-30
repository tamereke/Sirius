using System;
using System.Collections.Generic;
using System.Text;

namespace Sirius.Core.Services.ReflectionService
{
    public interface IReflectionService
    {
        TAttribute GetCustomAttribute<TAttribute>(Type type) where TAttribute : Attribute;
        List<Attribute> GetCustomAttributes(Type objectType, Type attributeType);
    }
}
