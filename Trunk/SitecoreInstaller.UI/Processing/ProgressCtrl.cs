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

  public partial class ProgressCtrl : UserControl
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
      this.SendToBack();
      this.Hide();
    }

    public void Starting(object sender, PipelineEventArgs e)
    {
      this.CrossThreadSafe(() =>
      {
        this.BringToFront();
        this.Show();
        btnOk.Hide();
        lblProgress.Show();
        lblTitle.Text = e.PipelineName.ToSpaceDelimiteredString();
        picWaitAnimation.Show();
      });
    }

    public void Ended(object sender, PipelineEventArgs e)
    {
      this.CrossThreadSafe(() =>
      {
        lblProgress.Hide();
        btnOk.Show();
        btnOk.Focus();
        picWaitAnimation.Hide();
      });
    }

    public void UpdateStatus(object sender, PipelineStepInfoEventArgs e)
    {
      this.CrossThreadSafe(() =>
      {
        lblProgress.Text = string.Format("Executing step {0} of {1}", e.StepNumber, e.TotalStepCount);
        lblStatusMessage.Text = e.StepName.ToSpaceDelimiteredString();
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
  }
}
