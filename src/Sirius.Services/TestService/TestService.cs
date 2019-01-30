using System;
using System.Collections.Generic;
using System.Text;

namespace Sirius.Services.TestService
{
    public class TestService : ITestService
    {
        int _val = 0;
        public int GetValue()
        {
            _val++;
            return _val; 
        }
    }
}
