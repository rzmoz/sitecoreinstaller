using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SitecoreInstaller.Host
{
    public class SiPage
    {
        private static readonly char[] _modulesSplit = { ';' };

        private static string _placeholdersPattern = @"@@([a-zA-A\-]+)@@";
        private static readonly Regex _placeholdersRegex = new Regex(_placeholdersPattern, RegexOptions.Compiled | RegexOptions.Singleline);

        private static string _modulesPattern = @"@modules\[\[(.*?)\]\]";
        private static readonly Regex _modulesRegex = new Regex(_modulesPattern, RegexOptions.Compiled | RegexOptions.Singleline);

        private static string _sectionsPattern = @"@section([ a-zA-Z0-9\-]+)\[\[(.*?)\]\]";
        private static readonly Regex _sectionsRegex = new Regex(_sectionsPattern, RegexOptions.Compiled | RegexOptions.Singleline);

        public SiPage(string html)
        {
            Html = html ?? string.Empty;

            Modules = new List<string>();
            var moduleMatch = _modulesRegex.Match(Html);
            if (moduleMatch.Success)
            {
                var rawModules = moduleMatch.Groups.Cast<Group>().Skip(1).First().Value;
                rawModules = rawModules.Replace("\r", "").Replace("\n", "").Trim();
                Modules =
                    rawModules.Split(_modulesSplit, StringSplitOptions.RemoveEmptyEntries)
                        .Select(m => m.Trim())
                        .ToList();
            }

            Placeholders = _placeholdersRegex.Matches(Html).Cast<Match>().Select(m => m.Groups.Cast<Group>().Skip(1).First().Value).ToList();
            Sections = _sectionsRegex.Matches(Html).Cast<Match>().Select(m =>
            {
                var sectionName = m.Groups.Cast<Group>().Skip(1).First().Value.Trim();
                var sectionContent = m.Groups.Cast<Group>().Skip(2).First().Value;
                return new { sectionName, sectionContent };
            }).ToDictionary(s => s.sectionName, s => s.sectionContent);

            //ensure ignore case in section names
            foreach (var placeholder in Placeholders)
                Html = Html.Replace($"@@{placeholder}@@", $"@@{placeholder.ToLowerInvariant()}@@");
            Placeholders = Placeholders.Select(p => p.ToLowerInvariant()).ToList();
            Sections = Sections.ToDictionary(s => s.Key.ToLowerInvariant(), s => s.Value);
        }

        public string Html { get; }

        public IReadOnlyCollection<string> Modules { get; }
        public IReadOnlyCollection<string> Placeholders { get; }
        public IReadOnlyDictionary<string, string> Sections { get; }
    }
}
