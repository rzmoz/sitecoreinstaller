using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SitecoreInstaller.Framework.IO;

namespace SitecoreInstaller.Domain.Website
{
    using System.Diagnostics.Contracts;
    using System.Threading.Tasks;

    public class WebsiteFolders
    {
        internal const string AppDataFolderName = "App_Data";
        internal const string DatabasesFolderName = "Databases";
        internal const string DataFolderName = "Data";
        internal const string WebsiteFolderName = "Website";
        internal const string ConfigFolderName = "App_Config";
        internal const string ConfigIncludeFolderName = "Include";
        internal const string PackagesFolderName = "Packages";
        internal const string IisLogFilesFolderName = "IisLogFiles";

        public WebsiteFolders()
        {
        }

        public WebsiteFolders(DirectoryInfo projectFolder, DataFolderMode dataFolderMode)
            : this()
        {
            Contract.Requires<ArgumentNullException>(projectFolder != null);

            ProjectFolder = projectFolder;
            DataFolderMode = dataFolderMode;
            ResolvePaths();
        }

        public DirectoryInfo ProjectFolder { get; private set; }
        public DirectoryInfo IisLogFilesFolder { get; private set; }
        public DirectoryInfo DataFolder { get; private set; }
        public DirectoryInfo PackagesFolder { get; private set; }
        public DirectoryInfo DatabaseFolder { get; private set; }
        public DirectoryInfo WebSiteFolder { get; private set; }
        public DirectoryInfo ConfigFolder { get; private set; }
        public DirectoryInfo ConfigIncludeFolder { get; private set; }

        public DataFolderMode DataFolderMode { get; private set; }

        private void ResolvePaths()
        {
            WebSiteFolder = ProjectFolder.CombineTo<DirectoryInfo>(WebsiteFolderName);
            DatabaseFolder = ProjectFolder.CombineTo<DirectoryInfo>(DatabasesFolderName);
            IisLogFilesFolder = ProjectFolder.CombineTo<DirectoryInfo>(IisLogFilesFolderName);
            ConfigFolder = ProjectFolder.CombineTo<DirectoryInfo>(WebsiteFolderName, ConfigFolderName);
            ConfigIncludeFolder = ConfigFolder.CombineTo<DirectoryInfo>(ConfigIncludeFolderName);
            switch (DataFolderMode)
            {
                case DataFolderMode.AppDataInside:
                    DataFolder = ProjectFolder.CombineTo<DirectoryInfo>(WebsiteFolderName, AppDataFolderName);
                    break;
                case DataFolderMode.DataOutside:
                default:
                    DataFolder = ProjectFolder.CombineTo<DirectoryInfo>(DataFolderName);
                    break;
            }
            PackagesFolder = DataFolder.CombineTo<DirectoryInfo>(PackagesFolderName);
        }
    }
}
