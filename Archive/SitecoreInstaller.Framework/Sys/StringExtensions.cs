using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Framework.Sys
{
    public static class StringExtensions
    {
        public static string RemoveNewLine(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            return str.Replace("\r", string.Empty).Replace("\n", string.Empty);
        }

        public static string Remove(this string originalString, string valuetoRemove)
        {
            return originalString.ReplaceCaseInsensitive(valuetoRemove, string.Empty);
        }

        public static string ReplaceCaseInsensitive(this string originalString, string oldValue, string newValue)
        {
            int startIndex = 0;
            while (true)
            {
                startIndex = originalString.IndexOf(oldValue, startIndex, StringComparison.InvariantCultureIgnoreCase);
                if (startIndex == -1)
                    break;

                originalString = originalString.Substring(0, startIndex) + newValue + originalString.Substring(startIndex + oldValue.Length);

                startIndex += newValue.Length;
            }

            return originalString;
        }



        public static string ToSpaceDelimiteredString(this string str)
        {
            return str.TokenizeWhenCharIsUpper().ToDelimiteredString();
        }

        internal static IEnumerable<string> TokenizeWhenCharIsUpper(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return Enumerable.Empty<string>();

            var resolvedName = new StringBuilder();

            foreach (var @char in str.ToArray())
            {
                if (Char.IsUpper(@char))
                    resolvedName.Append(' ');
                resolvedName.Append(@char);
            }
            return resolvedName.ToString().Trim().Split(' ');
        }
    }
}
