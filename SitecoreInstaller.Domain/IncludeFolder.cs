using System.IO;
using SitecoreInstaller.Framework.IO;

namespace SitecoreInstaller.Domain
{
    public class IncludeFolder : Folder
    {
        private const string _wffmConfigFileName = "forms.config";

        //prefix with z to make sure they are evaluated last
        private const string _licenseConfigFileName = "zLicense.config";
        private const string _dataFolderConfigFileName = "zDataFolder.config";
        private const string _wffmSqlDataproviderConfigFileName = "zFormsSqlDataProvider.config";

        public IncludeFolder(DirectoryInfo directory)
            : base(directory)
        {
            DataFolderConfigFile = Directory.CombineTo<FileInfo>(_dataFolderConfigFileName);
            LicenseConfigFile = Directory.CombineTo<FileInfo>(_licenseConfigFileName);
            WffmConfigFile = Directory.CombineTo<FileInfo>(_wffmConfigFileName);
            WffmSqlDataproviderConfigFile = Directory.CombineTo<FileInfo>(_wffmSqlDataproviderConfigFileName);
        }
        public FileInfo DataFolderConfigFile { get; private set; }
        public FileInfo LicenseConfigFile { get; private set; }
        public FileInfo WffmConfigFile { get; private set; }
        public FileInfo WffmSqlDataproviderConfigFile { get; private set; }
    }
}
