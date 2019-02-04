using Sirius.Core.Cache;
using Sirius.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks; 

namespace Sirius.Entities
{
    [CacheEntity()]
    public class Category: BaseEntity
    {
        public string Name { get; set; } 
    }
}
