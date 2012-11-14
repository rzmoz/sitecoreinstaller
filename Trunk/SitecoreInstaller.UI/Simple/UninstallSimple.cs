namespace SitecoreInstaller.UI.Simple
{
    using System;
    using System.Linq;
    using System.Windows.Forms;

    using SitecoreInstaller.App;
    using SitecoreInstaller.App.Pipelines;
    using SitecoreInstaller.App.Properties;
    using SitecoreInstaller.Domain.Pipelines;

    public partial class UninstallSimple : UserControl
    {
        public UninstallSimple()
        {
            InitializeComponent();
        }
        public void Init()
        {
            selectProjectName1.Init();
            selectProjectName1.DropDownStyle=ComboBoxStyle.DropDownList;
            selectProjectName1.Focus();
        }

        public ProjectSettings GetProjectSettings()
        {
            var projectSettings = new ProjectSettings();
            projectSettings.Init(UserSettings.Default);
            projectSettings.ProjectName = selectProjectName1.ProjectName;
            return projectSettings;
        }

        public event EventHandler<EventArgs> Cancelled;
        public void btnCancel_Click(object sender, EventArgs e)
        {
            if (Cancelled != null)
                Cancelled(this, new EventArgs());
        }

        public void btnUninstall_Click(object sender, EventArgs e)
        {
            if (selectProjectName1.ProjectName.Length == 0)
                Services.Dialogs.Information("Please choose a project");
            else
            {
                Services.ProjectSettings = GetProjectSettings();
                Services.Pipelines.Run<UninstallPipeline>(Dialogs.Off);
            }
        }
    }
}

