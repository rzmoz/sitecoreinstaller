using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Framework.System
{
    public static class EnumerableExtensions
    {
        public static bool ContainsCaseInsensitive(this IEnumerable<string> hayStack, string needle)
        {
            if (hayStack == null)
                return false;

            if (string.IsNullOrEmpty(needle))
                return false;

            needle = needle.ToLowerInvariant();

            return hayStack.Any(straw => straw.ToLowerInvariant().Equals(needle));
        }

        public static IEnumerable<string> AsUniqueStrings(this IEnumerable<string> enumerable, bool excludeEmpty = true)
        {
            if (enumerable == null)
                yield break;

            var uniqueEntries = new HashSet<string>();

            foreach (var entry in enumerable)
            {
                var processedName = entry.ToLowerInvariant();
                if (uniqueEntries.Contains(processedName) == false)
                {
                    uniqueEntries.Add(processedName);
                    if (excludeEmpty && string.IsNullOrEmpty(entry) == false)
                        yield return entry;
                }
            }
        }

        public static string ToDelimiteredString<T>(this IEnumerable<T> enumerable, char delimiter = ' ')
        {
            if (enumerable == null)
                return string.Empty;

            var resolvedName = new StringBuilder();

            foreach (var element in enumerable)
            {
                resolvedName.Append(delimiter);
                resolvedName.Append(element.ToString());
            }

            resolvedName.Remove(0, 1);//remove initial blank space

            return resolvedName.ToString();
        }
    }
}
