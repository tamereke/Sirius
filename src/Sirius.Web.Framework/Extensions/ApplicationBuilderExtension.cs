using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Text;
using Abc.Core.Middlewares.Exceptions;

namespace Sirius.Web.Framework.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static void ConfigureRequestPipeline(this IApplicationBuilder app, IHostingEnvironment env)
        {
       

            app.UseMiddleware<ExceptionMiddleware>();
 


        }
    }
}
