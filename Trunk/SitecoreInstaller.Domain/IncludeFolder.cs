using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain
{
    using System.IO;

    using SitecoreInstaller.Framework.IO;

    public class IncludeFolder : Folder
    {
        private const string _WffmConfigFileName = "forms.config";

        //prefix with z to make sure they are evaluated last
        private const string _LicenseConfigFileName = "zLicense.config";
        private const string _DataFolderConfigFileName = "zDataFolder.config";
        private const string _WffmSqlDataproviderConfigFileName = "zFormsSqlDataProvider.config";

        public IncludeFolder(DirectoryInfo directory)
            : base(directory)
        {
            DataFolderConfigFile = Directory.CombineTo<FileInfo>(_DataFolderConfigFileName);
            LicenseConfigFile = Directory.CombineTo<FileInfo>(_LicenseConfigFileName);
            WffmConfigFile = Directory.CombineTo<FileInfo>(_WffmConfigFileName);
            WffmSqlDataproviderConfigFile = Directory.CombineTo<FileInfo>(_WffmSqlDataproviderConfigFileName);
        }
        public FileInfo DataFolderConfigFile { get; private set; }
        public FileInfo LicenseConfigFile { get; private set; }
        public FileInfo WffmConfigFile { get; private set; }
        public FileInfo WffmSqlDataproviderConfigFile { get; private set; }
    }
}
