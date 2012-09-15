using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SitecoreInstaller.UI
{
    using SitecoreInstaller.App;
    using SitecoreInstaller.App.Pipelines;

    public partial class PipelineLists : UserControl
    {
        private Func<AppSettings> _getAppSettings;

        public PipelineLists()
        {
            InitializeComponent();
        }

        public void Init(Func<AppSettings> getAppSettings)
        {
            _getAppSettings = getAppSettings;
            var installer = Services.Pipelines.Get<InstallPipeline>();
            pipelineStepListInstall.Init(installer.Pipeline, _getAppSettings);
            var unInstaller = Services.Pipelines.Get<UninstallPipeline>();
            pipelineStepListUninstall.Init(unInstaller.Pipeline, _getAppSettings);
            var reAttacher = Services.Pipelines.Get<ReAttachPipeline>();
            pipelineStepListReAttach.Init(reAttacher.Pipeline, _getAppSettings);
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            Services.AppSettings = _getAppSettings();
            Services.Pipelines.Run<InstallPipeline>();
        }

        private void btnUninstall_Click(object sender, EventArgs e)
        {
            Services.AppSettings = _getAppSettings();
            Services.Pipelines.Run<UninstallPipeline>();
        }

        private void btnReAttach_Click(object sender, EventArgs e)
        {
            Services.AppSettings = _getAppSettings();
            Services.Pipelines.Run<ReAttachPipeline>();
        }

        private void btnReinstall_Click(object sender, EventArgs e)
        {
            Services.AppSettings = _getAppSettings();
            Services.Pipelines.Run<ReinstallPipeline>();
        }

    }
}
