using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace OzerNet.Commands.Infrastructure
{
    public static class AttributeHelper
    {
        public static T GetAttribute<T>(this PropertyInfo element) where T : Attribute
        {
            var attribute = (element.GetCustomAttributes(typeof(T)).FirstOrDefault() as T);
            return attribute;
        }

        public static object GetPropertyValue<T>(this T command, string propertyName)
        {
            var value = command.GetType().GetProperty(propertyName)?.GetValue(command);
            return value;
        }

        public static T GetPropertyValue<T>(this object command, string propertyName)
        {
            var value = command.GetPropertyValue(propertyName);
            try
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch
            {
                return default(T);
            }
        }

        public static bool NullOrEmptyControl(this object element)
        {
            var isNullOrEmpty = element == null || string.IsNullOrEmpty(element.ToString()) || string.IsNullOrWhiteSpace(element.ToString());
            return isNullOrEmpty;
        }
    }
}
