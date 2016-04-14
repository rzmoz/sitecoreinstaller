using System.IO;

namespace SitecoreInstaller.Domain.BuildLibrary
{
    public class BuildLibraryDirResource : BuildLibraryResource<DirectoryInfo>
    {
        public BuildLibraryDirResource(DirectoryInfo dir, BuildLibraryType buildLibraryType) : base(dir, buildLibraryType)
        {
        }
    }
}
