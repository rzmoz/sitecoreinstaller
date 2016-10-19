using DotNet.Basics.IO;

namespace SitecoreInstaller.BuildLibrary
{
    public abstract class BuildLibraryResource
    {
        protected BuildLibraryResource(PathInfo path)
        {
            Path = path;
            Name = path.Name;
        }

        public string Name { get; }
        public PathInfo Path { get; }
    }
}
