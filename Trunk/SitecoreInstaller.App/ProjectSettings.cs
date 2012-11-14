namespace SitecoreInstaller.App
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
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
        private Observable<string> _projectName;

        public ProjectSettings()
        {
            _projectName = new Observable<string>();
            _projectName.PropertyUpdated += ProjectNamePropertyUpdated;
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


        public bool ProjectNameIsSet { get { return !string.IsNullOrEmpty(ProjectName); } }

        public string ProjectName
        {
            get { return _projectName.Value; }
            set { _projectName.Value = value; }
        }

        public InstallType InstallType { get; set; }

        public BuildLibrarySelections BuildLibrarySelections { get; set; }
        public SqlSettings Sql { get; set; }
        public IisSettings Iis { get; set; }
        public ProjectFolder ProjectFolder { get; set; }

        public IEnumerable<ConnectionStringName> DatabaseNames { get; set; }

        private void Reset()
        {
            _projectName.Reset();
            DatabaseNames = Enumerable.Empty<ConnectionStringName>();
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

            Iis.Name = ProjectName;
        }

        private void SetSystemPaths()
        {
            var projectfolder = new DirectoryInfo(UserSettings.Default.ProjectsFolder).CombineTo<DirectoryInfo>(ProjectName);
            ProjectFolder = new ProjectFolder(projectfolder, DataFolderMode.DataOutside);
            Iis.Url = ProjectName + UserSettings.Default.IisSitePostfix;
        }
    }
}
