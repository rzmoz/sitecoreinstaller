using System;
using System.Windows.Forms;
using CSharp.Basics.Forms.Viewport;
using SitecoreInstaller.UI.Viewport;

namespace SitecoreInstaller.UI
{
    public partial class MainDeveloperButtons : UserControl
    {
        public MainDeveloperButtons()
        {
            InitializeComponent();
        }

        public void Init()
        {
            BackColor = Styles.Navigation.Level1.BackColor;
            toolTip1.SetToolTip(btnInstall, "CTRL + SHIFT + B");
            toolTip1.SetToolTip(btnUninstall, "CTRL + SHIFT + U");
            toolTip1.SetToolTip(btnReinstall, "CTRL + SHIFT + R");
            toolTip1.SetToolTip(btnArchive, "CTRL + SHIFT + A");
            btnArchive.DrawBottomDivider = true;

            toolTip1.SetToolTip(btnOpenSitecore, "CTRL + SHIFT + O");
            toolTip1.SetToolTip(btnOpenWebsite, "CTRL + O");
            toolTip1.SetToolTip(btnOpenProjectFolder, "CTRL + ALT + O");
            toolTip1.SetToolTip(btnOpenLogFiles, "CTRL + ALT + L");
            btnOpenLogFiles.DrawBottomDivider = true;
            toolTip1.SetToolTip(btnPublishSite, "CTRL + SHIFT + P");
            btnPublishSite.DrawBottomDivider = true;
        }

        private void TriggerKeyboardShortcut(Keys keys)
        {
            var parentSiCtrl = Parent;
            while (parentSiCtrl is BasicsUserControl == false)
            {
                parentSiCtrl = parentSiCtrl.Parent;
            }
            (parentSiCtrl as BasicsUserControl).ProcessKeyPress(keys);
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            TriggerKeyboardShortcut(Keys.B | Keys.Control | Keys.Shift);
        }

        private void btnUninstall_Click(object sender, EventArgs e)
        {
            TriggerKeyboardShortcut(Keys.U | Keys.Control | Keys.Shift);
        }

        private void btnReinstall_Click(object sender, EventArgs e)
        {
            TriggerKeyboardShortcut(Keys.R | Keys.Control | Keys.Shift);
        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            TriggerKeyboardShortcut(Keys.A | Keys.Control | Keys.Shift);
        }

        private void btnOpenSitecore_Click(object sender, EventArgs e)
        {
            TriggerKeyboardShortcut(Keys.O | Keys.Control | Keys.Shift);
        }

        private void btnOpenWebsite_Click(object sender, EventArgs e)
        {
            TriggerKeyboardShortcut(Keys.O | Keys.Control);
        }

        private void btnOpenProjectFolder_Click(object sender, EventArgs e)
        {
            TriggerKeyboardShortcut(Keys.O | Keys.Control | Keys.Alt);
        }

        private void btnPublishSite_Click(object sender, EventArgs e)
        {
            TriggerKeyboardShortcut(Keys.P | Keys.Control | Keys.Shift);
        }

        private void btnOpenLogFiles_Click(object sender, EventArgs e)
        {
            TriggerKeyboardShortcut(Keys.L | Keys.Control | Keys.Alt);
        }

        private void btnRecycleSite_Click(object sender, EventArgs e)
        {
            TriggerKeyboardShortcut(Keys.R | Keys.Control | Keys.Alt);
        }
    }
}
