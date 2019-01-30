using Sirius.Core.Cache;
using Sirius.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sirius.Entities
{
    [CacheEntity()]
    public class Role: BaseEntity, INamed
    {
        [Required]
        public string Name { get; set; }
    }
}
