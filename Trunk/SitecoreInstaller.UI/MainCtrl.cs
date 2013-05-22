﻿using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace SitecoreInstaller.UI
{
  using System.Linq;
  using SitecoreInstaller.App;
  using SitecoreInstaller.App.Pipelines;
  using SitecoreInstaller.Domain.BuildLibrary;
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

      ViewportStack.Close(progressCtrl1);

      progressCtrl1.Dock = DockStyle.Fill;
      InitLog();
      mainDeveloper1.Init();
    }

    private void InitLog()
    {
      this.logViewer1.Init();
      Services.PipelineWorker.AllStepsExecuting += PipelineWorker_AllStepsExecuting;
      Services.PipelineWorker.AllStepsExecuted += PipelineWorker_AllStepsExecuted;
      btnViewLog.FlatAppearance.BorderSize = 0;
    }

    void PipelineWorker_AllStepsExecuted(object sender, Domain.Pipelines.PipelineEventArgs e)
    {
      btnViewLog.Image = Properties.Resources.Log;
    }

    void PipelineWorker_AllStepsExecuting(object sender, Domain.Pipelines.PipelineEventArgs e)
    {
      btnViewLog.Image = Properties.Resources.Log_active;
    }

    public bool ProcessKeyPress(Keys keyData)
    {
      switch (keyData)
      {
        case Keys.N | Keys.Control | Keys.Shift:
          Services.Pipelines.Run<DoNothingPipeline>();
          return true;
        case Keys.L | Keys.Control | Keys.Shift:
          ViewportStack.OpenCloseDependingOnCurrentState(logViewer1);
          return true;
        case Keys.R | Keys.Control:
          Services.BuildLibrary.Update();
          return true;
      }

      return mainDeveloper1.ProcessKeyPress(keyData);
    }

    private void InitProjectSettings()
    {
      Services.UserPreferences.Updated += UserPreferences_Updated;
      Services.ProjectSettings.Updated += ProjectSettings_Updated;
      BuildLibrarySelectionsUpdated += mainDeveloper1.BuildLibrarySelectionsUpdated;
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

    private void btnViewLog_Click(object sender, EventArgs e)
    {
      ViewportStack.OpenCloseDependingOnCurrentState(logViewer1);
    }
  }
}
