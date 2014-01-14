using System.IO;
using SitecoreInstaller.Framework.IO;

namespace SitecoreInstaller.Domain
{
    public class DataFolder : Folder
    {
        private const string _packagesFolderName = "Packages";
        private const string _auditFolderName = "Audit";
        private const string _viewstateFolderName = "Viewstate";
        private const string _logsFolderName = "Logs";
        private const string _licenseFileName = "license.xml";

        public DataFolder(DirectoryInfo dataFolder)
            : base(dataFolder)
        {
            Packages = Directory.CombineTo<DirectoryInfo>(_packagesFolderName);
            Audit = Directory.CombineTo<DirectoryInfo>(_auditFolderName);
            Logs = Directory.CombineTo<DirectoryInfo>(_logsFolderName);
            Viewstate = Directory.CombineTo<DirectoryInfo>(_viewstateFolderName);
            LicenseFile = Directory.CombineTo<FileInfo>(_licenseFileName);
        }

        public FileInfo LicenseFile { get; private set; }

        public DirectoryInfo Packages { get; private set; }
        public DirectoryInfo Audit { get; private set; }
        public DirectoryInfo Logs { get; private set; }
        public DirectoryInfo Viewstate { get; private set; }
    }
}
