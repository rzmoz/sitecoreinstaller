using System;
using DotNet.Basics.IO;

namespace SitecoreInstaller.BuildLibrary
{
    public abstract class BuildLibraryResource<T> : IBuildLibraryResource where T : Path
    {
        protected BuildLibraryResource(T path, BuildLibraryType buildLibraryType)
        {
            if (path == null) throw new ArgumentNullException(nameof(path));
            Path = path;
            BuildLibraryType = buildLibraryType;
            Directory = path.Directory;
        }

        public string Name => Path.Name;
        public DirPath Directory { get; }
        public string FullName => Path.FullName;
        public BuildLibraryType BuildLibraryType { get; }
        public Path Path { get; }
    }
}
