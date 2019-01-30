using Sirius.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks; 

namespace Sirius.Entities
{
    public class Test : BaseEntity
    {
        public string TestName { get; set; }
       
    }
}
