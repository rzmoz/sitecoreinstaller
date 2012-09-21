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
    using SitecoreInstaller.Domain.Pipelines;

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

        public ProjectSettings GetProjectSettings()
        {
            var projectSettings = new ProjectSettings();
            projectSettings.Init(UserSettings.Default);
            projectSettings.ProjectName.Value = selectProjectName1.ProjectName;
            projectSettings.BuildLibrarySelections.SelectedLicense = selectLicense1.SelectedItem;
            return projectSettings;
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
                Services.ProjectSettings = GetProjectSettings();
                Services.Pipelines.Run<ReinstallPipeline>(Dialogs.Off);
            }
        }
    }
}
