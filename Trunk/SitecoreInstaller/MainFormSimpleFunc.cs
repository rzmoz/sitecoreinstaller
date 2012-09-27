using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller
{
    using System.Windows.Forms;

    using SitecoreInstaller.App;

    internal class MainFormSimpleFunc : MainFormFunc
    {
        public MainFormSimpleFunc(FrmMain mainForm)
            : base(mainForm)
        {
            MainForm.MainSimple.Show();
            MainForm.MainDeveloper.Hide();
            MainForm.Logger.ShowLogLevels = false;
        }

        protected override int SetContentWidth()
        {
            return Dimensions.MainSimpleWidth;
        }

        protected override int SetContentHeight(bool showLog)
        {
            const int contentHeight = Dimensions.MainSimpleHeight;
            MainForm.PanelMain.Height = contentHeight;

            if (showLog)
                return contentHeight + Dimensions.LoggerHeight;
            return contentHeight;
        }
        public override void Install(object sender, EventArgs e)
        {
            if (MainForm.MainSimple.PanelMain.Visible)
                MainForm.MainSimple.btnInstall_Click(sender, e);
            else if (MainForm.MainSimple.Install.Visible)
                MainForm.MainSimple.Install.btnInstall_Click(sender, e);
        }

        public override void Uninstall(object sender, EventArgs e)
        {
            if (MainForm.MainSimple.PanelMain.Visible)
                MainForm.MainSimple.btnUninstall_Click(sender, e);
            else if (MainForm.MainSimple.Uninstall.Visible)
                MainForm.MainSimple.Uninstall.btnUninstall_Click(sender, e);
        }

        public override void KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape)
                return;

            if (MainForm.MainSimple.PanelMain.Visible)
                return;
            if (MainForm.MainSimple.Install.Visible)
                MainForm.MainSimple.Install.btnCancel_Click(sender, e);
            else if (MainForm.MainSimple.Uninstall.Visible)
                MainForm.MainSimple.Uninstall.btnCancel_Click(sender, e);
            else if (MainForm.MainSimple.Reinstall.Visible)
                MainForm.MainSimple.Reinstall.btnCancel_Click(sender, e);
            else if (MainForm.MainSimple.Open.Visible)
                MainForm.MainSimple.Open.btnCancel_Click(sender, e);
        }

        public override void OpenSitecore(object sender, EventArgs e)
        {
            ProjectSettings projectSettings = null;
            if (MainForm.MainSimple.Install.Visible)
            {
                projectSettings = MainForm.MainSimple.Install.GetProjectSettings();
            }
            else if (MainForm.MainSimple.Uninstall.Visible)
            {
                projectSettings = MainForm.MainSimple.Uninstall.GetProjectSettings();
            }
            else if (MainForm.MainSimple.Open.Visible)
            {
                projectSettings = MainForm.MainSimple.Open.GetProjectSettings();
            }
            if (projectSettings == null)
                return;
            Services.Website.OpenSitecore(projectSettings.Iis.Url, projectSettings.ProjectFolder.Website.Directory);
        }

        public override void OpenFrontend(object sender, EventArgs e)
        {
            if (MainForm.MainSimple.Install.Visible)
                Services.Website.OpenFrontend(MainForm.MainSimple.Install.GetProjectSettings().Iis.Url);
            else if (MainForm.MainSimple.Uninstall.Visible)
                Services.Website.OpenFrontend(MainForm.MainSimple.Uninstall.GetProjectSettings().Iis.Url);
            else if (MainForm.MainSimple.Open.Visible)
                Services.Website.OpenFrontend(MainForm.MainSimple.Open.GetProjectSettings().Iis.Url);
            else
                MainForm.MainSimple.btnOpen_Click(sender, e);
        }
    }
}
