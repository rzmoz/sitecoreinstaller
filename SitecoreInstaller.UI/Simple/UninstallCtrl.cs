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

  public partial class UninstallCtrl : SIUserControl
  {
    public UninstallCtrl()
    {
      InitializeComponent();
    }

    public void Init()
    {
      selectProjectName1.DropDownStyle = ComboBoxStyle.DropDownList;
      selectProjectName1.Init();
    }

    public override void OnShow()
    {
      base.OnShow();
      selectProjectName1.UpdateList();
      selectProjectName1.Focus();
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
        case Keys.U | Keys.Control | Keys.Shift:
          this.btnUninstall_Click(this, new EventArgs());
          return true;
      }
      return false;
    }

    private void btnBack_Click(object sender, EventArgs e)
    {
      ViewportStack.Hide(this);
    }

    private void btnUninstall_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(selectProjectName1.ProjectName))
      {
        Services.Dialogs.Information("Please select a project");
        return;
      }
      Services.Pipelines.Run<UninstallPipeline>(UiServices.ProjectSettings);
      ViewportStack.Hide(this);
    }
  }
}
