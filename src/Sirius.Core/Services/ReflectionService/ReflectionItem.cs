using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Sirius.Core.Services.ReflectionService
{
    public class ReflectionItem
    {
        public ReflectionItem()
        {
            AttributeList = new Dictionary<Type, List<Attribute>>();
            PropertyList = new List<PropertyInfo>();
        }
        public  Dictionary<Type, List<Attribute>>  AttributeList
        { get; set; }

        public List<PropertyInfo> PropertyList
        { get; set; }
    }
}
