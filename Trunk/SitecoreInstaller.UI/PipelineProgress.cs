using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SitecoreInstaller.Domain.Pipelines;


namespace SitecoreInstaller.UI
{
    using SitecoreInstaller.App;
    using SitecoreInstaller.Framework.Diagnostics;
    using SitecoreInstaller.Framework.System;

    public partial class PipelineProgress : UserControl
    {
        public PipelineProgress()
        {
            InitializeComponent();
        }

        public void Init()
        {
            Log.It.EntryLogged += UpdateInfo;
            Services.PipelineWorker.StepExecuting += UpdateStatus;
        }

        public void Starting(object sender, PipelineEventArgs e)
        {
            if (InvokeRequired)
            {
                EventHandler<PipelineEventArgs> inv = Starting;
                Invoke(inv, new[] { sender, e });
            }
            else
            {
                lblTitle.Text = e.PipelineName;
            }
        }

        public void UpdateStatus(object sender, PipelineStepInfoEventArgs e)
        {
            if (InvokeRequired)
            {
                EventHandler<PipelineStepInfoEventArgs> inv = UpdateStatus;
                Invoke(inv, new[] { sender, e });
            }
            else
            {
                pgbStatus.Value = e.ProgressPercentage;
                lblStatusMessage.Text = e.StepName;
            }
        }

        public void UpdateInfo(object sender, GenericEventArgs<LogEntry> e)
        {
            if (InvokeRequired)
            {
                EventHandler<GenericEventArgs<LogEntry>> inv = UpdateInfo;
                Invoke(inv, new[] { sender, e });
            }
            else
            {
                if (e.Arg.LogType == LogType.Info)
                    tbxInfo.Text = e.Arg.Message;
            }
        }
    }
}
