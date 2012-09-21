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
    using SitecoreInstaller.App.Properties;

    public partial class OpenSimple : UserControl
    {
        public OpenSimple()
        {
            InitializeComponent();
        }

        public void Init(string selectedProjectName)
        {
            selectProjectName1.Init();
            selectProjectName1.DropDownStyle = ComboBoxStyle.DropDownList;
            if (string.IsNullOrEmpty(selectedProjectName) == false)
                selectProjectName1.ProjectName = selectedProjectName;
            selectProjectName1.Focus();
        }

        public ProjectSettings GetProjectSettings()
        {
            var projectSettings = new ProjectSettings();
            projectSettings.Init(UserSettings.Default);
            projectSettings.ProjectName.Value = selectProjectName1.ProjectName;
            return projectSettings;
        }

        public event EventHandler<EventArgs> Cancelled;
        public void btnCancel_Click(object sender, EventArgs e)
        {
            if (Cancelled != null)
                Cancelled(this, new EventArgs());
        }

        private void btnUninstall_Click(object sender, EventArgs e)
        {
            if (selectProjectName1.ProjectName.Length == 0)
                Services.Dialogs.Information("Please choose a project");
            else
            {
                var projectSettings = GetProjectSettings();
                Services.Website.OpenFrontend(projectSettings.Iis.Url);
            }
        }
    }
}
