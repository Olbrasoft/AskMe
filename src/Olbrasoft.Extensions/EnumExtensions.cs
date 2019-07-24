using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Olbrasoft.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var result = value
                             .GetType()
                             .GetMember(value.ToString())
                             .FirstOrDefault()
                             ?.GetCustomAttribute<DescriptionAttribute>()
                             ?.Description ?? value.ToString();

            return result;
        }
    }
}