using DotNet.Basics.IO;

namespace SitecoreInstaller
{
    public class AppConfigDir : DirPath
    {
        public AppConfigDir(DirPath fullPath) : base(fullPath.FullName)
        {
        }

        public DirPath Include => Add(nameof(Include));
        public FilePath ConnectionStringsConfig => this.ToFile("ConnectionStrings.config");
    }
}
