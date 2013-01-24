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
            Buttons = new CtrlList<MainNavigationButton>();
            Buttons.Click += ButtonsClick;
        }

        void ButtonsClick(object sender, EventArgs e)
        {
            var button = sender as MainNavigationButton;
            if (button == null)
                return;

            if (Buttons.ActiveControl != null)
                Buttons.ActiveControl.BackColor = button.BackColor;
            button.BackColor = button.FlatAppearance.MouseOverBackColor;
        }

        protected override void InitLayout()
        {
            base.InitLayout();
            SuspendLayout();

            Buttons.Add(new MainNavigationButton { Image = Properties.Resources.ExistingInstallations, Text = "My Sitecores" }, null);
            Buttons.Add(new MainNavigationButton { Image = Properties.Resources.InstallNewSitecore, Text = "Install New Sitecore" }, null);
            Buttons.Add(new MainNavigationButton { Image = Properties.Resources.settings, Text = "Settings", Dock = DockStyle.Bottom }, null);

            Controls.AddRange(Buttons.ToArray());

            ResumeLayout(false);
        }

        public CtrlList<MainNavigationButton> Buttons { get; set; }
    }
}
