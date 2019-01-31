using System;
using System.Collections.Generic;
using System.Text;

namespace Sirius.Core.AppConfig
{
    public class Logging : IAppSetting
    {
        public Logging()
        {
            CustomSettings = new CustomSettings();
        }
        public CustomSettings CustomSettings
        { get; set; }
    }

    public class CustomSettings
    {
        public bool Enabled
        { get; set; }
    }
}
