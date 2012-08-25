using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller
{
    using System.Windows.Forms;

    using SitecoreInstaller.App;

    internal class MainFormDeveloperFunc : MainFormFunc
    {
        public MainFormDeveloperFunc(FrmMain mainForm)
            : base(mainForm)
        {
            MainForm.MainSimple.Hide();
            MainForm.MainDeveloper.Show();
            MainForm.Logger.ShowLogLevels = true;
        }

        protected override int SetContentWidth()
        {
            var contentWidth = Dimensions.MainDeveloperWidth;

            MainForm.MainDeveloper.PanelAdvanced.Visible = true;

            return contentWidth;
        }

        protected override int SetContentHeight(bool showLog)
        {
            var contentHeight = Dimensions.MainDeveloperHeight;
            MainForm.PanelMain.Height = contentHeight;
            contentHeight += Dimensions.LoggerHeight;

            return contentHeight;
        }

        public override void Install(object sender, EventArgs e)
        {
            Services.AppSettings = MainForm.MainDeveloper.SelectionsDeveloper.GetAppSettings();
            Services.PipelineWorker.RunPipeline(Services.Pipelines.GetInstaller());
        }

        public override void Uninstall(object sender, EventArgs e)
        {
            Services.AppSettings = MainForm.MainDeveloper.SelectionsDeveloper.GetAppSettings();
            Services.PipelineWorker.RunPipeline(Services.Pipelines.GetUnInstaller());
        }

        public override void KeyUp(object sender, KeyEventArgs e)
        {
        }

        public override void OpenSitecore(object sender, EventArgs e)
        {
            var appsettings = MainForm.MainDeveloper.SelectionsDeveloper.GetAppSettings();
            Services.Website.OpenSitecore(appsettings.IisSiteName, appsettings.WebsiteFolders.WebSiteFolder);
        }

        public override void OpenFrontend(object sender, EventArgs e)
        {
            Services.Website.OpenFrontend(MainForm.MainDeveloper.SelectionsDeveloper.GetAppSettings().IisSiteName);
        }
    }
}
