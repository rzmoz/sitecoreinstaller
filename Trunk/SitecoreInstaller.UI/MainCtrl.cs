using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace SitecoreInstaller.UI
{
  using System.Diagnostics;
  using System.Linq;
  using SitecoreInstaller.App;
  using SitecoreInstaller.App.Pipelines;
  using SitecoreInstaller.Domain.BuildLibrary;
  using SitecoreInstaller.Domain.Pipelines;
  using SitecoreInstaller.Framework.System;

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
      progressCtrl1.SendToBack();
      progressCtrl1.Hide();
      progressCtrl1.Dock = DockStyle.Fill;

      selectProjectName1.Init();
      selectSitecore1.Init();
      selectLicense1.Init();
      selectModules1.Init();

      selectProjectName1.FocusTextBox();
    }

    private void InitProjectSettings()
    {
      Services.UserPreferences.Updated += UserPreferences_Updated;
      Services.ProjectSettings.Updated += ProjectSettings_Updated;
      BuildLibrarySelectionsUpdated += selectSitecore1.BuildLibrarySelectionsUpdated;
      BuildLibrarySelectionsUpdated += selectLicense1.BuildLibrarySelectionsUpdated;
      BuildLibrarySelectionsUpdated += selectModules1.BuildLibrarySelectionsUpdated;
      Services.UserPreferences.Load();
    }

    void ProjectSettings_Updated(object sender, GenericEventArgs<string> e)
    {
      //load project settings if file exist or reset if it doesn't
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

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      switch (keyData)
      {
        case Keys.N | Keys.Control | Keys.Shift:
          Services.Pipelines.Run<DoNothingPipeline>();
          break;
        case Keys.B | Keys.Control | Keys.Shift:
          this.UpdateBuildLibrarySelections();
          Services.Pipelines.Run<InstallPipeline>();
          break;
        case Keys.U | Keys.Control | Keys.Shift:
          Services.Pipelines.Run<UninstallPipeline>();
          break;
        case Keys.R | Keys.Control | Keys.Shift:
          this.UpdateBuildLibrarySelections();
          Services.Pipelines.Run<ReinstallPipeline>(Dialogs.Off);
          break;
        case Keys.R | Keys.Control:
          Services.BuildLibrary.Update();
          break;
        case Keys.O | Keys.Control:
          Services.Website.OpenFrontend(Services.ProjectSettings.Iis.Url);
          break;
        case Keys.O | Keys.Control | Keys.Shift:
          Services.Website.OpenSitecore(Services.ProjectSettings.Iis.Url, Services.ProjectSettings.ProjectFolder.Website.Directory);
          break;
        case Keys.O | Keys.Control | Keys.Alt:
          Process.Start(Services.ProjectSettings.ProjectFolder.Directory.FullName);
          break;
        default:
          return base.ProcessCmdKey(ref msg, keyData);
      }
      return true;
    }

    private void UpdateBuildLibrarySelections()
    {
      Services.ProjectSettings.BuildLibrarySelections.SelectedSitecore = this.selectSitecore1.SelectedItem;
      Services.ProjectSettings.BuildLibrarySelections.SelectedLicense = this.selectLicense1.SelectedItem;
      Services.ProjectSettings.BuildLibrarySelections.SelectedModules = this.selectModules1.SelectedModules;
    }

    private void InitPipelineWorker()
    {
      Services.PipelineWorker.AllStepsExecuting += progressCtrl1.Starting;
      Services.PipelineWorker.AllStepsExecuted += progressCtrl1.Ended;
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
