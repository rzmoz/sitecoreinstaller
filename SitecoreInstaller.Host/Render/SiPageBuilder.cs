using System;
using System.IO;
using DotNet.Basics.IO;
using DotNet.Basics.Sys;
using SitecoreInstaller.Host.Render;

namespace SitecoreInstaller.Host.ClientControllers
{
    public class SiPageBuilder
    {
        private readonly DirPath _pagesDir;
        private SiPage _page;

        public SiPageBuilder()
        {
            _pagesDir = @".\client".ToDir("pages");
            var clientPath = _pagesDir.ToFile("client.html");
            _page = new SiPage("Client", clientPath.ReadAllText(), string.Empty, false);
        }

        public void Apply(string name, Func<SiPage, SiPage> init = null)
        {
            var page = Get(name);

            var mergedHtml = _page.Html.Replace("@@[[page-content]]@@", page.Html, StringComparison.OrdinalIgnoreCase);
            mergedHtml = mergedHtml.Replace("@@[[page-title]]@@", page.Title, StringComparison.InvariantCultureIgnoreCase);
            mergedHtml = mergedHtml.Replace("@@[[page-script]]@@", page.Script, StringComparison.InvariantCultureIgnoreCase);
            var newPage = new SiPage(page.Name, mergedHtml, page.Script, page.Is404);
            _page = init?.Invoke(newPage) ?? newPage;
        }

        private SiPage Get(string name)
        {
            try
            {
                var pageHtml = _pagesDir.ToFile($"{name}.html").ReadAllText();
                var pageScript = _pagesDir.ToFile($"{name}.js").ReadAllText(false);
                return new SiPage(name, pageHtml, pageScript, false);
            }
            catch (FileNotFoundException)
            {
                var notFoundHtml = _pagesDir.ToFile("404.html").ReadAllText();
                return new SiPage("Not Found", notFoundHtml, null, true);
            }
        }

        public SiPage Build()
        {
            return _page;
        }
    }
}
