using System.IO;

namespace SitecoreInstaller.Domain.BuildLibrary
{
    public class BuildLibraryFileResource : BuildLibraryResource<FileInfo>
    {
        public BuildLibraryFileResource(FileInfo file, BuildLibraryType buildLibraryType) : base(file, buildLibraryType)
        {
        }
    }
}
