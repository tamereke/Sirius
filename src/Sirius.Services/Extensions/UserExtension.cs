using System;
using System.Collections.Generic;
using System.Text;
using Sirius.Core;
using Sirius.Entities;

namespace Sirius.Services
{
    public static class UserExtension
    {
        public static string DecryptedPassword(this User user)
        {
            if (user == null)
                throw new ArgumentNullException("User");
            return ApplicationCryptography.DecryptRijndael(user.Password, user.PasswordSalt);
        }
    }
}
