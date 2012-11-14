namespace SitecoreInstaller.UI.Developer
{
    using System;
    using System.Windows.Forms;

    using SitecoreInstaller.App;
    using SitecoreInstaller.App.Properties;
    using SitecoreInstaller.Domain;
    using SitecoreInstaller.Domain.WebServer;
    using SitecoreInstaller.Framework.System;

    public partial class SelectionsDeveloper : UserControl
    {
        private Func<IisSettings> _getIisSettings;
        private Func<InstallType> _getInstallType; 
        public SelectionsDeveloper()
        {
            InitializeComponent();
        }

        public void Init(Func<IisSettings> getIisSettings, Func<InstallType> getInstallType)
        {
            _getIisSettings = getIisSettings;
            _getInstallType = getInstallType;
            _selectProjectName1.Init();
            selectSitecore1.Init();
            selectLicense1.Init();
            selectModules1.Init();
        }

        public ProjectSettings GetProjectSettings()
        {
            var projectSettings = new ProjectSettings();
            projectSettings.Init(UserSettings.Default);
            projectSettings.Iis = _getIisSettings();//Get iis settings before project name is set!
            projectSettings.InstallType = _getInstallType();
            projectSettings.ProjectName = _selectProjectName1.ProjectName;
            projectSettings.BuildLibrarySelections.SelectedSitecore = selectSitecore1.SelectedItem;
            projectSettings.BuildLibrarySelections.SelectedLicense = selectLicense1.SelectedItem;
            projectSettings.BuildLibrarySelections.SelectedModules = selectModules1.SelectedModules;
            return projectSettings;
        }

        public void FocusProjectcName()
        {
            _selectProjectName1.FocusTextBox();
        }
    }
}
