using DotNet.Basics.IO;

namespace SitecoreInstaller.BuildLibrary
{
    public abstract class BuildLibraryResource
    {
        protected BuildLibraryResource(DirPath dir)
        {
            Dir = dir;
            Name = dir.Name;
        }

        public string Name { get; }
        public DirPath Dir { get; }
    }
}
