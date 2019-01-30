using System;
using System.Collections.Generic;
using System.Text;

namespace Sirius.Core.Cache
{
    public class CacheEntityAttribute: Attribute
    {
        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="timeOut">Seconds
        /// <para>if timeout 0 then value get from appconfig</para>
        /// </param>
        public CacheEntityAttribute(int timeOut=0)
        {
            TimeOut = timeOut;
        }
        /// <summary>
        /// Seconds
        /// </summary>
        public int TimeOut { get; private set; }
    }
}
