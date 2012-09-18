namespace SitecoreInstaller.App
{
    using System.IO;
    using System.Runtime.Serialization;

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
    [DataContract]
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
        

        public bool ProjectNameIsSet { get { return !string.IsNullOrEmpty(ProjectName.Value); } }

        public Observable<string> ProjectName { get; private set; }

        public ConnectionStringsFile ConnectionStringsConfigFile { get; set; }

        public FileInfo DataFolderConfigFile { get; private set; }
        public FileInfo LicenseConfigFile { get; private set; }
        public FileInfo WffmConfigFile { get; private set; }
        public FileInfo WffmSqlDataproviderConfigFile { get; private set; }

        public UserSelections UserSelections { get; set; }
        public SqlSettings Sql { get; set; }
        public IisSettings Iis { get; set; }
        public WebsiteFolders WebsiteFolders { get; set; }

        private void Reset()
        {
            ProjectName.Reset();
            Iis = new IisSettings();
            WebsiteFolders = new WebsiteFolders();
            UserSelections = new UserSelections();
            Sql = new SqlSettings();
        }

        private void ResolveDependentPaths()
        {
            if (ProjectNameIsSet)
                SetSystemPaths();
            else
                Iis.Url = string.Empty;

            Iis.Name = ProjectName.Value;
        }

        private void SetSystemPaths()
        {
            var projectfolder = new DirectoryInfo(UserSettings.Default.ProjectsFolder).CombineTo<DirectoryInfo>(ProjectName.Value);
            WebsiteFolders = new WebsiteFolders(projectfolder, DataFolderMode.DataOutside);
            Iis.Url = ProjectName + UserSettings.Default.IisSitePostfix;
            ConnectionStringsConfigFile =new ConnectionStringsFile(WebsiteFolders.ConfigFolder.CombineTo<FileInfo>(AppConstants.ConnectionStringsConfigFileName));
            DataFolderConfigFile = WebsiteFolders.ConfigIncludeFolder.CombineTo<FileInfo>(AppConstants.DataFolderConfigFileName);
            LicenseConfigFile = WebsiteFolders.ConfigIncludeFolder.CombineTo<FileInfo>(AppConstants.LicenseConfigFileName);
            WffmConfigFile = WebsiteFolders.ConfigIncludeFolder.CombineTo<FileInfo>(AppConstants.WffmConfigFileName);
            WffmSqlDataproviderConfigFile = WebsiteFolders.ConfigIncludeFolder.CombineTo<FileInfo>(AppConstants.WffmSqlDataproviderConfigFileName);
        }
    }
}
