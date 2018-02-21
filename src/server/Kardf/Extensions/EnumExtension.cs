using System;
using System.ComponentModel;

namespace Kardf.Extensions
{
    public static class EnumExtension
    {
        public static string GetDisplayName(this Enum value)
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            var field = type.GetField(name);
            var attr = field.GetAttribute<DisplayNameAttribute>(false);
            return attr != null ? attr.DisplayName : name;
        }
    }
}
