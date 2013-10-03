﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SitecoreInstaller.UI.Log
{
  using SitecoreInstaller.App;
  using SitecoreInstaller.Domain.Pipelines;
  using SitecoreInstaller.Framework.Diagnostics;
  using SitecoreInstaller.Framework.Sys;
  using SitecoreInstaller.UI.Viewport;

  public partial class LogViewer : SIUserControl
  {
    private IDictionary<LogType, Color> _colors;

    public LogViewer()
    {
      InitializeComponent();
      this.BackColor = Styles.Controls.BackColor;
      chkFollowLogTrail.ForeColor = Styles.Fonts.DarkBg.Colors.Text;
    }
    public void Init()
    {
      Log.This.EntryLogged += EntryLogged;
      Log.This.LogCleared += this.Clear;
      Services.PipelineWorker.AllStepsExecuting += PipelineWorker_AllStepsExecuting;
      _colors = new Dictionary<LogType, Color>
                {
                    { LogType.Debug, Color.DarkGray },
                    { LogType.Info, Color.Black },
                    { LogType.Warning, Color.Blue },
                    { LogType.Error, Color.Red },
                    { LogType.Profiling, Color.Green }
                };
      chkFollowLogTrail.Checked = true;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);

      var graphics = this.CreateGraphics();

      var myPen = new Pen(Color.White)
      {
        Width = 2
      };

      graphics.DrawLine(myPen, 0, 0, this.Width, 0);
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
      this.CrossThreadSafe(() => this.Clear(sender, e));
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
      Log.This.Reset();
    }
  }
}
