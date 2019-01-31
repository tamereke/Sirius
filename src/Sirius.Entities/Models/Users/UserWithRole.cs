using System;
using System.Collections.Generic;
using System.Text;

namespace Sirius.Entities.Models
{
    public class UserWithRole
    {
        public User User
        { get; set; }

        public UserRole UserRole
        { get; set; }
    }
}
