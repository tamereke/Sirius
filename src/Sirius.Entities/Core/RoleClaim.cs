using Sirius.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sirius.Entities
{
    public class RoleClaim : BaseEntity
    {
        [Required]
        public int RoleId { get; set; }
        [Required]
        public int ClaimId { get; set; }
    }
}
