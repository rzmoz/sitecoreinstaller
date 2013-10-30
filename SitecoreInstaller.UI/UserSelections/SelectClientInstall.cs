using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SitecoreInstaller.App;
using SitecoreInstaller.Domain;

namespace SitecoreInstaller.UI.UserSelections
{
  public partial class SelectClientInstall : UserControl
  {
    public SelectClientInstall()
    {
      InitializeComponent();
      toolTip1.SetToolTip(chkClientInstall, "Database actions are ignored. ConnectionStrings must be set with connection strings deltas");
    }

    public void Init()
    {
      UiServices.ProjectSettings.Updated += ProjectSettings_Updated;
    }

    void ProjectSettings_Updated(object sender, Framework.Sys.GenericEventArgs<string> e)
    {
      switch (UiServices.ProjectSettings.InstallType)
      {
        case InstallType.Full:
          chkClientInstall.CheckState = CheckState.Unchecked;
          break;
        case InstallType.Client:
          chkClientInstall.CheckState = CheckState.Checked;
          break;
      }
    }

    public void Clear()
    {
      chkClientInstall.CheckState = CheckState.Unchecked;
    }

    private void chkClientInstall_CheckedChanged(object sender, EventArgs e)
    {
      UiServices.ProjectSettings.InstallType = chkClientInstall.Checked ? InstallType.Client : InstallType.Full;
    }
  }
}
