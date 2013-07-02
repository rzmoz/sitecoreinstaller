using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Framework.System
{
    public static class EnumExtensions
    {
        public static T ParseToEnumValue<T>(this string enumValue)
        {
            return (T)Enum.Parse(typeof(T), enumValue);
        }
    }
}
