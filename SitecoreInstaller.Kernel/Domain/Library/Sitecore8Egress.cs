using DotNet.Basics.IO;
using DotNet.Basics.Sys;

namespace SitecoreInstaller.Kernel.Domain.Library
{
    public class Sitecore8Egress : DirPath, IEgressAsset
    {
        public Sitecore8Egress(string path) : base(path)
        {
        }

        public DirPath Dacpacs => this.ToDir("Dacpacs");
        public DirPath Website => this.ToDir("Website");
        public DirPath AppData => Website.Add("App_Data");
        public DirPath AppConfig => Website.Add("App_Config");
    }
}
