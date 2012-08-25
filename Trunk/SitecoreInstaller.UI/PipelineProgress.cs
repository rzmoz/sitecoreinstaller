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
                    pgbStatus.Visible = true;
                    cmdOk.Visible = false;
                    tbxInfo.Visible = true;
                    tbxMessages.Visible = false;
                });
        }
        public void Ended(object sender, PipelineEventArgs e)
        {
            this.CrossThreadSafe(() =>
                {
                    pgbStatus.Visible = false;
                    cmdOk.Visible = true;
                    tbxInfo.Visible = false;
                    tbxMessages.Visible = true;

                    lblStatusMessage.Text = "Finished with "
                                            + e.Status.ToString().TokenizeWhenCharIsUpper().ToDelimiteredString();

                    tbxMessages.Text = "";

                    foreach (var logEntry in e.Messages)
                        tbxMessages.Text += string.Format("{0}\r\n", logEntry.Message);
                    
                    cmdOk.Focus();
                });
        }

        public void UpdateStatus(object sender, PipelineStepInfoEventArgs e)
        {
            this.CrossThreadSafe(() =>
                    {
                        pgbStatus.Value = e.ProgressPercentage;
                        lblStatusMessage.Text = e.StepName.TokenizeWhenCharIsUpper().ToDelimiteredString();
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
