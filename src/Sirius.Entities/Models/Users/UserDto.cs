using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sirius.Entities.Models
{
    public class UserDto :BaseIdModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string FullName { get; set; }

        public string PasswordSalt { get; set; } 

        public string Token { get; set; }

    }
}
