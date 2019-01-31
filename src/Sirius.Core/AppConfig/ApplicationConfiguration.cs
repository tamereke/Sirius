using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sirius.Core.AppConfig
{
    //TODO : refactoring => const setting name 
    //add get method to other data type  
    /// <summary>
    /// Represented ApplicationConfiguration
    /// </summary>
    public class ApplicationConfiguration : IApplicationConfiguration
    {
        private static readonly object padlock = new object();
        /// <summary>
        /// Initialization
        /// </summary>
        public ApplicationConfiguration()
        {
        }

        /// <summary>
        /// Get or set ConnectionStrings
        /// </summary>
        public ConnectionStrings ConnectionStrings
        {
            get; private set;
        }
        /// <summary>
        /// Get or set GeneralSettings
        /// </summary>
        public GeneralSettings GeneralSettings
        {
            get; private set;
        }
        /// <summary>
        /// Get or set WebApiSettings
        /// </summary>
        public WebApiSettings WebApiSettings
        {
            get; private set;
        }
        /// <summary>
        /// Get or set Loging
        /// </summary>
        public Logging Logging
        { get; private set; }
        /// <summary>
        /// Create singleton instance
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <param name="configuration">IConfiguration</param>
        public ApplicationConfiguration Init(IConfiguration configuration)
        {
            //call get section method
            ConnectionStrings = new ConnectionStrings();
            configuration.GetSection("ConnectionStrings").Bind(ConnectionStrings);

            GeneralSettings = new GeneralSettings();
            configuration.GetSection("GeneralSettings").Bind(GeneralSettings);

            WebApiSettings = new WebApiSettings();
            configuration.GetSection("WebApiSettings").Bind(WebApiSettings);

            Logging = new Logging();
            configuration.GetSection("Logging").Bind(Logging); 




            return this;
        }

        public static TSetting GetSection<TSetting>(IConfiguration configuration) where TSetting : class, IAppSetting, new()
        {
            var setting = new TSetting();
            configuration.GetSection(setting.GetType().Name).Bind(setting);
            return setting;
        }
    }
}
