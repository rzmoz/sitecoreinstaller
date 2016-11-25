using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using DotNet.Basics.Collections;

namespace SitecoreInstaller.Host
{
    public class SiPage
    {
        private static string _placeholdersPattern = @"@@([a-zA-A\-]+)@@";
        private static readonly Regex _placeholdersRegex = new Regex(_placeholdersPattern, RegexOptions.Compiled | RegexOptions.Singleline);

        private static string _sectionsPattern = @"@section([ a-zA-Z0-9\-]+)\[\[(.*?)\]\]";
        private static readonly Regex _sectionsRegex = new Regex(_sectionsPattern, RegexOptions.Compiled | RegexOptions.Singleline);

        public SiPage(string name, string html, string script, bool is404)
        {

            Name = name ?? "Not Found";
            Title = Name.Replace("-", " ");
            Html = html ?? string.Empty;
            Script = script ?? string.Empty;
            Is404 = is404;
            Placeholders = _placeholdersRegex.Matches(Html).Cast<Match>().Select(m => m.Groups.Cast<Group>().Skip(1).First().Value).ToList();
            Sections = _sectionsRegex.Matches(Html).Cast<Match>().Select(m =>
            {
                var sectionName = m.Groups.Cast<Group>().Skip(1).First().Value.Trim(' ');
                var sectionContent = m.Groups.Cast<Group>().Skip(2).First().Value;
                return new { sectionName, sectionContent };
            }).ToDictionary(s => s.sectionName, s => s.sectionContent);

            //ensure ignore case in section names
            foreach (var placeholder in Placeholders)
                Html = Html.Replace($"@@{placeholder}@@", $"@@{placeholder.ToLowerInvariant()}@@");
            Placeholders = Placeholders.Select(p => p.ToLowerInvariant()).ToList();
            Sections = Sections.ToDictionary(s => s.Key.ToLowerInvariant(), s => s.Value);
        }

        public string Name { get; }
        public string Title { get; }
        public string Html { get; }
        public string Script { get; }
        public bool Is404 { get; }

        public IReadOnlyCollection<string> Placeholders { get; }
        public IReadOnlyDictionary<string, string> Sections { get; }

        public string Render(params SiPage[] subPages)
        {
            var renderedHtml = Html;
            foreach (var placeholder in Placeholders)
            {
                var replacedContent = string.Empty;

                foreach (var subPage in subPages)
                {
                    if (subPage.Sections.ContainsKey(placeholder))
                        replacedContent += $"{subPage.Sections[placeholder]}\r\n";
                }
                renderedHtml = renderedHtml.Replace($"@@{placeholder}@@", replacedContent);
            }
            return renderedHtml;
        }
    }
}
