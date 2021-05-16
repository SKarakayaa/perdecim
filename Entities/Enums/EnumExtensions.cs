using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Entities.Enums
{
    public static class EnumExtensions
    {
        private static DisplayAttribute GetDisplayAttribute(object value)
        {
            Type type = value.GetType();

            FieldInfo field = type.GetField(value.ToString());
            return field.GetCustomAttribute<DisplayAttribute>() ?? null;
        }

        public static string GetDisplayName(this Enum enu)
        {
            DisplayAttribute attr = GetDisplayAttribute(enu);
            return attr == null ? enu.ToString() : attr.Name;
        }
    }
}