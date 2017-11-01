using DotNet.Basics.Sys;
using SitecoreInstaller.Domain;

namespace SitecoreInstaller.Infrastructure
{
    public class IoResource : IResource
    {
        public IoResource(PathInfo path)
        {
            Path = path;
        }

        public string Name => Path.Name;
        public PathInfo Path { get; }
    }
}
