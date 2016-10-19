using DotNet.Basics.IO;

namespace SitecoreInstaller
{
    public class WebsiteDir : DirPath
    {
        public WebsiteDir(DirPath fullPath) : base(fullPath.FullName)
        {
        }

        public DirPath App_Data => Add(nameof(App_Data));
        public AppConfigDir App_Config => new AppConfigDir(Add(nameof(App_Config)));
        public DirPath Temp => Add(nameof(Temp).ToLowerInvariant());
    }
}
