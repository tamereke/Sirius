using System;
using System.Collections.Generic;
using System.Text;

namespace Sirius.Core.AppConfig
{
    public class Loging : IAppSetting
    {
        public CustomSettings CustomSettings
        { get; set; }
    }

    public class CustomSettings
    {
        public bool Enabled
        { get; set; }
    }
}
