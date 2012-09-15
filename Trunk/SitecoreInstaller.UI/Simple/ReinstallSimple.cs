using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SitecoreInstaller.UI.Simple
{
    using SitecoreInstaller.App;
    using SitecoreInstaller.App.Pipelines;
    using SitecoreInstaller.App.Properties;

    public partial class ReinstallSimple : UserControl
    {
        public ReinstallSimple()
        {
            InitializeComponent();
        }

        public void Init()
        {
            selectLicense1.Init();
            selectProjectName1.Init();
            selectProjectName1.DropDownStyle = ComboBoxStyle.DropDownList;
            selectProjectName1.Focus();
        }

        public AppSettings GetAppSettings()
        {
            var appSettings = new AppSettings();
            appSettings.Init(UserSettings.Default);
            appSettings.ProjectName.Value = selectProjectName1.ProjectName;
            appSettings.UserSelections.SelectedLicense = selectLicense1.SelectedItem;
            return appSettings;
        }

        public event EventHandler<EventArgs> Cancelled;
        public void btnCancel_Click(object sender, EventArgs e)
        {
            if (Cancelled != null)
                Cancelled(this, new EventArgs());
        }
        
        private void btnReinstall_Click(object sender, EventArgs e)
        {
            if (selectProjectName1.ProjectName.Length == 0)
                Services.Dialogs.Information("Please choose a project");
            else
            {
                Services.AppSettings = GetAppSettings();
                Services.Pipelines.Run<ReinstallPipeline>();
            }
        }
    }
}
