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

        public string Name { get; private set; }
        public string Type { get; private set; }
        public string Parameters { get; private set; }
    }
}
