using System.IO;
using DotNet.Basics.IO;

namespace SitecoreInstaller.Host.ClientControllers
{
    public class PageFactory
    {
        private readonly DirPath _pagesDir;
        private readonly FilePath _clientHtml;

        public PageFactory(DirPath pagesDir)
        {
            _pagesDir = pagesDir;
            _clientHtml = _pagesDir.ToFile("client.html");
        }

        public SiPage Get(string name)
        {
            var clientPage = new SiPage(name, _clientHtml.ReadAllText(), string.Empty, false);
            SiPage page;
            try
            {
                var pageHtml = _pagesDir.ToFile($"{name}.html").ReadAllText();
                var pageScript = _pagesDir.ToFile($"{name}.js").ReadAllText(false);
                page = new SiPage(name, pageHtml, pageScript, false);
            }
            catch (FileNotFoundException)
            {
                var notFoundHtml = _pagesDir.ToFile("404.html").ReadAllText();
                page = new SiPage("Not Found", notFoundHtml, null, true);
            }
            return clientPage.Apply(page);
        }
    }
}
