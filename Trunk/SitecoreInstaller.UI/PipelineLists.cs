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
    using SitecoreInstaller.Domain.Pipelines;

    public partial class PipelineLists : UserControl
    {
        private Func<ProjectSettings> _getProjectSettings;

        public PipelineLists()
        {
            InitializeComponent();
        }

        public void Init(Func<ProjectSettings> getProjectSettings)
        {
            _getProjectSettings = getProjectSettings;
            var installer = Services.Pipelines.Get<InstallPipeline>();
            pipelineStepListInstall.Init(installer.Pipeline, _getProjectSettings);
            var unInstaller = Services.Pipelines.Get<UninstallPipeline>();
            pipelineStepListUninstall.Init(unInstaller.Pipeline, _getProjectSettings);
            var reAttacher = Services.Pipelines.Get<ReAttachPipeline>();
            pipelineStepListReAttach.Init(reAttacher.Pipeline, _getProjectSettings);
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            Services.ProjectSettings = _getProjectSettings();
            Services.Pipelines.Run<InstallPipeline>();
        }

        private void btnUninstall_Click(object sender, EventArgs e)
        {
            Services.ProjectSettings = _getProjectSettings();
            Services.Pipelines.Run<UninstallPipeline>();
        }

        private void btnReAttach_Click(object sender, EventArgs e)
        {
            Services.ProjectSettings = _getProjectSettings();
            Services.Pipelines.Run<ReAttachPipeline>();
        }

        private void btnReinstall_Click(object sender, EventArgs e)
        {
            Services.ProjectSettings = _getProjectSettings();
            Services.Pipelines.Run<ReinstallPipeline>(Dialogs.Off);
        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            Services.ProjectSettings = _getProjectSettings();
            Services.Pipelines.Run<ArchivePipeline>();
        }
    }
}
