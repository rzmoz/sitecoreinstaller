namespace SitecoreInstaller.App
{
    using System.IO;

    using SitecoreInstaller.Domain.Database;
    using SitecoreInstaller.Domain.WebServer;
    using SitecoreInstaller.Domain.Website;
    using SitecoreInstaller.Framework.IO;
    using SitecoreInstaller.App.Properties;
    using SitecoreInstaller.Domain;
    using SitecoreInstaller.Framework.System;

    /// <summary>
    /// Not thread safe!
    /// </summary>
    public class AppSettings
    {
        public AppSettings()
        {
            ProjectName = new Observable<string>();
            ProjectName.PropertyUpdated += ProjectNamePropertyUpdated;
            Reset();
        }

        public void Init(UserSettings userSettings)
        {
            WebsiteFolders = new WebsiteFolders(new DirectoryInfo(userSettings.ProjectsFolder), DataFolderMode.DataOutside);
            Sql.InstanceName = userSettings.SqlInstanceName;
            Sql.Login = userSettings.SqlLogin;
            Sql.Password = userSettings.SqlPassword;
        }

        void ProjectNamePropertyUpdated(object sender, GenericEventArgs<string> e)
        {
            ResolveDependentPaths();
        }

        private void Reset()
        {
            ProjectName.Reset();
            AppPool = new AppPoolSettings();
            WebsiteFolders = new WebsiteFolders();
            UserSelections = new UserSelections();
            Sql = new SqlSettings();
        }

        public bool ProjectNameIsSet { get { return !string.IsNullOrEmpty(ProjectName.Value); } }

        public Observable<string> ProjectName { get; set; }

        private void ResolveDependentPaths()
        {
            if (ProjectNameIsSet)
                SetSystemPaths();
            else
                IisSiteName = string.Empty;

            AppPool.Name = IisSiteName;
        }

        private string _iisSiteName;
        public string IisSiteName
        {
            get { return _iisSiteName; }
            set { _iisSiteName = value.ToLowerInvariant(); }
        }

        public FileInfo ConnectionStringsConfigFile { get; set; }

        public FileInfo DataFolderConfigFile { get; private set; }
        public FileInfo LicenseConfigFile { get; private set; }
        public FileInfo WffmConfigFile { get; private set; }
        public FileInfo WffmSqlDataproviderConfigFile { get; private set; }

        public UserSelections UserSelections { get; set; }
        public SqlSettings Sql { get; set; }
        public AppPoolSettings AppPool { get; set; }
        public WebsiteFolders WebsiteFolders { get; set; }

        public FileInfo AttachScriptPath
        {
            get { return GetScriptPath(SqlConstants.AttachScriptName); }
        }

        public FileInfo MapLoginScriptPath
        {
            get { return GetScriptPath(SqlConstants.MapLoginScriptName); }
        }

        public FileInfo DetachScriptPath
        {
            get { return GetScriptPath(SqlConstants.DetachScriptName); }
        }

        private FileInfo GetScriptPath(string scriptFileName)
        {
            return WebsiteFolders.ProjectFolder.CombineTo<FileInfo>(ProjectName + scriptFileName);
        }

        private void SetSystemPaths()
        {
            var projectfolder = new DirectoryInfo(UserSettings.Default.ProjectsFolder).CombineTo<DirectoryInfo>(ProjectName.Value);
            WebsiteFolders = new WebsiteFolders(projectfolder, DataFolderMode.DataOutside);
            IisSiteName = ProjectName + UserSettings.Default.IisSitePostfix;
            ConnectionStringsConfigFile = WebsiteFolders.ConfigFolder.CombineTo<FileInfo>(ApplicationConstants.ConnectionStringsConfigFileName);
            DataFolderConfigFile = WebsiteFolders.ConfigIncludeFolder.CombineTo<FileInfo>(ApplicationConstants.DataFolderConfigFileName);
            LicenseConfigFile = WebsiteFolders.ConfigIncludeFolder.CombineTo<FileInfo>(ApplicationConstants.LicenseConfigFileName);
            WffmConfigFile = WebsiteFolders.ConfigIncludeFolder.CombineTo<FileInfo>(ApplicationConstants.WffmConfigFileName);
            WffmSqlDataproviderConfigFile = WebsiteFolders.ConfigIncludeFolder.CombineTo<FileInfo>(ApplicationConstants.WffmSqlDataproviderConfigFileName);
        }
    }
}
