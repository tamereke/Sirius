using System;
using System.Collections.Generic;
using System.Text;

namespace Sirius.Core.Enums
{
    /// <summary>
    /// Authentication Types
    /// </summary>
    public enum AuthenticationTypes
    {
        /// <summary>
        /// Cookie authentication
        /// </summary>
        Cookie=1,
        /// <summary>
        /// Jwt bearer authentication
        /// </summary>
        Jwt = 2
    }
}
