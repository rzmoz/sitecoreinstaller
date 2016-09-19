using DotNet.Basics.IO;

namespace SitecoreInstaller.Domain.BuildLibrary
{
    public class BuildLibraryFileResource : BuildLibraryResource<FilePath>
    {
        public BuildLibraryFileResource(FilePath file, BuildLibraryType buildLibraryType) : base(file, buildLibraryType)
        {
        }
    }
}
