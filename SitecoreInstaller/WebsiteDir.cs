using DotNet.Basics.IO;

namespace SitecoreInstaller
{
    public class WebsiteDir : DirPath
    {
        public WebsiteDir(DirPath fullPath) : base(fullPath.FullName)
        {
        }

        public AppDataDir App_Data => new AppDataDir(Add(nameof(App_Data)));
        public AppConfigDir App_Config => new AppConfigDir(Add(nameof(App_Config)));
        public DirPath Temp => Add(nameof(Temp).ToLowerInvariant());
        public DirPath Bin => Add(nameof(Bin).ToLowerInvariant());
        public DirPath Bin_x64 => Add(nameof(Bin_x64).ToLowerInvariant());
    }
}
