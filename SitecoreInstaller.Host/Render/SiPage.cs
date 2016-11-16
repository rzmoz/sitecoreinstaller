namespace SitecoreInstaller.Host.Render
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

        public string Title { get; }
        public string Name { get; }
        public string Html { get; }
        public string Script { get; }
        public bool Is404 { get; }
    }
}
