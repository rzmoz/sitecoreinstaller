using DotNet.Basics.IO;

namespace SitecoreInstaller.BuildLibrary
{
    public class BuildLibraryFileResource : BuildLibraryResource<FilePath>
    {
        public BuildLibraryFileResource(FilePath file, BuildLibraryType buildLibraryType) : base(file, buildLibraryType)
        {
        }
    }
}
