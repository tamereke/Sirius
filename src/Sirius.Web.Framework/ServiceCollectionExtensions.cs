using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sirius.Core;
using System;

namespace Sirius.Web.Framework
{
    public static class ServiceCollectionExtensions
    {
        //public static IServiceProvider ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
        //{ 

        //    InitAssembly();
        //    var serviceProvider = SiriusCore.Instance.Initialize(services, configuration);



        



        //   return serviceProvider;
        //}

        private static void InitAssembly()
        {
            Sirius.Core.Initialization.Init();
            Sirius.Data.Initialization.Init();
            Sirius.Services.Initialization.Init();
        }

        public static void AddHttpContextAccessor(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

    }
}
