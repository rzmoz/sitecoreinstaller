using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SitecoreInstaller.UI.Developer
{
    using Microsoft.Web.Administration;

    using SitecoreInstaller.App;
    using SitecoreInstaller.Domain;
    using SitecoreInstaller.Domain.WebServer;
    using SitecoreInstaller.Framework.System;

    public partial class AdvancedSettings : UserControl
    {
        public AdvancedSettings()
        {
            InitializeComponent();
        }

        public IisSettings GetIisSettings()
        {
            var iisSettings = new IisSettings
            {
                ManagedRuntimeVersion = (ClrVersion)cbxClrVersion.SelectedItem,
                Enable32BitAppOnWin64 = chk32BitEnabled.Checked,
                ManagedPipelineMode =
                    cbxManagedPipelineMode.SelectedItem.ToString().ParseToEnumValue<ManagedPipelineMode>()
            };
            return iisSettings;
        }
        public InstallType GetInstallType()
        {
            return cbxInstallType.SelectedItem.ToString().ParseToEnumValue<InstallType>();
        }

        public void Init()
        {
            chk32BitEnabled.Checked = false;

            cbxClrVersion.DataSource = ClrVersion.Names;
            cbxClrVersion.SelectedIndex = cbxClrVersion.Items.Count - 1;//select last item

            cbxManagedPipelineMode.DataSource = Enum.GetNames(typeof(ManagedPipelineMode));
            cbxManagedPipelineMode.SelectedIndex = cbxManagedPipelineMode.Items.Count > 0 ? 0 : -1;

            cbxInstallType.DataSource = Enum.GetNames(typeof(InstallType));
        }
    }
}
