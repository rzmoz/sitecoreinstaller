using DotNet.Basics.IO;

namespace SitecoreInstaller.Domain.InstallerLib
{
    public abstract class InstallerResource : IInstallerResource
    {
        public string Name => Path.Name;
        public PathInfo Path { get; set; }
    }
}
