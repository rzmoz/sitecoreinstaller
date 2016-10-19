using DotNet.Basics.IO;

namespace SitecoreInstaller.BuildLibrary
{
    public class Sitecore : BuildLibraryResource
    {
        public Sitecore(DirPath path) : base(path)
        {
        }

        public DirPath Databases => Path.ToDir(nameof(Databases));
        public DirPath Data => Path.ToDir(nameof(Data));
        public DirPath Website => Path.ToDir(nameof(Website));
    }
}
