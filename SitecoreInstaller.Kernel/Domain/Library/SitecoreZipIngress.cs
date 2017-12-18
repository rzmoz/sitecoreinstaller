using DotNet.Basics.Sys;

namespace SitecoreInstaller.Kernel.Domain.Library
{
    public class SitecoreZipIngress : FilePath, IIngressAsset
    {
        public SitecoreZipIngress(string path) : base(path)
        {
        }

        public PathInfo Source { get; }
        public void Extract(DirPath targetDir)
        {
            throw new System.NotImplementedException();
        }
    }
}
