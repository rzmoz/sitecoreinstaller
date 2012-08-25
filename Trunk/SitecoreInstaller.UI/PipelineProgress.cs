using System;
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
                    pgbStatus.Visible = true;
                });
        }
        public void Ended(object sender, PipelineEventArgs e)
        {
            this.CrossThreadSafe(() =>
                {
                    pgbStatus.Visible = false;
                    
                    lblTitle.Text = lblTitle.Text + " finished";
                    lblStatusMessage.Text = e.Status.ToString();
                    tbxInfo.Text = string.Empty;
                    cmdOk.Left = Width / 2 - cmdOk.Width / 2;
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
