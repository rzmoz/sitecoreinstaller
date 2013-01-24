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
    public partial class MainNavigationCtrl : UserControl
    {
        public MainNavigationCtrl()
        {
            InitializeComponent();
            Buttons = new NavigationCtrlList<MainNavigationButton>();
        }

        protected override void InitLayout()
        {
            base.InitLayout();
            SuspendLayout();

            Buttons.Add(new MainNavigationButton { Text = "My Sitecores", Image = Properties.Resources.MySitecores, ImageSelected = Properties.Resources.MySitecores_Active }, null);
            Buttons.Add(new MainNavigationButton { Text = "Install New Sitecore", Image = Properties.Resources.InstallNewSitecore, ImageSelected = Properties.Resources.InstallNewSitecore_Active }, null);
            Buttons.Add(new MainNavigationButton { Text = "Settings", Image = Properties.Resources.Settings, ImageSelected = Properties.Resources.Settings_Active, Dock = DockStyle.Bottom }, null);

            Controls.AddRange(Buttons.ToArray());

            ResumeLayout(false);
        }

        public NavigationCtrlList<MainNavigationButton> Buttons { get; set; }
    }
}
