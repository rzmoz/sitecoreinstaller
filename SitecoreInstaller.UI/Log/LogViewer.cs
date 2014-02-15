using System;
using System.Collections.Generic;
using System.Drawing;
using CSharp.Basics.Forms;
using CSharp.Basics.Forms.Viewport;
using CSharp.Basics.Sys;

namespace SitecoreInstaller.UI.Log
{
    using App;
    using Domain.Pipelines;
    using Framework.Diagnostics;

    public partial class LogViewer : BasicsUserControl
    {
        private IDictionary<LogType, Color> _colors;

        public LogViewer()
        {
            InitializeComponent();
            chkFollowLogTrail.ForeColor = Styles.Fonts.DarkBg.Colors.Text;
        }
        public void Init()
        {
            BackColor = Styles.Controls.BackColor;
            Services.PipelineEngine.AllStepsExecuting += PipelineWorker_AllStepsExecuting;
            _colors = new Dictionary<LogType, Color>
                {
                    { LogType.Debug, Color.DarkGray },
                    { LogType.Info, Color.Black },
                    { LogType.Warning, Color.Blue },
                    { LogType.Error, Color.Red },
                    { LogType.Profiling, Color.Green }
                };
            chkFollowLogTrail.Checked = true;
            Log.ToApp.Flush();
            Log.ToApp.EntryLogged += EntryLogged;
            Log.ToApp.LogCleared += Clear;
        }

        private void EntryLogged(object sender, GenericEventArgs<LogEntry> e)
        {
            this.CrossThreadSafe(() =>
            {
                rtbLog.SelectionColor = _colors[e.Arg.LogType];
                rtbLog.AppendText(e.Arg + Environment.NewLine);

                if (chkFollowLogTrail.Checked)
                    chkFollowLogTrail_CheckedChanged(this, new EventArgs());
            });
        }

        void PipelineWorker_AllStepsExecuting(object sender, PipelineInfoEventArgs e)
        {
            this.CrossThreadSafe(() => Clear(sender, e));
        }

        public void Clear(object sender, EventArgs e)
        {
            this.CrossThreadSafe(() => rtbLog.Text = string.Empty);
        }

        private void chkFollowLogTrail_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkFollowLogTrail.Checked)
                return;
            rtbLog.SelectionStart = rtbLog.Text.Length;
            rtbLog.ScrollToCaret();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Log.ToApp.Reset();
        }
    }
}
