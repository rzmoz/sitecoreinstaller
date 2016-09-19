using System.IO;
using DotNet.Basics.IO;

namespace SitecoreInstaller.Domain.BuildLibrary
{
    public class BuildLibraryDirResource : BuildLibraryResource<DirPath>
    {
        public BuildLibraryDirResource(DirPath dir, BuildLibraryType buildLibraryType) : base(dir, buildLibraryType)
        {
        }
    }
}
