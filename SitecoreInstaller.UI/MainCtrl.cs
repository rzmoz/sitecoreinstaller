using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CSharp.Basics.Forms;
using CSharp.Basics.Sys;
using SitecoreInstaller.App;
using SitecoreInstaller.App.Pipelines;
using SitecoreInstaller.App.Pipelines.Steps.Nothing;
using SitecoreInstaller.Domain;
using SitecoreInstaller.Domain.BuildLibrary;
using SitecoreInstaller.Framework.Sys;
using SitecoreInstaller.Framework.Web;
using SitecoreInstaller.UI.Viewport;

namespace SitecoreInstaller.UI
{
    public partial class MainCtrl : UserControl
    {
        public MainCtrl()
        {
            InitializeComponent();
        }

        private event EventHandler<GenericEventArgs<ProjectSettings>> ProjectSettingsUpdated;

        public void ShowUserPreferences(bool gotoLicenses = false)
        {
            UiServices.ViewportStack.Show(userPreferences1);
            if(gotoLicenses)
                userPreferences1.Navigate("/licenses");
        }

        public void Init()
        {
            InitPipelineWorker();
            InitProjectSettings();

            InitProgress();
            InitUserPreferences();
            InitSdnLogin();
            InitLog();
            InitMainSimple();
            InitMainDeveloper();
            Services.UserPreferences.Load();

            if (Services.UserPreferences.Properties.AdvancedView)
                UiServices.ViewportStack.Show(mainDeveloper1);
            else
                UiServices.ViewportStack.Show(mainSimple1);
        }

        private void InitSdnLogin()
        {
            UiServices.ViewportStack.Register(sdnLogin1);
            sdnLogin1.Init();
            btnSdn.Init(sdnLogin1, toolTip1);
        }

        private void InitProgress()
        {
            progressCtrl1.Init();
        }

        private void InitUserPreferences()
        {
            UiServices.ViewportStack.Register(userPreferences1);
            userPreferences1.Init();
            showHideSettingsButton1.Init(userPreferences1, toolTip1);
        }

        private void InitMainSimple()
        {
            UiServices.ViewportStack.Register(mainSimple1);
            mainSimple1.Init();
        }

        private void InitMainDeveloper()
        {
            UiServices.ViewportStack.Register(mainDeveloper1);

            mainDeveloper1.Init();
            ProjectSettingsUpdated += mainDeveloper1.ProjectSettingsUpdated;
        }

        private void InitLog()
        {
            logViewer1.Init();
            UiServices.ViewportStack.Register(logViewer1);
            showHideLogViewerButton1.Init(logViewer1, toolTip1);
        }

        public bool ProcessKeyPress(Keys keyData)
        {
            //can always run
            switch (keyData)
            {
                case Keys.L | Keys.Control | Keys.Shift:
                    UiServices.ViewportStack.OpenOrCloseDependingOnCurrentState(logViewer1);
                    return true;
            }

            //can only run if we're not busy running a pipeline
            if (Services.PipelineWorker.IsBusy())
                return false;

            //we only handle keypress from here if pipeline is not busy
            switch (keyData)
            {
                case Keys.N | Keys.Control | Keys.Shift:
                    Services.Pipelines.Run<DoNothingPipeline, DoNothingEventArgs>(UiServices.ProjectSettings);
                    return true;
                case Keys.C | Keys.Control | Keys.Shift:
                    Framework.Diagnostics.Log.ToApp.Reset();
                    return true;
                case Keys.R | Keys.Control:
                    Services.BuildLibrary.Update();
                    return true;
                case Keys.P | Keys.Alt | Keys.Shift:
                    UiServices.ViewportStack.OpenOrCloseDependingOnCurrentState(userPreferences1);
                    return true;
            }

            var activeMainCtrl = UiServices.ViewportStack.ActiveCtrl;
            if (activeMainCtrl == null)
                return false;

            return activeMainCtrl.ProcessKeyPress(keyData);
        }

        private void InitProjectSettings()
        {
            Services.UserPreferences.Updated += UserPreferences_Updated;
            UiServices.ProjectSettings.Updated += ProjectSettings_Updated;

            Services.UserPreferences.Load();
        }

        void ProjectSettings_Updated(object sender, GenericEventArgs<string> e)
        {
            //load project settings if file exists or reset if it doesn't
            if (UiServices.ProjectSettings.ProjectFolder.ProjectSettingsConfigFile.FileExists)
            {
                var projectConfig = UiServices.ProjectSettings.ProjectFolder.ProjectSettingsConfigFile;
                projectConfig.Load();
                UiServices.ProjectSettings.BuildLibrarySelections.SelectedSitecore = SourceEntry.ParseString(projectConfig.Properties.Sitecore);
                UiServices.ProjectSettings.BuildLibrarySelections.SelectedLicense = SourceEntry.ParseString(projectConfig.Properties.License);
                UiServices.ProjectSettings.BuildLibrarySelections.SelectedModules = projectConfig.Properties.Modules.Select(SourceEntry.ParseString);
                UiServices.ProjectSettings.Sql.InstallType = projectConfig.Properties.SqlInstallType;
                UiServices.ProjectSettings.Mongo.InstallType = projectConfig.Properties.MongoInstallType;

                if (ProjectSettingsUpdated != null)
                    ProjectSettingsUpdated(sender, new GenericEventArgs<ProjectSettings>(UiServices.ProjectSettings));
            }
            else
            {
                UiServices.ProjectSettings.BuildLibrarySelections = new BuildLibrarySelections();
                UiServices.ProjectSettings.Sql.InstallType = DbInstallType.Local;
                UiServices.ProjectSettings.Mongo.InstallType = DbInstallType.Local;
            }
        }

        void UserPreferences_Updated(object sender, GenericEventArgs<UserPreferencesConfig> e)
        {
            UiServices.ProjectSettings.Init(e.Arg);
        }

        private void InitPipelineWorker()
        {
            Services.PipelineWorker.AllStepsExecuting += progressCtrl1.Starting;
            Services.PipelineWorker.WorkerCompleted += progressCtrl1.Ended;
            Services.PipelineWorker.WorkerCompleted += PipelineWorker_WorkerCompleted;
            Services.PipelineWorker.PreconditionNotMet += PipelineWorker_PreconditionNotMet;
        }

        void PipelineWorker_WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Services.BuildLibrary.Update();
        }
        void PipelineWorker_PreconditionNotMet(object sender, GenericEventArgs<string> e)
        {
            this.CrossThreadSafe(() => UiServices.Dialogs.ModalDialog(DialogIcons.Error, e.Arg, string.Empty));
        }
    }
}
