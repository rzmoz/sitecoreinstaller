﻿using System;
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

        protected override int SetContentHeight(bool useAdvancedView)
        {
            var contentHeight = Dimensions.MainSimpleHeight;
            MainForm.PanelMain.Height = contentHeight;

            if (useAdvancedView)
                return contentHeight + Dimensions.LoggerHeight;
            return contentHeight;
        }

        protected override int SetContentWidth(bool useAdvancedView)
        {
            var width = Dimensions.MainSimpleWidth;
            if (useAdvancedView)
                width += Dimensions.MainSimpleAdvancedWidth;
            return width;
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
            else if (MainForm.MainSimple.Open.Visible)
                MainForm.MainSimple.Open.btnCancel_Click(sender, e);
        }

        public override void OpenSitecore(object sender, EventArgs e)
        {
            if (MainForm.MainSimple.Install.Visible)
            {
                var appsettings = MainForm.MainSimple.Install.GetAppSettings();
                Services.Website.OpenSitecore(appsettings.IisSiteName, appsettings.WebsiteFolders.WebSiteFolder);
            }
            else if (MainForm.MainSimple.Uninstall.Visible)
            {
                var appsettings = MainForm.MainSimple.Uninstall.GetAppSettings();
                Services.Website.OpenSitecore(appsettings.IisSiteName, appsettings.WebsiteFolders.WebSiteFolder);
            }
            else if (MainForm.MainSimple.Open.Visible)
            {
                var appsettings = MainForm.MainSimple.Open.GetAppSettings();
                Services.Website.OpenSitecore(appsettings.IisSiteName, appsettings.WebsiteFolders.WebSiteFolder);
            }
        }

        public override void OpenFrontend(object sender, EventArgs e)
        {
            if (MainForm.MainSimple.Install.Visible)
                Services.Website.OpenFrontend(MainForm.MainSimple.Install.GetAppSettings().IisSiteName);
            else if (MainForm.MainSimple.Uninstall.Visible)
                Services.Website.OpenFrontend(MainForm.MainSimple.Uninstall.GetAppSettings().IisSiteName);
            else if (MainForm.MainSimple.Open.Visible)
                Services.Website.OpenFrontend(MainForm.MainSimple.Open.GetAppSettings().IisSiteName);
            else
                MainForm.MainSimple.btnOpen_Click(sender, e);
        }
    }
}
