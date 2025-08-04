using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using GerberTools.Attributes;

namespace GerberTools.Extensions
{
    public static class AttributeExtensions
    {
        public static T? GetFieldAttribute<T>(this Type type, string fieldName) where T : Attribute
        {
            var field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            return field?.GetCustomAttribute<T>();
        }

        public static T? GetPropertyAttribute<T>(this Type type, string propertyName) where T : Attribute
        {
            var prop = type.GetProperty(propertyName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            return prop?.GetCustomAttribute<T>();
        }

        public static void FindAttribute<TAttribute>(this object obj, Action<TAttribute, object> action)
            where TAttribute : Attribute
        {
            var type = obj.GetType();

            foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (Attribute.IsDefined(prop, typeof(TAttribute)))
                {
                    var attribute = prop.GetCustomAttribute<TAttribute>();
                    var value = prop.GetValue(obj);

                    if (value is not null && !value.IsDefault())
                    {
                        action(attribute!, value);
                    }
                }
            }
        }
    }
}
