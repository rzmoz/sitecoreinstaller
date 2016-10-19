using DotNet.Basics.IO;

namespace SitecoreInstaller
{
    public class AppDataDir : DirPath
    {
        public AppDataDir(DirPath fullPath) : base(fullPath.FullName)
        {
        }
        public DirPath Packages => Add(nameof(Packages).ToLowerInvariant());
        public FilePath LicenseXml => this.ToFile("license.xml");
    }
}
