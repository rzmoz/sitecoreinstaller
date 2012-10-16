using System;
using System.Windows.Forms;
using SitecoreInstaller.Domain.Pipelines;


namespace SitecoreInstaller.UI
{
    using System.Drawing;

    using SitecoreInstaller.App;
    using SitecoreInstaller.Framework.Diagnostics;
    using SitecoreInstaller.Framework.System;
    using SitecoreInstaller.UI.Properties;

    public partial class PipelineStatus : UserControl
    {
        public PipelineStatus()
        {
            InitializeComponent();
        }

        public void Init()
        {
            Log.As.EntryLogged += UpdateInfo;
            Services.PipelineWorker.StepExecuting += UpdateStatus;
        }

        public void Starting(object sender, PipelineEventArgs e)
        {
            this.CrossThreadSafe(() =>
                {
                    lblTitle.Text = e.PipelineName.ToSpaceDelimiteredString();
                    pgbStatus.Visible = true;
                    cmdOk.Visible = false;
                    tbxInfo.Visible = true;
                    tbxMessages.Visible = false;
                    picStatus.Visible = false;
                });
        }
        public void Ended(object sender, PipelineEventArgs e)
        {
            this.CrossThreadSafe(() =>
                {
                    pgbStatus.Visible = false;
                    cmdOk.Visible = true;
                    tbxInfo.Visible = false;

                    picStatus.Visible = true;
                    switch (e.Status)
                    {
                        case Domain.Pipelines.PipelineStatus.NoProblems:
                            picStatus.Image = Resources.ok;
                            break;
                        case Domain.Pipelines.PipelineStatus.Warnings:
                            picStatus.Image = Resources.warning;
                            break;
                        case Domain.Pipelines.PipelineStatus.Errors:
                            picStatus.Image = Resources.error;
                            break;
                    }

                    if (e.Status != Domain.Pipelines.PipelineStatus.NoProblems)
                    {
                        tbxMessages.Visible = true;
                        tbxMessages.Text = "";
                        foreach (var logEntry in e.Messages)
                            tbxMessages.Text += string.Format("{0}{1}", logEntry.Message, Environment.NewLine);

                    }


                    lblStatusMessage.Text = "Finished with "
                                            + e.Status.ToString().ToSpaceDelimiteredString();

                    cmdOk.Focus();
                });
        }

        public void UpdateStatus(object sender, PipelineStepInfoEventArgs e)
        {
            this.CrossThreadSafe(() =>
                    {
                        pgbStatus.Value = e.ProgressPercentage;
                        lblStatusMessage.Text = e.StepName.ToSpaceDelimiteredString();
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
