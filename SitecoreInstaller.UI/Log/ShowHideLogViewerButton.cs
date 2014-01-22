using System;
using System.ComponentModel;
using System.Windows.Forms;
using CSharp.Basics.Sys;
using SitecoreInstaller.App;
using SitecoreInstaller.Framework.Diagnostics;
using SitecoreInstaller.Framework.Sys;
using SitecoreInstaller.UI.Forms;
using SitecoreInstaller.UI.Viewport;

namespace SitecoreInstaller.UI.Log
{
    public class ShowHideLogViewerButton : SIButton
    {
        private readonly Timer _timer;

        private const string _toolTipWhenVisible = "Hide Log viewer";
        private const string _toolTipWhenNotVisible = "Show Log viewer";

        public ShowHideLogViewerButton()
        {
            Image = LogResources.Log;
            FlatAppearance.BorderSize = 0;
            this.Click += this.ShowHideLogViewerButton_Click;
            _timer = new Timer
            {
                Interval = 1000
            };
            _timer.Tick += _timer_Tick;
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            if (Services.PipelineWorker.IsBusy() == false)
                PipelineWorker_WorkerCompleted(sender, new RunWorkerCompletedEventArgs(null, null, false));
        }

        public LogViewer LogViewer { get; private set; }

        public void Init(LogViewer logViewer, ToolTip toolTip = null)
        {
            if (logViewer == null) { throw new ArgumentNullException("logViewer"); }
            LogViewer = logViewer;
            Init(toolTip);
            SetToolTip(_toolTipWhenNotVisible);
            Framework.Diagnostics.Log.ToApp.LogCleared += This_LogCleared;
            Framework.Diagnostics.Log.ToApp.EntryLogged += This_EntryLogged;
            Services.PipelineWorker.AllStepsExecuting += PipelineWorker_AllStepsExecuting;
            Services.PipelineWorker.WorkerCompleted += PipelineWorker_WorkerCompleted;
            _timer.Start();
        }

        void PipelineWorker_WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Framework.Diagnostics.Log.ToApp.Status == LogStatus.NoProblems)
                Image = LogResources.Log;
            else
                Image = LogResources.Log_error;
        }

        void PipelineWorker_AllStepsExecuting(object sender, Domain.Pipelines.PipelineInfoEventArgs e)
        {
            Image = LogResources.Log_active;
        }

        private void This_EntryLogged(object sender, GenericEventArgs<LogEntry> e)
        {
            switch (e.Arg.LogType)
            {
                case LogType.Error:
                case LogType.Warning:
                    Image = LogResources.Log_error_active;
                    break;
            }
        }

        private void This_LogCleared(object sender, EventArgs e)
        {
            if (Services.PipelineWorker.IsBusy())
                Image = LogResources.Log_active;
            else
                Image = LogResources.Log;
        }

        private void ShowHideLogViewerButton_Click(object sender, EventArgs e)
        {
            var visible = ViewportStack.OpenOrCloseDependingOnCurrentState(LogViewer);
            if (visible)
                base.SetToolTip(_toolTipWhenVisible);
            else
                base.SetToolTip(_toolTipWhenNotVisible);
        }
    }
}
