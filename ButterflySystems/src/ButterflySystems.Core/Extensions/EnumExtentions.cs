using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace ButterflySystems.Core.Extensions
{
    public static class EnumExtentions
    {
        public static string GetDescription(this Enum enumValue)
        {
            return enumValue.GetType()
                       .GetMember(enumValue.ToString())
                       .First()
                       .GetCustomAttribute<DescriptionAttribute>()?
                       .Description ?? string.Empty;
        }
    }
}
