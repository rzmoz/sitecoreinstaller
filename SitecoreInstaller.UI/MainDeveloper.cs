using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CSharp.Basics.Forms.Viewport;
using CSharp.Basics.Sys;
using SitecoreInstaller.App;
using SitecoreInstaller.App.Pipelines;
using SitecoreInstaller.App.Pipelines.Steps.Install;
using SitecoreInstaller.Domain.BuildLibrary;
using SitecoreInstaller.Framework.Sys;
using SitecoreInstaller.UI.Viewport;

namespace SitecoreInstaller.UI
{
    public partial class MainDeveloper : BasicsUserControl
    {
        public MainDeveloper()
        {
            InitializeComponent();
        }

        public void Init()
        {
            selectProjectName1.ProjectNameChanged += selectProjectName1_ProjectNameChanged;

            selectProjectName1.Init();
            selectProjectName1_ProjectNameChanged(null, selectProjectName1.ProjectName);
            selectSitecore1.Init();
            selectLicense1.Init();
            selectModules1.Init();
            selectClientInstall1.Init();
            mainDeveloperButtons1.Init();
        }

        void selectProjectName1_ProjectNameChanged(object sender, string projectName)
        {
            mainDeveloperButtons1.Enabled = !string.IsNullOrEmpty(projectName);
        }

        public void ProjectSettingsUpdated(object sender, GenericEventArgs<ProjectSettings> e)
        {
            selectSitecore1.BuildLibrarySelectionsUpdated(sender, e);
            selectLicense1.BuildLibrarySelectionsUpdated(sender, e);
            selectModules1.BuildLibrarySelectionsUpdated(sender, e);
        }

        public override void OnShow()
        {
            base.OnShow();
            selectProjectName1.UpdateList();
            selectProjectName1.FocusTextBox();
            ParentForm.Height = Styles.MainForm.HeightDeveloper;
            Services.UserPreferences.Properties.AdvancedView = true;
            Services.UserPreferences.Save();
        }

        public override bool ProcessKeyPress(Keys keyData)
        {
            //we only activate key board shortcuts, if we're visible
            if (UiServices.ViewportStack.IsVisible(this) == false)
                return false;

            switch (keyData)
            {
                case Keys.L | Keys.Control | Keys.Alt:
                    Services.Website.OpenLogsInBareTail(UiServices.ProjectSettings.ProjectFolder.Data.Logs);
                    return true;
                case Keys.L | Keys.Control | Keys.Shift:
                    UpdateProjectSettings();
                    Services.Pipelines.Run<UpdateLicenseFilePipeline, PipelineApplicationEventArgs>(UiServices.ProjectSettings);
                    return true;
                case Keys.D | Keys.Control | Keys.Shift:
                    selectProjectName1.ProjectName = string.Empty;
                    UiServices.ViewportStack.Show("SitecoreInstaller.UI.MainSimple");
                    return true;
                case Keys.C | Keys.Control:
                    selectProjectName1.ProjectName = string.Empty;
                    selectClientInstall1.Clear();
                    ProjectSettingsUpdated(this, new GenericEventArgs<ProjectSettings>(new ProjectSettings()));
                    return true;
                case Keys.B | Keys.Control | Keys.Shift:
                    if (selectProjectName1.ProjectName.Length == 0)
                    {
                        UiServices.Dialogs.Information("Please enter project name");
                        return true;
                    }
                    UpdateProjectSettings();
                    Services.Pipelines.Run<InstallPipeline, PipelineApplicationEventArgs>(UiServices.ProjectSettings);
                    return true;
                case Keys.P | Keys.Control | Keys.Shift:
                    Services.Pipelines.Run<PublishPipeline, PipelineApplicationEventArgs>(UiServices.ProjectSettings, UiServices.Dialogs.MakeFullPublishDialog);
                    return true;
                case Keys.R | Keys.Control | Keys.Alt:
                    Services.Pipelines.Run<RecycleApplicationPipeline, PipelineApplicationEventArgs>(UiServices.ProjectSettings);
                    return true;
                case Keys.U | Keys.Control | Keys.Shift:
                    Services.Pipelines.Run<UninstallPipeline, CleanupEventArgs>(UiServices.ProjectSettings, UiServices.Dialogs.DeleteProjectDialog);
                    return true;
                case Keys.R | Keys.Control | Keys.Shift:
                    //we make sure the install type is not changed on reinstall! That would mess things up
                    var sqlInstallType = UiServices.ProjectSettings.Sql.InstallType;
                    var mongoInstallType = UiServices.ProjectSettings.Mongo.InstallType;
                    UpdateProjectSettings();
                    UiServices.ProjectSettings.Sql.InstallType = sqlInstallType;
                    UiServices.ProjectSettings.Mongo.InstallType = mongoInstallType;
                    Services.Pipelines.Run<ReinstallPipeline, CleanupEventArgs>(UiServices.ProjectSettings);
                    return true;
                case Keys.A | Keys.Control | Keys.Shift:
                    UpdateProjectSettings();
                    Services.Pipelines.Run<ArchivePipeline, ArchiveEventArgs>(UiServices.ProjectSettings, UiServices.Dialogs.SetArchiveName);
                    return true;
                case Keys.O | Keys.Control:
                    Services.Website.OpenFrontend(UiServices.ProjectSettings.Iis.Url);
                    return true;
                case Keys.O | Keys.Control | Keys.Shift:
                    Services.Website.OpenSitecore(UiServices.ProjectSettings.Iis.Url, UiServices.ProjectSettings.ProjectFolder.Website.Directory);
                    return true;
                case Keys.O | Keys.Control | Keys.Alt:
                    try
                    {
                        Process.Start(UiServices.ProjectSettings.ProjectFolder.Directory.FullName);
                    }
                    catch (Win32Exception)
                    {
                        UiServices.Dialogs.Information("Folder doesn't exist: '{0}'", UiServices.ProjectSettings.ProjectFolder.Directory.FullName);
                    }

                    return true;
            }
            return false;
        }

        private void UpdateProjectSettings()
        {
            UiServices.ProjectSettings.BuildLibrarySelections.SelectedSitecore = selectSitecore1.SelectedItem;
            UiServices.ProjectSettings.BuildLibrarySelections.SelectedLicense = selectLicense1.SelectedItem;
            UiServices.ProjectSettings.BuildLibrarySelections.SelectedModules = selectModules1.SelectedModules;
            UiServices.ProjectSettings.Sql.InstallType = selectClientInstall1.SqlInstallType;
            UiServices.ProjectSettings.Mongo.InstallType = selectClientInstall1.MongoInstallType;
        }
    }
}

