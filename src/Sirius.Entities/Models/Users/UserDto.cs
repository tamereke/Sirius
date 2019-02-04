using System;
using System.Collections.Generic;
using System.Text;

namespace Sirius.Entities.Models
{
    public class UserDto :BaseIdModel
    { 
        public string UserName
        {
           get;set;
        }

        public string Name
        { get; set; }

        public string Surname
        { get; set; }

        public string FullName
        { get; set; }

    }
}
