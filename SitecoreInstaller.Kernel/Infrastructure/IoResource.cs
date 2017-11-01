using DotNet.Basics.Sys;
using SitecoreInstaller.Domain.Library;

namespace SitecoreInstaller.Infrastructure
{
    public class IoResource : ILibraryResource
    {
        public IoResource(PathInfo path)
        {
            Path = path;
        }

        public string Name => Path.Name;
        public PathInfo Path { get; }
    }
}
