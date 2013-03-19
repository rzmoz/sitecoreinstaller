using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SitecoreInstaller.UI
{
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

    private void siButton1_Click(object sender, EventArgs e)
    {
      Services.ProjectSettings = GetProjectSettings();
      Services.Pipelines.Run<InstallPipeline>();
    }

    private void btnUninstall_Click(object sender, EventArgs e)
    {
      Services.ProjectSettings = GetProjectSettings();
      Services.Pipelines.Run<UninstallPipeline>();
    }
    void PipelineWorker_WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      Services.BuildLibrary.Update();
    }
    void PipelineWorker_PreconditionNotMet(object sender, GenericEventArgs<string> e)
    {
      this.CrossThreadSafe(() => Services.Dialogs.ModalDialog(MessageBoxIcon.Error, e.Arg, string.Empty));
    }

    private void siButton1_Click_1(object sender, EventArgs e)
    {
      Services.Pipelines.Run<NothingPipeline>();
    }
  }
}
