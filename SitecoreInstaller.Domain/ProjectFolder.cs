using System.IO;
using SitecoreInstaller.Domain.Projects;
using SitecoreInstaller.Framework.Configuration;
using SitecoreInstaller.Framework.IO;

namespace SitecoreInstaller.Domain
{
    public class ProjectFolder : Folder
    {
        private const string _projectSettingsConfigFileName = "ProjectSettings.config";

        private const string _dataFolderName = "Data";

        private const string _databasesFolderName = "Databases";
        private const string _websiteFolderName = "Website";
        private const string _iisLogFilesFolderName = "IisLogFiles";

        public ProjectFolder(DirectoryInfo directory)
            : base(directory)
        {
            Website = new WebsiteFolder(Directory.CombineTo<DirectoryInfo>(_websiteFolderName));
            Databases = Directory.CombineTo<DirectoryInfo>(_databasesFolderName);
            IisLogFiles = Directory.CombineTo<DirectoryInfo>(_iisLogFilesFolderName);
            ProjectSettingsConfigFile = new ConfigFile<ProjectSettingsConfig>(Directory.CombineTo<FileInfo>(_projectSettingsConfigFileName));
            Data = new DataFolder(Directory.CombineTo<DirectoryInfo>(_dataFolderName));
        }

        public DataFolder Data { get; private set; }
        public DirectoryInfo Databases { get; private set; }
        public WebsiteFolder Website { get; private set; }
        public DirectoryInfo IisLogFiles { get; private set; }
        public ConfigFile<ProjectSettingsConfig> ProjectSettingsConfigFile { get; private set; }
    }
}
