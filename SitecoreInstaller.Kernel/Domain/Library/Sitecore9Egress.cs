using DotNet.Basics.IO;
using DotNet.Basics.Sys;

namespace SitecoreInstaller.Kernel.Domain.Library
{
    public class Sitecore9Egress : DirPath, IEgressAsset
    {
        public Sitecore9Egress(string path) : base(path)
        {
        }

        public DirPath Databases => this.ToDir("Databases");
        public DirPath Content => this.Add(Name);
        public DirPath MarketingAutomationService => this.ToDir($"Marketing Automation Service {Name}");
        public DirPath XConnectIndexService => this.ToDir($"XConnect Index Service {Name}");
        public DirPath XConnectServer => this.ToDir($"X Connect Server {Name}");
    }
}
