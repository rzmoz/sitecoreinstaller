﻿namespace SitecoreInstaller.UI.Developer
{
    using System;
    using System.Windows.Forms;

    using SitecoreInstaller.App;
    using SitecoreInstaller.App.Properties;
    using SitecoreInstaller.Domain.WebServer;
    using SitecoreInstaller.Framework.System;

    public partial class SelectionsDeveloper : UserControl
    {
        private Func<IisSettings> _getAppPoolSettings;

        public SelectionsDeveloper()
        {
            InitializeComponent();
        }

        public void Init(Func<IisSettings> getAppPoolSettings)
        {
            _getAppPoolSettings = getAppPoolSettings;
            _selectProjectName1.Init();
            selectSitecore1.Init();
            selectLicense1.Init();
            selectModules1.Init();
        }

        public AppSettings GetAppSettings()
        {
            var appSettings = new AppSettings();
            appSettings.Init(UserSettings.Default);
            appSettings.Iis = _getAppPoolSettings();//Get app pool settings before project name is set!
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
