using DotNet.Basics.Sys;

namespace SitecoreInstaller.Domain.Library.Sitecores
{
    public class Sitecore9 : LibraryResource
    {
        public Sitecore9(DirPath path)
        {
            Path = path;
        }

        public DirPath Databases => Path.ToDir("Databases");
        public WebRoot WebRoot => new WebRoot(Path.Add(Name).RawPath);
        public DirPath MarketingAutomationService => Path.ToDir($"Marketing Automation Service {Name}");
        public DirPath XConnectIndexService => Path.ToDir($"XConnect Index Service {Name}");
        public DirPath XConnectServer => Path.ToDir($"X Connect Server {Name}");
    }
}
