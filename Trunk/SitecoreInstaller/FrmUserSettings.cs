using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SitecoreInstaller
{
    using SitecoreInstaller.Domain.Pipelines;
    using SitecoreInstaller.UI;
    using SitecoreInstaller.UI.UserSettingsDialogs;

    public partial class FrmUserSettings : Form
    {
        public FrmUserSettings()
        {
            InitializeComponent();
            StepWizard = new StepWizard();
            foreach (var step in StepWizard)
            {
                step.Top = 0;
                step.Left = 0;
                step.Dock = DockStyle.Fill;
                Controls.Add(step);
            }
        }

        public StepWizard StepWizard { get; private set; }

        public void Init()
        {
            pipelineProgress1.Hide();
            StepWizard.Init();
        }

        public PipelineProgress PipelineProgress { get { return pipelineProgress1; } }

        public void PipelineWorkerOnAllStepsExecuting(object sender, PipelineEventArgs e)
        {
            if (InvokeRequired)
            {
                EventHandler<PipelineEventArgs> inv = PipelineWorkerOnAllStepsExecuting;
                Invoke(inv, new[] { sender, e });
            }
            else
            {
                pipelineProgress1.BringToFront();
                pipelineProgress1.Top = 0;
                pipelineProgress1.Left = 100;
                pipelineProgress1.Width = 300;
                pipelineProgress1.Height = Height;
                pipelineProgress1.Show();
            }
        }
        public void PipelineWorkerOnAllStepsExecuted(object sender, PipelineEventArgs eventArgs)
        {
            if (InvokeRequired)
            {
                EventHandler<PipelineEventArgs> inv = PipelineWorkerOnAllStepsExecuted;
                Invoke(inv, new[] { sender, eventArgs });
            }
            else
            {
                pipelineProgress1.Hide();
            }
        }
    }
}
