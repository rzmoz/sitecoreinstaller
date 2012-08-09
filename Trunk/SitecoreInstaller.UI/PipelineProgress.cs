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
            Services.Log.EntryLogged += UpdateInfo;
            Services.PipelineWorker.StepExecuting += UpdateStatus;
        }

        public void UpdateStatus(object sender, PipelineStepEventArgs e)
        {
            if (InvokeRequired)
            {
                EventHandler<PipelineStepEventArgs> inv = UpdateStatus;
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
                if (e.Arg.MessageType == MessageType.Info)
                    tbxInfo.Text = e.Arg.Message;
            }
        }
    }
}
