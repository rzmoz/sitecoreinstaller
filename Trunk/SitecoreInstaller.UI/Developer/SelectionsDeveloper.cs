namespace SitecoreInstaller.UI.Developer
{
    using System;
    using System.Windows.Forms;

    using SitecoreInstaller.App;
    using SitecoreInstaller.App.Properties;
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

        public AppSettings GetAppSettings()
        {
            var appSettings = new AppSettings();
            appSettings.Init(UserSettings.Default);
            appSettings.Iis = _getIisSettings();//Get iis settings before project name is set!
            appSettings.InstallType = _getInstallType();
            appSettings.ProjectName.Value = _selectProjectName1.ProjectName;
            appSettings.BuildLibrarySelections.SelectedSitecore = selectSitecore1.SelectedItem;
            appSettings.BuildLibrarySelections.SelectedLicense = selectLicense1.SelectedItem;
            appSettings.BuildLibrarySelections.SelectedModules = selectModules1.SelectedModules;
            return appSettings;
        }

        public void FocusProjectcName()
        {
            _selectProjectName1.FocusTextBox();
        }
    }
}
