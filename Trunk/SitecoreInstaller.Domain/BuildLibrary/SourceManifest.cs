namespace SitecoreInstaller.Domain.BuildLibrary
{
    public class SourceManifest
    {
        public SourceManifest()
        {
        }

        public SourceManifest(string name, string type, string parameters)
        {
            Name = name ?? string.Empty;
            Type = type ?? string.Empty;
            Parameters = parameters ?? string.Empty;
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public string Parameters { get; set; }
    }
}
