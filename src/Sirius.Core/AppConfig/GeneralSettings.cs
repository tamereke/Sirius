using System;
using System.Collections.Generic;
using System.Text;

namespace Sirius.Core.AppConfig
{
    public class GeneralSettings:IAppSetting
    {
        /// <summary>
        /// Get or set SessionTimeout - second
        /// </summary>
        public int SessionTimeout
        { get; set; }

        /// <summary>
        /// Get or set MemoryCacheTimeout - second
        /// </summary>
        public int MemoryCacheTimeout
        { get; set; }
    }
}
