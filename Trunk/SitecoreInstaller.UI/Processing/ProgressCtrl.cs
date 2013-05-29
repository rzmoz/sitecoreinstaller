using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SitecoreInstaller.UI.Processing
{
  using SitecoreInstaller.App;
  using SitecoreInstaller.Domain.Pipelines;
  using SitecoreInstaller.Framework.Diagnostics;
  using SitecoreInstaller.Framework.System;
  using SitecoreInstaller.UI.Viewport;

  public partial class ProgressCtrl : SIUserControl
  {
    public ProgressCtrl()
    {
      InitializeComponent();
    }

    private void ProgressCtrl_Load(object sender, EventArgs e)
    {
      Log.This.EntryLogged += UpdateInfo;
      Services.PipelineWorker.StepExecuting += UpdateStatus;
    }

    private void siButton1_Click(object sender, EventArgs e)
    {
      ViewportStack.Hide(this);
      Log.This.Clear();
    }

    public void Starting(object sender, PipelineEventArgs e)
    {
      this.CrossThreadSafe(() =>
      {
        ViewportStack.Show(this);
        imgStatus.Hide();
        lblTitle.Text = e.PipelineName;
        picWaitAnimation.Show();
        btnOk.Hide();
        lblStatusMessage.Show();
        lblInfo.Show();
      });
    }

    public void Ended(object sender, RunWorkerCompletedEventArgs e)
    {
      this.CrossThreadSafe(() =>
      {
        lblInfo.Hide();
        picWaitAnimation.Hide();
        imgStatus.Show();
        btnOk.Show();
        btnOk.Focus();

        var logStatus = Log.This.Status;

        lblStatusMessage.Text = "Finished with " + logStatus.ToString().ToSpaceDelimiteredString().ToLower();

        switch (logStatus)
        {
          case LogStatus.NoProblems:
            imgStatus.Image = ProgressResources.Status_Ok;
            break;
          case LogStatus.Warnings:
          case LogStatus.Errors:
            imgStatus.Image = ProgressResources.Status_Error;
            lblStatusMessage.Text += ". Click to view log for details =>";
            break;
        }

        imgStatus.Left = lblStatusMessage.Right + 10;
      });
    }

    public void UpdateStatus(object sender, PipelineStepInfoEventArgs e)
    {
      this.CrossThreadSafe(() =>
      {
        lblStatusMessage.Text = string.Format("We're at step {0} of {1} : {2}", e.StepNumber, e.TotalStepCount, e.StepName);
      });
    }

    public void UpdateInfo(object sender, GenericEventArgs<LogEntry> e)
    {
      this.CrossThreadSafe(() =>
      {
        if (e == null)
          return;
        if (e.Arg == null)
          return;
        if (e.Arg.LogType == LogType.Info)
          lblInfo.Text = e.Arg.Message;
      });
    }

    private void imgStatus_Click(object sender, EventArgs e)
    {
      //I don't really like this. Thought the coupling is loose, it's still there. The progress control is referencing the logviwer control :-/
      ViewportStack.Show("SitecoreInstaller.UI.Log.LogViewer");
    }
  }
}
