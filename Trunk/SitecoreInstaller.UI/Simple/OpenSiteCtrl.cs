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
  using SitecoreInstaller.UI.Viewport;

  public partial class OpenSiteCtrl : SIUserControl
  {
    public OpenSiteCtrl()
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
    }


    private void btnBack_Click(object sender, EventArgs e)
    {
      ViewportStack.Hide(this);
    }

    private void btnOpenSite_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(selectProjectName1.ProjectName))
        return;

      Services.Website.OpenFrontend(Services.ProjectSettings.Iis.Url);
    }
  }
}
