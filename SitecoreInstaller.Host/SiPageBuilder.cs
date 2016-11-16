using System;
using System.IO;
using DotNet.Basics.IO;
using DotNet.Basics.Sys;

namespace SitecoreInstaller.Host
{
    public class SiPageBuilder
    {
        private static DirPath PagesRootDir => @".\client\pages".ToDir();
        private static readonly Lazy<string> _clientHtml = new Lazy<string>(() => PagesRootDir.ToFile("client.html").ReadAllText());
        private static readonly Lazy<string> _404Html = new Lazy<string>(() => PagesRootDir.ToFile("404.html").ReadAllText());

        public SiPage Build(string name)
        {
            var page = Load(name);
            var mergedHtml = _clientHtml.Value.Replace("@@[[page-content]]@@", page.Html, StringComparison.OrdinalIgnoreCase);
            mergedHtml = mergedHtml.Replace("@@[[page-title]]@@", page.Title, StringComparison.InvariantCultureIgnoreCase);
            mergedHtml = mergedHtml.Replace("@@[[page-script]]@@", page.Script, StringComparison.InvariantCultureIgnoreCase);
            return new SiPage(page.Name, mergedHtml, page.Script, page.Is404);
        }

        private SiPage Load(string name)
        {
            try
            {
                var html = PagesRootDir.ToFile($"{name}.html").ReadAllText();
                var script = PagesRootDir.ToFile($"{name}.js").ReadAllText(false) ?? string.Empty;
                return new SiPage(name, html, script, false);
            }
            catch (FileNotFoundException)
            {
                return new SiPage(name, _404Html.Value, null, true);
            }
        }
    }
}
