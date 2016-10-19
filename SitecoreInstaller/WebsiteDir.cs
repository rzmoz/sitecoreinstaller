using DotNet.Basics.IO;

namespace SitecoreInstaller
{
    public class WebsiteDir : DirPath
    {
        public WebsiteDir(DirPath fullPath) : base(fullPath.FullName)
        {
        }

        public DirPath AppData => Add(nameof(AppData));
        public AppConfigDir AppConfig => new AppConfigDir(Add(nameof(AppConfig)));
        public DirPath Temp => Add(nameof(Temp));
    }
}
