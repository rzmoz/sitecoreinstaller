namespace SitecoreInstaller.App
{
    using System.IO;
    using System.Runtime.Serialization;

    using SitecoreInstaller.Domain.BuildLibrary;
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
    public class ProjectSettings
    {
        public ProjectSettings()
        {
            ProjectName = new Observable<string>();
            ProjectName.PropertyUpdated += ProjectNamePropertyUpdated;
            Reset();
        }

        public void Init(UserSettings userSettings)
        {
            ProjectFolder = new ProjectFolder(new DirectoryInfo(userSettings.ProjectsFolder), DataFolderMode.DataOutside);
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

        public InstallType InstallType { get; set; }

        public BuildLibrarySelections BuildLibrarySelections { get; set; }
        public SqlSettings Sql { get; set; }
        public IisSettings Iis { get; set; }
        public ProjectFolder ProjectFolder { get; set; }

        private void Reset()
        {
            ProjectName.Reset();
            InstallType = InstallType.Full;
            Iis = new IisSettings();
            ProjectFolder = new ProjectFolder(new DirectoryInfo(@"c:\"), DataFolderMode.DataOutside);
            BuildLibrarySelections = new BuildLibrarySelections();
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
            ProjectFolder = new ProjectFolder(projectfolder, DataFolderMode.DataOutside);
            Iis.Url = ProjectName + UserSettings.Default.IisSitePostfix;
            ConnectionStringsConfigFile = new ConnectionStringsFile(ProjectFolder.Website.AppConfig.CombineTo<FileInfo>(AppConstants.ConnectionStringsConfigFileName));
        }
    }
}
