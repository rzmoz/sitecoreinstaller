using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace SitecoreInstaller.UI
{
  using System.Linq;
  using SitecoreInstaller.App;
  using SitecoreInstaller.App.Pipelines;
  using SitecoreInstaller.Domain.BuildLibrary;
  using SitecoreInstaller.Framework.System;
  using SitecoreInstaller.UI.Viewport;

  public partial class MainCtrl : UserControl
  {
    public MainCtrl()
    {
      InitializeComponent();
    }

    private event EventHandler<GenericEventArgs<BuildLibrarySelections>> BuildLibrarySelectionsUpdated;

    private void MainCtrl_Load(object sender, EventArgs e)
    {
      Services.Init();

      InitPipelineWorker();
      InitProjectSettings();

      InitProgress();
      InitUserPreferences();
      InitLog();
      InitMainSimple();
      InitMainDeveloper();
      Services.UserPreferences.Load();
      ViewportStack.Show(mainDeveloper1);
    }

    private void InitProgress()
    {
      progressCtrl1.Init();
    }

    private void InitUserPreferences()
    {
      ViewportStack.Register(userPreferences1);
      userPreferences1.Init();
      this.showHideSettingsButton1.Init(userPreferences1, toolTip1);

    }

    private void InitMainSimple()
    {
      ViewportStack.Register(mainSimple1);
      this.mainSimple1.Init();
    }

    private void InitMainDeveloper()
    {
      ViewportStack.Register(mainDeveloper1);
      this.mainDeveloper1.Init();
      BuildLibrarySelectionsUpdated += mainDeveloper1.BuildLibrarySelectionsUpdated;
    }

    private void InitLog()
    {
      this.logViewer1.Init();
      ViewportStack.Register(logViewer1);
      this.showHideLogViewerButton1.Init(logViewer1, toolTip1);
    }

    public bool ProcessKeyPress(Keys keyData)
    {
      //can always run
      switch (keyData)
      {
        case Keys.L | Keys.Control | Keys.Shift:
          ViewportStack.OpenOrCloseDependingOnCurrentState(logViewer1);
          return true;
      }

      //can only run if we're not busy running a pipeline
      if (Services.PipelineWorker.IsBusy())
        return false;

      //we only handle keypress from here if pipeline is not busy
      switch (keyData)
      {
        case Keys.N | Keys.Control | Keys.Shift:
          Services.Pipelines.Run<DoNothingPipeline>();
          return true;
        case Keys.C | Keys.Control | Keys.Shift:
          Framework.Diagnostics.Log.This.Clear();
          return true;
        case Keys.R | Keys.Control:
          Services.BuildLibrary.Update();
          return true;
        case Keys.P | Keys.Control | Keys.Shift:
          ViewportStack.OpenOrCloseDependingOnCurrentState(userPreferences1);
          return true;
      }

      var activeMainCtrl = ViewportStack.ActiveCtrl;
      if (activeMainCtrl == null)
        return false;

      return activeMainCtrl.ProcessKeyPress(keyData);
    }

    private void InitProjectSettings()
    {
      Services.UserPreferences.Updated += UserPreferences_Updated;
      Services.ProjectSettings.Updated += ProjectSettings_Updated;

      Services.UserPreferences.Load();
    }

    void ProjectSettings_Updated(object sender, GenericEventArgs<string> e)
    {
      //load project settings if file exists or reset if it doesn't
      if (Services.ProjectSettings.ProjectFolder.ProjectSettingsConfigFile.Exists)
      {
        var projectConfig = Services.ProjectSettings.ProjectFolder.ProjectSettingsConfigFile;
        projectConfig.Load();
        Services.ProjectSettings.BuildLibrarySelections.SelectedSitecore = SourceEntry.ParseString(projectConfig.Properties.Sitecore);
        Services.ProjectSettings.BuildLibrarySelections.SelectedLicense = SourceEntry.ParseString(projectConfig.Properties.License);
        Services.ProjectSettings.BuildLibrarySelections.SelectedModules = projectConfig.Properties.Modules.Select(SourceEntry.ParseString);
      }
      else
      {
        Services.ProjectSettings.BuildLibrarySelections = new BuildLibrarySelections();
      }

      if (BuildLibrarySelectionsUpdated != null)
        BuildLibrarySelectionsUpdated(sender, new GenericEventArgs<BuildLibrarySelections>(Services.ProjectSettings.BuildLibrarySelections));
    }

    void UserPreferences_Updated(object sender, GenericEventArgs<UserPreferencesConfig> e)
    {
      Services.ProjectSettings.Init(e.Arg);
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
      this.CrossThreadSafe(() => Services.Dialogs.ModalDialog(MessageBoxIcon.Error, e.Arg, string.Empty));
    }
  }
}
