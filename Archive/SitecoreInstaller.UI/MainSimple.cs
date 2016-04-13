using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharp.Basics.Forms.Viewport;
using SitecoreInstaller.App;
using SitecoreInstaller.UI.Simple;

namespace SitecoreInstaller.UI
{
    public partial class MainSimple : BasicsUserControl
    {
        public MainSimple()
        {
            InitializeComponent();
        }

        public void Init()
        {
            installCtrl1.Init();
            uninstallCtrl1.Init();
            openSiteCtrl1.Init();

            btnInstall.Image = SimpleResources.Install;
            btnUninstall.Image = SimpleResources.Uninstall;
            btnOpenSite.Image = SimpleResources.OpenSite;
            InitButtons(btnInstall, btnUninstall, btnOpenSite);
        }

        private void InitButtons(params Button[] buttons)
        {
            Parallel.ForEach(buttons, button =>
            {
                button.BackColor = Styles.Navigation.Level1.BackColor;
                button.ForeColor = Styles.Navigation.Level1.ForeColor;
                button.FlatAppearance.BorderSize = 0;
            });
        }

        public override void OnShow()
        {
            base.OnShow();
            btnOpenSite.Text = Services.Projects.GetExistingProjects().Count() + new string(' ', 29);
            if (ParentForm != null) ParentForm.Height = Styles.MainForm.HeightSimple;
            Services.UserPreferences.Properties.AdvancedView = false;
            Services.UserPreferences.Save();
        }

        public override bool ProcessKeyPress(Keys keyData)
        {
            //we only activate keyboard shortcuts, if we're visible
            if (UiServices.ViewportStack.IsVisible(this) == false)
                return false;

            switch (keyData)
            {
                case Keys.D | Keys.Control | Keys.Shift:
                    UiServices.ViewportStack.Show("SitecoreInstaller.UI.MainDeveloper");
                    return true;
                case Keys.B | Keys.Control | Keys.Shift:
                    btnInstall_Click(this, new EventArgs());
                    return true;
                case Keys.U | Keys.Control | Keys.Shift:
                    btnUninstall_Click(this, new EventArgs());
                    return true;
                case Keys.O | Keys.Control:
                    btnOpenSite_Click(this, new EventArgs());
                    return true;
            }
            return false;
        }

        private void MainSimple_Resize(object sender, EventArgs e)
        {
            ResizeButtons(btnInstall, btnUninstall, btnOpenSite);
        }

        private void ResizeButtons(params Button[] buttons)
        {
            if (buttons == null || buttons.Length == 0)
                return;

            const int padding = 30;
            const int buttonMinWidth = 120;
            var buttonWidth = (this.Width - padding) / buttons.Length - padding;
            if (buttonWidth < buttonMinWidth)
                buttonWidth = buttonMinWidth;

            var i = 1;
            foreach (var button in buttons)
            {
                button.Width = buttonWidth;
                button.Height = buttonWidth;
                button.Top = Height / 2 - button.Height / 2;
                button.Left = (padding * i) + button.Width * (i - 1);
                i++;
            }
        }

        private void btnOpenSite_Click(object sender, EventArgs e)
        {
            UiServices.ViewportStack.Show(openSiteCtrl1);
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            UiServices.ViewportStack.Show(installCtrl1);
        }

        private void btnUninstall_Click(object sender, EventArgs e)
        {
            UiServices.ViewportStack.Show(uninstallCtrl1);
        }
    }
}
