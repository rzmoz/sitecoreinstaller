using DotNet.Basics.IO;

namespace SitecoreInstaller.Domain.InstallerLib.Sitecores
{
    public class Sitecore9 : InstallerResource
    {
        public Sitecore9(DirPath path) : base(path)
        {
        }

        public DirPath Databases => Path.Add("Databases");
        public WebRoot WebRoot => new WebRoot(Path.Add(Name).RawPath);
        public DirPath MarketingAutomationService => Path.Add($"Marketing Automation Service {Name}");
        public DirPath XConnectIndexService => Path.Add($"XConnect Index Service {Name}");
        public DirPath XConnectServer => Path.Add($"X Connect Server {Name}");
    }
}
