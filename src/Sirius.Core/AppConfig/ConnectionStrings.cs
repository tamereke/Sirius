using System;
using System.Collections.Generic;
using System.Text;

namespace Sirius.Core.AppConfig
{
    public class ConnectionStrings: IAppSetting
    {
        public string DefaultConnection { get; set; }

        public string DefaultConnection2 { get; set; }
    }
}
