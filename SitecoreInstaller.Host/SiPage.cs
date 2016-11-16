namespace SitecoreInstaller.Host
{
    public class SiPage
    {
        public SiPage(string name, string html, string script,bool is404)
        {
            
            Name = name ?? "Not Found";
            Title = Name.Replace("-", " ");
            Html = html ?? string.Empty;
            Script = script ?? string.Empty;
            Is404 = is404;
        }

        public string Name { get; }
        public string Title { get; }
        public string Html { get; }
        public string Script { get; }
        public bool Is404 { get; }
    }
}
