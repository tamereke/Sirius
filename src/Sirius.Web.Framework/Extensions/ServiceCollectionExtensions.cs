using Sirius.Core;
using Sirius.Core.AppConfig;
using Sirius.Core.Cache;
using Sirius.Core.Data;
using Sirius.Core.Enums;
using Sirius.Core.Services.ReflectionService;
using Sirius.Core.Services.SessionServices;
using Sirius.Data;
using Sirius.Web.Framework.Events;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;
using Sirius.Services.BusinessService;
using Sirius.Services.CoreService;
using Sirius.Web.Framework.Filters;

namespace Sirius.Web.Framework.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceProvider ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration, AuthenticationTypes authenticationType)
        {

            try
            {
                InitAssembly();
                //add accessor to HttpContext
                services.AddHttpContextAccessor();
                services.AddMemoryCache();
                //Cinfigure Cookie
                services.ConfigureCookie();
                //Configure Authetication
                if (authenticationType == AuthenticationTypes.Cookie)
                    services.ConfigureCookieAuthentication();
                //Configure Session
                services.ConfigureSession(configuration);
                //Configure database
                services.ConfigureDatabase(configuration);
                //Add mvc
                services.AddMvc(x => x.Filters.Add(typeof(HttpGlobalExceptionFilter)))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

                if (authenticationType == AuthenticationTypes.Jwt)
                    services.ConfigureJwtAuthentication(configuration);

                //Init application
                var serviceProvider = SiriusCore.Instance.Initialize(services, configuration);

                //Claim const sync to db
                LoadClaims();

                SiriusCore.Instance.Resolve<IAppLogger<SiriusCore>>().LogInfo("Application started");

                return serviceProvider;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void LoadClaims()
        {
            SiriusCore.Instance.Resolve<IClaimService>().LoadClaims();
        }

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

        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionStrings = ApplicationConfiguration.GetSection<ConnectionStrings>(configuration);
            services.AddDbContext<MainContext>(o =>
            o.UseSqlServer(connectionStrings.DefaultConnection));
        }

        public static void ConfigureSession(this IServiceCollection services, IConfiguration configuration)
        {
            var generalSettings = ApplicationConfiguration.GetSection<GeneralSettings>(configuration);
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(generalSettings.SessionTimeout);
                options.Cookie.HttpOnly = true;
            });
        }

        public static void ConfigureCookie(this IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
        }

        public static void ConfigureCookieAuthentication(this IServiceCollection services)
        {

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Login/Login/";
                    options.AccessDeniedPath = "/Login/AccessDenied/";
                    options.LogoutPath = "/Login/Logoff/";
                    options.EventsType = typeof(ApplicationCookieAuthenticationEvents);
                });
            services.AddScoped<ApplicationCookieAuthenticationEvents>();

            #region ApplicationUser
            //services.AddDbContext<ApplicationIdentityDbContext>
            //   (options => options.UseSqlServer(AppCore.Instance.AppConfig.Resolve<ConnectionStrings>().DefaultConnection));
            //services.AddIdentity<ApplicationUser, ApplicationRole>()
            //    .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
            //    .AddDefaultTokenProviders(); 
            #endregion
        }

        public static void ConfigureJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var webApiSettings = ApplicationConfiguration.GetSection<WebApiSettings>(configuration);

            var key = Encoding.UTF8.GetBytes(webApiSettings.SecretKey);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }


    }
}
