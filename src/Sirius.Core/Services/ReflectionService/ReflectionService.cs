using Sirius.Core.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Sirius.Core.Services.ReflectionService
{
    public class ReflectionService : IReflectionService
    {
        private Dictionary<Type, ReflectionItem> _Items = new Dictionary<Type, ReflectionItem>();

        public TAttribute GetCustomAttribute<TAttribute>(Type type)
            where TAttribute : Attribute
        {
            return GetCustomAttributes(type, typeof(TAttribute))?.FirstOrDefault() as TAttribute;
        }

        public List<Attribute> GetCustomAttributes(Type objectType, Type attributeType)
        {
            Load(objectType);
            var reflectionItem = _Items[objectType];
            if (reflectionItem.AttributeList.ContainsKey(attributeType))
                return reflectionItem.AttributeList[attributeType];
            return null;
        }

        private void Load(Type type)
        {
            if (_Items.ContainsKey(type))
                return;

            var reflectionItem = new ReflectionItem();
            var atts = type.GetCustomAttributes().ToList();
            
            for (int i = 0; i < atts.Count(); i++)
            {
                var att = atts[i];
                var attType = att.GetType();
                if (!reflectionItem.AttributeList.ContainsKey(attType))
                {
                    reflectionItem.AttributeList.Add(attType, atts.Where(x => x.GetType() == attType).ToList());
                }
            }

            //TODO : Properties

            _Items.Add(type,reflectionItem);
        }
    }
}
