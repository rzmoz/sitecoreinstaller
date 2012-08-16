using System;
using System.Drawing;
using System.Windows.Forms;

namespace SitecoreInstaller.UI
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SitecoreInstaller.App;
    using SitecoreInstaller.Domain.Pipelines;
    using SitecoreInstaller.Framework.Diagnostics;
    using SitecoreInstaller.Framework.System;
    using SitecoreInstaller.UI.Properties;

    public partial class Logger : UserControl
    {
        private IDictionary<LogType, Color> _colors;

        public Logger()
        {
            InitializeComponent();
        }

        public void Init()
        {
            chkDebug.Checked = UiUserSettings.Default.ShowDebug;
            chkInfo.Checked = UiUserSettings.Default.ShowInfo;
            chkWarning.Checked = UiUserSettings.Default.ShowWarning;
            chkError.Checked = UiUserSettings.Default.ShowError;
            chkProfiling.Checked = UiUserSettings.Default.ShowProfiling;
            Log.It.EntryLogged += EntryLogged;
            Log.It.LogCleared += ClearLog;
            Services.PipelineWorker.AllStepsExecuting += PipelineWorker_AllStepsExecuting;
            _colors = new Dictionary<LogType, Color>
                {
                    { LogType.Debug, Color.DarkGray },
                    { LogType.Info, Color.Black },
                    { LogType.Warning, Color.Blue },
                    { LogType.Error, Color.Red },
                    { LogType.Profiling, Color.Green }
                };
        }

        void PipelineWorker_AllStepsExecuting(object sender, PipelineEventArgs e)
        {
            if (InvokeRequired)
            {
                EventHandler<PipelineEventArgs> inv = PipelineWorker_AllStepsExecuting;
                Invoke(inv, new[] { sender, e });
            }
            else
            {
                ClearLog(sender, e);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var color = Color.FromArgb(211, 211, 227);
            var pen = new Pen(color, 1);
            e.Graphics.DrawLine(pen, 0, 0, Width, 0);
        }

        private bool _showLogLevels;
        public bool ShowLogLevels
        {
            get { return _showLogLevels; }
            set
            {
                _showLogLevels = value;
                chkDebug.Visible = _showLogLevels;
                chkInfo.Visible = _showLogLevels;
                chkWarning.Visible = _showLogLevels;
                chkError.Visible = _showLogLevels;
                chkProfiling.Visible = _showLogLevels;
            }
        }

        private void EntryLogged(object sender, GenericEventArgs<LogEntry> e)
        {
            if (InvokeRequired)
            {
                EventHandler<GenericEventArgs<LogEntry>> inv = EntryLogged;
                Invoke(inv, new[] { sender, e });
            }
            else
            {
                rteEventLog.SelectionColor = _colors[e.Arg.LogType];

                if (LogEntry(e))
                {
                    rteEventLog.AppendText(e.Arg + "\r\n");

                    if (chkFollowLogTrail.Checked)
                        chkFollowLogTrail_CheckedChanged(this, new EventArgs());
                }
            }
        }

        private bool LogEntry(GenericEventArgs<LogEntry> e)
        {
            if (e.Arg.LogType == LogType.Debug && UiUserSettings.Default.ShowDebug)
                return true;
            if (e.Arg.LogType == LogType.Info && UiUserSettings.Default.ShowInfo)
                return true;
            if (e.Arg.LogType == LogType.Warning && UiUserSettings.Default.ShowWarning)
                return true;
            if (e.Arg.LogType == LogType.Error && UiUserSettings.Default.ShowError)
                return true;
            if (e.Arg.LogType == LogType.Profiling && UiUserSettings.Default.ShowProfiling)
                return true;
            return false;
        }


        private void ClearLog(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                EventHandler inv = ClearLog;
                Invoke(inv, new[] { sender, e });
            }
            else
            {
                rteEventLog.Text = string.Empty;
            }
        }
        private void chkFollowLogTrail_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkFollowLogTrail.Checked)
                return;
            rteEventLog.SelectionStart = rteEventLog.Text.Length;
            rteEventLog.ScrollToCaret();
        }

        private void chkDebug_CheckedChanged(object sender, EventArgs e)
        {
            UiUserSettings.Default.ShowDebug = chkDebug.Checked;
            UiUserSettings.Default.Save();
        }

        private void chkInfo_CheckedChanged(object sender, EventArgs e)
        {
            UiUserSettings.Default.ShowInfo = chkInfo.Checked;
            UiUserSettings.Default.Save();
        }

        private void chkWarning_CheckedChanged(object sender, EventArgs e)
        {
            UiUserSettings.Default.ShowWarning = chkWarning.Checked;
            UiUserSettings.Default.Save();
        }

        private void chkError_CheckedChanged(object sender, EventArgs e)
        {
            UiUserSettings.Default.ShowError = chkError.Checked;
            UiUserSettings.Default.Save();
        }

        private void chkProfiling_CheckedChanged(object sender, EventArgs e)
        {
            UiUserSettings.Default.ShowProfiling = chkProfiling.Checked;
            UiUserSettings.Default.Save();
        }
    }
}
