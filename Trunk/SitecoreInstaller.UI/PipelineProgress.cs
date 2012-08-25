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
            this.CrossThreadSafe(() =>
                {
                    lblTitle.Text = e.PipelineName;
                    cmdOk.Visible = false;
                });
        }
        public void Ended(object sender, PipelineEventArgs e)
        {
            this.CrossThreadSafe(() =>
                    {
                        lblTitle.Text = lblTitle.Text + " finished";
                        cmdOk.Visible = true;
                        cmdOk.Focus();
                    });
        }

        public void UpdateStatus(object sender, PipelineStepInfoEventArgs e)
        {
            this.CrossThreadSafe(() =>
                    {
                        pgbStatus.Value = e.ProgressPercentage;
                        lblStatusMessage.Text = e.StepName;
                    });
        }

        public void UpdateInfo(object sender, GenericEventArgs<LogEntry> e)
        {
            this.CrossThreadSafe(() =>
                    {
                        if (e.Arg.LogType == LogType.Info)
                            tbxInfo.Text = e.Arg.Message;
                    });
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            SendToBack();
            Hide();
        }
    }
}
