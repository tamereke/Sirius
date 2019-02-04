using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using AutoMapper;

namespace Sirius.Core.Mapping
{
    public class MapperManager
    {
        public static IMapper CreateMapper()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                var all = Assembly
               .GetEntryAssembly()
               .GetReferencedAssemblies()
               .Select(Assembly.Load)
               .SelectMany(x => x.DefinedTypes)
               .Where(type => typeof(IProfile).IsAssignableFrom(type) && type.IsClass && !type.IsInterface && !type.IsAbstract);

                foreach (var t in all)
                { 
                    mc.AddProfile(Activator.CreateInstance(t) as Profile);
                }
            });
            return mappingConfig.CreateMapper();
        }
    }
}
