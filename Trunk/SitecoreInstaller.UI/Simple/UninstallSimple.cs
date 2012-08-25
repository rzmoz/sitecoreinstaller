namespace SitecoreInstaller.UI.Simple
{
    using System;
    using System.Linq;
    using System.Windows.Forms;

    using SitecoreInstaller.App;
    using SitecoreInstaller.App.Properties;

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

        public AppSettings GetAppSettings()
        {
            var appSettings = new AppSettings();
            appSettings.Init(UserSettings.Default);
            appSettings.ProjectName.Value = selectProjectName1.ProjectName;
            return appSettings;
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
                Services.AppSettings = GetAppSettings();
                Services.PipelineWorker.RunPipeline(Services.Pipelines.GetUnInstaller());
            }
                
        }
    }
}

