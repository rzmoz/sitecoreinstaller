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
    }

    public void Starting(object sender, PipelineEventArgs e)
    {
      this.CrossThreadSafe(() =>
      {
        ViewportStack.Show(this);
        btnOk.Hide();
        lblTitle.Text = e.PipelineName;
        picWaitAnimation.Show();
      });
    }

    public void Ended(object sender, PipelineEventArgs e)
    {
      this.CrossThreadSafe(() =>
      {
        btnOk.Show();
        btnOk.Focus();
        picWaitAnimation.Hide();
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

    public override bool BlocksView
    {
      get { return true; }
    }
  }
}
