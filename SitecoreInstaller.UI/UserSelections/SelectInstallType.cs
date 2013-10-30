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
  public partial class SelectInstallType : UserControl
  {
    public SelectInstallType()
    {
      InitializeComponent();
    }

    public void Init()
    {
      UiServices.ProjectSettings.Updated += ProjectSettings_Updated;
      Clear();
    }

    void ProjectSettings_Updated(object sender, Framework.Sys.GenericEventArgs<string> e)
    {
      switch (UiServices.ProjectSettings.InstallType)
      {
        case InstallType.Full:
          radInstallTypeFull.Checked = true;
          break;
        case InstallType.Client:
          radInstallTypeClient.Checked = true;
          break;
      }
    }

    public void Clear()
    {
      radInstallTypeFull.Checked = true;
    }

    private void radInstallTypeFull_CheckedChanged(object sender, EventArgs e)
    {
      UiServices.ProjectSettings.InstallType = radInstallTypeClient.Checked ? InstallType.Client : InstallType.Full;
    }

    private void radInstallTypeClient_CheckedChanged(object sender, EventArgs e)
    {
      UiServices.ProjectSettings.InstallType = radInstallTypeClient.Checked ? InstallType.Client : InstallType.Full;
    }
  }
}
