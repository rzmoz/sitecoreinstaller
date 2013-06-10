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

    public MainSIUserControl ActiveSiControl { get; private set; }

    private void MainCtrl_Load(object sender, EventArgs e)
    {
      Services.Init();

      InitPipelineWorker();
      InitProjectSettings();

      InitUserPreferences();
      InitLog();
      InitMainSimple();
      InitMainDeveloper();
      ActiveSiControl = mainDeveloper1;
      ViewportStack.Show(ActiveSiControl);
    }

    private void InitUserPreferences()
    {
      ViewportStack.Register(userPreferences1);
    }

    private void InitMainSimple()
    {
      this.mainSimple1.Init();
    }

    private void InitMainDeveloper()
    {
      this.mainDeveloper1.Init();
      BuildLibrarySelectionsUpdated += mainDeveloper1.BuildLibrarySelectionsUpdated;
    }

    private void InitLog()
    {
      this.logViewer1.Init();
      ViewportStack.Register(logViewer1);
      this.showHideLogViewerButton1.Init(logViewer1);
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
        case Keys.D | Keys.Control | Keys.Shift:
          if (!Services.PipelineWorker.IsBusy())
          {
            ViewportStack.Hide(ActiveSiControl);
            if (ActiveSiControl == mainDeveloper1)
              ActiveSiControl = mainSimple1;
            else
              ActiveSiControl = mainDeveloper1;
            ViewportStack.Show(ActiveSiControl);
            return true;
          }
          break;
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
          ViewportStack.Show(userPreferences1);
          return true;
      }

      return ActiveSiControl.ProcessKeyPress(keyData);
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
