﻿using System;

namespace SitecoreInstaller.Framework.Sys
{
    public static class TypeExtensions
    {
        public static bool Is<T>(this Type @type)
        {
            if (type == null)
                return false;
            return @type.FullName.Equals(typeof(T).FullName);
        }
    }
}
