using DotNet.Basics.Sys;

namespace SitecoreInstaller.Domain.Library
{
    public abstract class LibraryResource : ILibraryResource
    {
        public string Name => Path.Name;
        public PathInfo Path { get; set; }
    }
}
