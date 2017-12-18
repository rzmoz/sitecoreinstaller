using DotNet.Basics.Sys;

namespace SitecoreInstaller.Kernel.Domain.Library
{
    public class LicenseFileIngress : FilePath, IIngressAsset
    {
        public LicenseFileIngress(string path) : base(path)
        {
        }

        public PathInfo Source => this;

        public void Extract(DirPath targetDir)
        {
            throw new System.NotImplementedException();
        }
    }
}
