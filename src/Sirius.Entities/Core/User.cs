﻿using Sirius.Core.Cache;
using Sirius.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sirius.Entities
{
    [CacheEntity()]
    public class User : BaseEntity,INamed,ICloneable
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PasswordSalt { get; set; } 
        [NotMapped]
        public string Token { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
