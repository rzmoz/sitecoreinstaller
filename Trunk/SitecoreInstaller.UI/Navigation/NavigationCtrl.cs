using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SitecoreInstaller.UI.Navigation
{
  public partial class NavigationCtrl : UserControl
  {
    public NavigationCtrl()
    {
      InitializeComponent();
      Buttons = new NavigationCtrlList(this);
    }

    protected override void InitLayout()
    {
      base.InitLayout();
      SuspendLayout();

      Buttons.Add(new MainNavigationButton { Text = "My Sitecores", Image = Properties.Resources.MySitecores, ImageSelected = Properties.Resources.MySitecores_Active });
      Buttons.Add(new MainNavigationButton { Text = "Install New Sitecore", Image = Properties.Resources.InstallNewSitecore, ImageSelected = Properties.Resources.InstallNewSitecore_Active });
      Buttons.Add(new MainNavigationButton { Text = "Settings", Image = Properties.Resources.Settings, ImageSelected = Properties.Resources.Settings_Active, Dock = DockStyle.Bottom });
    
      ResumeLayout(false);
    }

    public NavigationCtrlList Buttons { get; set; }
  }
}
