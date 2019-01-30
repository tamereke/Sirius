using System;
using System.Collections.Generic;
using System.Text;

namespace Sirius.Core.AppConfig
{
    public class WebApiSettings:IAppSetting
    {
        public string SecretKey
        { get; set; }
        public int Expires
        { get; set; }
        
    }
}
