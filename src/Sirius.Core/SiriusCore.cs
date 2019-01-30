using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sirius.Core.AppConfig;
using Sirius.Core.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;


namespace Sirius.Core
{
    public class SiriusCore
    {
        static Lazy<SiriusCore> _Intance = new Lazy<SiriusCore>();
        private AutofacServiceProvider _serviceProvider;

        public static SiriusCore Instance
        {
            get
            {
                return _Intance.Value;
            }
        }

        public ApplicationConfiguration AppConfig
        {
            get; private set;
        }

        public IServiceProvider Initialize(IServiceCollection services, IConfiguration configuration)
        {
            var containerBuilder = new ContainerBuilder();

            InitConfig(configuration, containerBuilder);

            containerBuilder.RegisterInstance(this).SingleInstance();

            RegisterServices(services, containerBuilder);

            containerBuilder.Populate(services);

            return _serviceProvider = new AutofacServiceProvider(containerBuilder.Build());
        }

        private void RegisterServices(IServiceCollection services, ContainerBuilder containerBuilder)
        {
            var dependencyRegistrars = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes()).Where(t => typeof(IDependencyRegistrar).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

            var instances = dependencyRegistrars.Select(dr => (IDependencyRegistrar)Activator.CreateInstance(dr)).OrderBy(dr => dr.Order);

            foreach (var dr in instances)
                dr.Register(containerBuilder);
        }

        private void InitConfig(IConfiguration configuration, ContainerBuilder builder)
        {
            AppConfig = new ApplicationConfiguration().Init(configuration);
            builder.RegisterInstance(AppConfig).SingleInstance();
        }

        public void RegisterFromAttribute(ContainerBuilder builder, Assembly assembly)
        {
            var allTypes = assembly.GetTypes();

            var serviceTypes = allTypes.Where(x => x.IsInterface && x.GetCustomAttributes().Any(y => y is ServiceRegisterAttribute)).ToList();
            for (int i = 0; i < serviceTypes.Count(); i++)
            {
                var sType = serviceTypes[i];
                var att = sType.GetCustomAttribute(typeof(ServiceRegisterAttribute)) as ServiceRegisterAttribute;
                var impType = att.ImplementationType;
                var registrationBuilder = builder.RegisterType(impType).As(sType);

                switch (att.RegisterType)
                {
                    case RegisterTypes.PerDependency:
                        registrationBuilder.InstancePerDependency();
                        break;
                    case RegisterTypes.PerRequest:
                        registrationBuilder.InstancePerRequest();
                        break;
                    case RegisterTypes.SingleInstance:
                        registrationBuilder.SingleInstance();
                        break;
                    case RegisterTypes.PerLifetimeScope:
                        registrationBuilder.InstancePerLifetimeScope();
                        break;
                    case RegisterTypes.PerMatchingLifetimeScope:
                        registrationBuilder.InstancePerMatchingLifetimeScope();
                        break;
                    case RegisterTypes.PerOwned:
                        throw new NotImplementedException();
                    case RegisterTypes.ThreadScope:
                        throw new NotImplementedException(); 
                    default:
                        break;
                }
            }
        }

        protected IServiceProvider GetServiceProvider()
        {
            var accessor = ServiceProvider.GetService<IHttpContextAccessor>();
            var context = accessor.HttpContext;
            return context?.RequestServices ?? ServiceProvider;
        }

        public T Resolve<T>() where T : class
        {
            return (T)GetServiceProvider().GetRequiredService(typeof(T));
        }

        public object Resolve(Type type)
        {
            return GetServiceProvider().GetRequiredService(type);
        }

        public IServiceProvider ServiceProvider => _serviceProvider;
    }
}
