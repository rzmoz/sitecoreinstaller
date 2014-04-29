using System.IO;
using CSharp.Basics.IO;
using SitecoreInstaller.Framework.IOx;

namespace SitecoreInstaller.Domain
{
    public class IncludeFolder : Folder
    {
        private const string _wffmConfigFileName = "forms.config";

        //prefix with z to make sure they are evaluated last

        private const string _sitecoreSettingsConfigFile = "zSitecoreSettings.config";
        private const string _licenseConfigFileName = "zLicense.config";
        private const string _dataFolderConfigFileName = "zDataFolder.config";
        private const string _wffmSqlDataproviderConfigFileName = "zFormsSqlDataProvider.config";

        public IncludeFolder(DirectoryInfo directory)
            : base(directory)
        {
            SitecoreSettingsConfigFile = Directory.CombineTo<FileInfo>(_sitecoreSettingsConfigFile);
            DataFolderConfigFile = Directory.CombineTo<FileInfo>(_dataFolderConfigFileName);
            LicenseConfigFile = Directory.CombineTo<FileInfo>(_licenseConfigFileName);
            WffmConfigFile = Directory.CombineTo<FileInfo>(_wffmConfigFileName);
            WffmSqlDataproviderConfigFile = Directory.CombineTo<FileInfo>(_wffmSqlDataproviderConfigFileName);
        }
        public FileInfo SitecoreSettingsConfigFile { get; private set; }
        public FileInfo DataFolderConfigFile { get; private set; }
        public FileInfo LicenseConfigFile { get; private set; }
        public FileInfo WffmConfigFile { get; private set; }
        public FileInfo WffmSqlDataproviderConfigFile { get; private set; }
    }
}
