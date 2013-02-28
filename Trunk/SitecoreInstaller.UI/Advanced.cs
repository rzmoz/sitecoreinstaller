using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SitecoreInstaller.UI
{
  using SitecoreInstaller.UI.Navigation;

  public partial class Advanced : UserControl
  {
    public Advanced()
    {
      InitializeComponent();
      Buttons = new NavigationCtrlList(pnlMainNavigation);
    }

    protected override void InitLayout()
    {
      base.InitLayout();
      SuspendLayout();

      Buttons.Add(new MainNavigationButton(button1) { Text = "My Sitecores", Image = NavigationResources.MySitecores, ImageSelected = NavigationResources.MySitecores_Active });
      Buttons.Add(new MainNavigationButton(button2) { Text = "Install New Sitecore", Image = NavigationResources.InstallNewSitecore, ImageSelected = NavigationResources.InstallNewSitecore_Active });
      Buttons.Add(new MainNavigationButton(button3) { Text = "Settings", Image = NavigationResources.Settings, ImageSelected = NavigationResources.Settings_Active, Dock = DockStyle.Bottom });

      ResumeLayout(false);
    }

    public NavigationCtrlList Buttons { get; set; }
  }
}
