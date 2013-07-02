using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain
{
    using System.IO;

    using SitecoreInstaller.Framework.IO;

    public class WebsiteFolder : Folder
    {
        private const string _AppConfigFolderName = "App_Config";
        private const string _TempFolderName = "Temp";

        public WebsiteFolder(DirectoryInfo directory)
            : base(directory)
        {
            AppConfig = new AppConfigFolder(Directory.CombineTo<DirectoryInfo>(_AppConfigFolderName));
            Temp = Directory.CombineTo<DirectoryInfo>(_TempFolderName);
        }

        public AppConfigFolder AppConfig { get; private set; }
        public DirectoryInfo Temp { get; private set; }
    }
}
