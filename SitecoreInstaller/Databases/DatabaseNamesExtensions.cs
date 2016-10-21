using System.Collections.Generic;

namespace SitecoreInstaller.Databases
{
public static    class DatabaseNamesExtensions
    {
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
    }
}
