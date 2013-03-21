﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SitecoreInstaller.UI
{
  using System.Diagnostics;
  using SitecoreInstaller.App;
  using SitecoreInstaller.App.Pipelines;
  using SitecoreInstaller.App.Properties;
  using SitecoreInstaller.Domain;
  using SitecoreInstaller.Domain.WebServer;
  using SitecoreInstaller.Framework.System;
  using SitecoreInstaller.UI.Navigation;

  public partial class MainCtrl : UserControl
  {
    public MainCtrl()
    {
      InitializeComponent();
    }

    private void MainCtrl_Load(object sender, EventArgs e)
    {
      Services.Init();

      InitPipelineWorker();
      progressCtrl1.SendToBack();
      progressCtrl1.Hide();
      progressCtrl1.Dock = DockStyle.Fill;

      selectProjectName1.Init();
      selectSitecore1.Init();
      selectLicense1.Init();
      selectModules1.Init();

      selectProjectName1.FocusTextBox();
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      Services.ProjectSettings = GetProjectSettings();
      switch (keyData)
      {
        case Keys.N | Keys.Control | Keys.Shift:
          Services.Pipelines.Run<DoNothingPipeline>();
          break;
        case Keys.B | Keys.Control | Keys.Shift:
          Services.Pipelines.Run<InstallPipeline>();
          break;
        case Keys.U | Keys.Control | Keys.Shift:
          Services.Pipelines.Run<UninstallPipeline>();
          break;
        case Keys.R | Keys.Control | Keys.Shift:
          Services.BuildLibrary.Update();
          break;
        case Keys.O | Keys.Control | Keys.Shift:
          Services.Website.OpenSitecore(Services.ProjectSettings.Iis.Url, Services.ProjectSettings.ProjectFolder.Website.Directory);
          break;
        case Keys.O | Keys.Control | Keys.Alt:
          Process.Start(Services.ProjectSettings.ProjectFolder.Directory.FullName);
          break;
      }
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private void InitPipelineWorker()
    {
      Services.PipelineWorker.AllStepsExecuting += progressCtrl1.Starting;
      Services.PipelineWorker.AllStepsExecuted += progressCtrl1.Ended;
      Services.PipelineWorker.WorkerCompleted += PipelineWorker_WorkerCompleted;
      Services.PipelineWorker.PreconditionNotMet += PipelineWorker_PreconditionNotMet;
    }

    private ProjectSettings GetProjectSettings()
    {
      var projectSettings = new ProjectSettings();
      projectSettings.Init(UserSettings.Default);
      projectSettings.Iis = new IisSettings();
      projectSettings.InstallType = InstallType.Full;
      projectSettings.ProjectName = this.selectProjectName1.ProjectName;
      projectSettings.BuildLibrarySelections.SelectedSitecore = this.selectSitecore1.SelectedItem;
      projectSettings.BuildLibrarySelections.SelectedLicense = this.selectLicense1.SelectedItem;
      projectSettings.BuildLibrarySelections.SelectedModules = this.selectModules1.SelectedModules;
      return projectSettings;
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
