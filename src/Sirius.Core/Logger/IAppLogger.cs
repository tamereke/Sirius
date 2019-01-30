using System;
using System.Collections.Generic;
using System.Text;

namespace Sirius.Core
{

    public interface IAppLogger<out category>:IAppLogger
    {  
    }
}
