using System;
using DotNet.Basics.Sys;

namespace SitecoreInstaller.Host.ClientControllers
{
    public class SiPage
    {
        public SiPage(string name, string pageHtml, string script, bool is404)
        {
            Name = name;
            Html = pageHtml ?? string.Empty;
            Script = script ?? string.Empty;
            Is404 = is404;
            Title = name.Replace("-", " "); ;
        }

        public SiPage Apply(SiPage page, Action<SiPage> init = null)
        {
            var mergedHtml = Html.Replace("@@[[page-content]]@@", page.Html, StringComparison.OrdinalIgnoreCase);
            mergedHtml = mergedHtml.Replace("@@[[page-title]]@@", page.Title, StringComparison.InvariantCultureIgnoreCase);
            mergedHtml = mergedHtml.Replace("@@[[page-script]]@@", page.Script, StringComparison.InvariantCultureIgnoreCase);
            var newPage = new SiPage(page.Name, mergedHtml, page.Script, page.Is404);
            init?.Invoke(newPage);
            return newPage;
        }
        public string Title { get; }
        public string Name { get; }
        public string Html { get; }
        public string Script { get; }
        public bool Is404 { get; }
    }
}
