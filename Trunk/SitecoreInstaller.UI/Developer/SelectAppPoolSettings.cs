namespace SitecoreInstaller.UI.Developer
{
    using System;
    using System.Windows.Forms;

    using SitecoreInstaller.Domain.WebServer;
    using SitecoreInstaller.Framework.System;

    using Microsoft.Web.Administration;

    public partial class SelectAppPoolSettings : UserControl
    {
        public SelectAppPoolSettings()
        {
            InitializeComponent();
        }
        public IisSettings GetAppPoolSettings()
        {
            var appPoolSettings = new IisSettings
                {
                    ManagedRuntimeVersion = (ClrVersion)cbxClrVersion.SelectedItem,
                    Enable32BitAppOnWin64 = chk32BitEnabled.Checked,
                    ManagedPipelineMode =
                        cbxManagedPipelineMode.SelectedItem.ToString().ParseToEnumValue<ManagedPipelineMode>()
                };
            return appPoolSettings;
        }

        public void Init()
        {
            chk32BitEnabled.Checked = false;

            cbxClrVersion.DataSource = ClrVersion.Names;
            cbxClrVersion.SelectedIndex = cbxClrVersion.Items.Count - 1;//select last item

            cbxManagedPipelineMode.DataSource = Enum.GetNames(typeof(ManagedPipelineMode));
            cbxManagedPipelineMode.SelectedIndex = cbxManagedPipelineMode.Items.Count > 0 ? 0 : -1;
        }
    }
}
