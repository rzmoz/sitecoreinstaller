using System;
using System.IO;
using DotNet.Basics.IO;

namespace SitecoreInstaller.Host
{
    public class SiPageBuilder
    {
        private static readonly DirPath _clientRootDir = @".\client".ToDir();
        private static readonly DirPath _pagesRootDir = _clientRootDir.ToDir("pages");
        private static readonly Lazy<SiPage> _clientLayout = new Lazy<SiPage>(() =>
        {
            var html = _clientRootDir.ToFile("layout.html").ReadAllText();
            return new SiPage("Layout", html, null, false);
        });
        private static readonly Lazy<SiPage> _404Page = new Lazy<SiPage>(() => Load("404"));

        public SiPage Build(string name)
        {
            var page = Load(name);
            var renderedHtml = _clientLayout.Value.Render(page);
            return new SiPage(page.Name, renderedHtml, page.Script, page.Is404);
        }

        private static SiPage Load(string name)
        {
            try
            {
                var html = _pagesRootDir.ToFile($"{name}.html").ReadAllText();
                var script = _pagesRootDir.ToFile($"{name}.js").ReadAllText(false) ?? string.Empty;
                return new SiPage(name, html, script, false);
            }
            catch (FileNotFoundException)
            {
                return _404Page.Value;
            }
        }
    }
}
