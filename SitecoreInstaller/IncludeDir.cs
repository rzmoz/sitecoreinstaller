using DotNet.Basics.IO;

namespace SitecoreInstaller
{
    public class IncludeDir : DirPath
    {
        public IncludeDir(DirPath path) : base(path.FullName)
        { }

        public FilePath DataFolderConfig => this.ToFile("zzDataFolder.config");
    }
}
