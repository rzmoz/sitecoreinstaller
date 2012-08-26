namespace SitecoreInstaller.UI.Simple
{
    using System;
    using System.Windows.Forms;

    using SitecoreInstaller.App;
    using SitecoreInstaller.App.Pipelines;
    using SitecoreInstaller.App.Properties;

    public partial class InstallSimple : UserControl
    {
        public InstallSimple()
        {
            InitializeComponent();
        }
        public AppSettings GetAppSettings()
        {
            var appSettings = new AppSettings();
            appSettings.Init(UserSettings.Default);
            appSettings.ProjectName.Value = tbxProjectName.Text;
            appSettings.UserSelections.SelectedSitecore = selectSitecore1.SelectedItem;
            appSettings.UserSelections.SelectedLicense = selectLicense1.SelectedItem;
            return appSettings;
        }

        public void Init()
        {
            tbxProjectName.Text = string.Empty;
            selectLicense1.Init();
            selectSitecore1.Init();
            selectLicense1.Visible = true;
        }
        public event EventHandler<EventArgs> Cancelled;
        public void btnCancel_Click(object sender, EventArgs e)
        {
            if (Cancelled != null)
                Cancelled(this, new EventArgs());
        }
        public void btnInstall_Click(object sender, EventArgs e)
        {
            if (tbxProjectName.Text.Length == 0)
                Services.Dialogs.Information("Please enter project name");
            else
            {
                Services.AppSettings = GetAppSettings();
                Services.Pipelines.Run<InstallPipeline>();
            }
        }
    }
}
