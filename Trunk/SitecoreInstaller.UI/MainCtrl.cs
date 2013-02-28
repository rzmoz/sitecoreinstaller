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
  using SitecoreInstaller.UI.Navigation;

  public partial class MainCtrl : UserControl
  {
    public MainCtrl()
    {
      InitializeComponent();
      Buttons = new NavigationCtrlList(pnlMainNavigation);
    }

    protected override void InitLayout()
    {
      base.InitLayout();
      SuspendLayout();

      Buttons.Add(new MainNavigationButton(button1) { Text = "My Sitecores", Image = Properties.Resources.MySitecores, ImageSelected = Properties.Resources.MySitecores_Active });
      Buttons.Add(new MainNavigationButton(button2) { Text = "Install New Sitecore", Image = Properties.Resources.InstallNewSitecore, ImageSelected = Properties.Resources.InstallNewSitecore_Active });
      Buttons.Add(new MainNavigationButton(button3) { Text = "Settings", Image = Properties.Resources.Settings, ImageSelected = Properties.Resources.Settings_Active, Dock = DockStyle.Bottom });

      ResumeLayout(false);
    }

    public NavigationCtrlList Buttons { get; set; }
  }
}
