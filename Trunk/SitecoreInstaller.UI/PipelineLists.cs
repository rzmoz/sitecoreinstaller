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
            var installer = Services.Pipelines.GetInstaller(getAppSettings);
            installer.Processor.InitOnStepInvoke = true;
            pipelineStepListInstall.Init(installer);
            var unInstaller = Services.Pipelines.GetUnInstaller(getAppSettings);
            unInstaller.Processor.InitOnStepInvoke = true;
            pipelineStepListUninstall.Init(unInstaller);
            var reAttacher = Services.Pipelines.GetReAttach(getAppSettings);
            reAttacher.Processor.InitOnStepInvoke = true;
            pipelineStepListReAttach.Init(reAttacher);
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            Services.PipelineWorker.RunPipeline(Services.Pipelines.GetInstaller(_getAppSettings));
        }

        private void btnUninstall_Click(object sender, EventArgs e)
        {
            Services.PipelineWorker.RunPipeline(Services.Pipelines.GetUnInstaller(_getAppSettings));
        }

        private void btnReAttach_Click(object sender, EventArgs e)
        {
            Services.PipelineWorker.RunPipeline(Services.Pipelines.GetReAttach(_getAppSettings));
        }
    }
}
