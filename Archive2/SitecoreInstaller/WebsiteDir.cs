using DotNet.Basics.IO;

namespace SitecoreInstaller
{
    public class WebsiteDir : DirPath
    {
        public WebsiteDir(DirPath fullPath) : base(fullPath.FullName)
        { }

        public AppDataDir App_Data => new AppDataDir(Add(nameof(App_Data)));
        public AppConfigDir App_Config => new AppConfigDir(Add(nameof(App_Config)));
        public TempDir Temp => new TempDir(Add(nameof(Temp).ToLowerInvariant()));
        public DirPath Bin => Add(nameof(Bin).ToLowerInvariant());
    }
}
