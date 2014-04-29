using System.IO;
using CSharp.Basics.IO;
using SitecoreInstaller.Framework.IOx;

namespace SitecoreInstaller.Domain
{
    public class WebsiteFolder : Folder
    {
        private const string _appConfigFolderName = "App_Config";
        private const string _tempFolderName = "Temp";

        public WebsiteFolder(DirectoryInfo directory)
            : base(directory)
        {
            AppConfig = new AppConfigFolder(Directory.CombineTo<DirectoryInfo>(_appConfigFolderName));
            Temp = Directory.CombineTo<DirectoryInfo>(_tempFolderName);
        }

        public AppConfigFolder AppConfig { get; private set; }
        public DirectoryInfo Temp { get; private set; }
    }
}
