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
      Services.PipelineWorker.StepExecuting += UpdateStatus;
    }

    public void Ended(object sender, PipelineEventArgs e)
    {
      this.CrossThreadSafe(() =>
      {
        picWaitingAni.Hide();
        btnOk.Show();
        btnOk.Focus();
      });
      
    }

    public void Starting(object sender, PipelineEventArgs e)
    {
      this.CrossThreadSafe(() =>
      {
        this.BringToFront();
        this.Show();
        btnOk.Hide();
        picWaitingAni.Show();
        lblTitle.Text = e.PipelineName.ToSpaceDelimiteredString();
      });
    }

    private void siButton1_Click(object sender, EventArgs e)
    {
      this.SendToBack();
      this.Hide();
    }

    public void UpdateStatus(object sender, PipelineStepInfoEventArgs e)
    {
      this.CrossThreadSafe(() =>
      {
        lblStatusMessage.Text = e.StepName.ToSpaceDelimiteredString();
      });
    }
  }
}
