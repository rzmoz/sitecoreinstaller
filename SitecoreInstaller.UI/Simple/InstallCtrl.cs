using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SitecoreInstaller.UI.Simple
{
  using SitecoreInstaller.App;
  using SitecoreInstaller.App.Pipelines;
  using SitecoreInstaller.UI.Viewport;

  public partial class InstallCtrl : SIUserControl
  {
    public InstallCtrl()
    {
      InitializeComponent();
    }

    public void Init()
    {
      selectSitecore1.Init();
      selectLicense1.Init();
    }

    public override void OnShow()
    {
      tbxProjectName.Text = string.Empty;
      tbxProjectName.Focus();
    }

    public override bool ProcessKeyPress(Keys keyData)
    {
      //we only activate key board shortcuts, if we're visible
      if (ViewportStack.IsVisible(this) == false)
        return false;

      switch (keyData)
      {
        case Keys.Escape:
          this.btnBack_Click(this, new EventArgs());
          return true;
        case Keys.B | Keys.Control | Keys.Shift:
          this.btnInstall_Click(this, new EventArgs());
          return true;
      }
      return false;
    }


    private void btnBack_Click(object sender, EventArgs e)
    {
      ViewportStack.Hide(this);
    }

    private void btnInstall_Click(object sender, EventArgs e)
    {
      var projectName = tbxProjectName.Text;

      if (string.IsNullOrEmpty(tbxProjectName.Text))
      {
        UiServices.Dialogs.Information("Please enter project name");
        return;
      }

      if (Services.Projects.GetExistingProjects().Any(p => p.Name.ToLower() == projectName.ToLower()))
      {
        UiServices.Dialogs.Information("Project '{0}' already exists.", projectName);
        return;
      }

      UiServices.ProjectSettings.ProjectName = tbxProjectName.Text;
      UiServices.ProjectSettings.BuildLibrarySelections.SelectedSitecore = this.selectSitecore1.SelectedItem;
      UiServices.ProjectSettings.BuildLibrarySelections.SelectedLicense = this.selectLicense1.SelectedItem;
      Services.Pipelines.Run<InstallPipeline, PipelineEventArgs>(UiServices.ProjectSettings);
      ViewportStack.Hide(this);
    }
  }
}
