﻿namespace SitecoreInstaller.UI
{
  using SitecoreInstaller.UI.Forms;

  partial class MainCtrl
  {
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.pnlFooter = new System.Windows.Forms.Panel();
      this.pnlHeader = new System.Windows.Forms.Panel();
      this.pnlContent = new System.Windows.Forms.Panel();
      this.mainDeveloper1 = new SitecoreInstaller.UI.MainDeveloper();
      this.progressCtrl1 = new SitecoreInstaller.UI.Processing.ProgressCtrl();
      this.logViewer1 = new SitecoreInstaller.UI.Log.LogViewer();
      this.btnViewLog = new SitecoreInstaller.UI.Forms.SIButton();
      this.pnlFooter.SuspendLayout();
      this.pnlContent.SuspendLayout();
      this.SuspendLayout();
      // 
      // pnlFooter
      // 
      this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(46)))));
      this.pnlFooter.Controls.Add(this.btnViewLog);
      this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.pnlFooter.Location = new System.Drawing.Point(0, 400);
      this.pnlFooter.Name = "pnlFooter";
      this.pnlFooter.Size = new System.Drawing.Size(800, 50);
      this.pnlFooter.TabIndex = 2;
      // 
      // pnlHeader
      // 
      this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(46)))));
      this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnlHeader.Location = new System.Drawing.Point(0, 0);
      this.pnlHeader.Name = "pnlHeader";
      this.pnlHeader.Size = new System.Drawing.Size(800, 30);
      this.pnlHeader.TabIndex = 3;
      // 
      // pnlContent
      // 
      this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(69)))), ((int)(((byte)(79)))));
      this.pnlContent.Controls.Add(this.mainDeveloper1);
      this.pnlContent.Controls.Add(this.progressCtrl1);
      this.pnlContent.Controls.Add(this.logViewer1);
      this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlContent.Location = new System.Drawing.Point(0, 30);
      this.pnlContent.Name = "pnlContent";
      this.pnlContent.Size = new System.Drawing.Size(800, 370);
      this.pnlContent.TabIndex = 1;
      // 
      // mainDeveloper1
      // 
      this.mainDeveloper1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mainDeveloper1.Location = new System.Drawing.Point(0, 0);
      this.mainDeveloper1.Name = "mainDeveloper1";
      this.mainDeveloper1.Size = new System.Drawing.Size(800, 370);
      this.mainDeveloper1.TabIndex = 7;
      // 
      // progressCtrl1
      // 
      this.progressCtrl1.BackColor = System.Drawing.Color.White;
      this.progressCtrl1.Location = new System.Drawing.Point(-3, 1);
      this.progressCtrl1.Name = "progressCtrl1";
      this.progressCtrl1.Size = new System.Drawing.Size(800, 370);
      this.progressCtrl1.TabIndex = 6;
      // 
      // logViewer1
      // 
      this.logViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.logViewer1.Location = new System.Drawing.Point(0, 187);
      this.logViewer1.Name = "logViewer1";
      this.logViewer1.Size = new System.Drawing.Size(800, 184);
      this.logViewer1.TabIndex = 0;
      this.logViewer1.TabStop = false;
      // 
      // btnViewLog
      // 
      this.btnViewLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnViewLog.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnViewLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnViewLog.Font = new System.Drawing.Font("Segoe UI", 8F);
      this.btnViewLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnViewLog.Image = global::SitecoreInstaller.UI.Properties.Resources.Log;
      this.btnViewLog.Location = new System.Drawing.Point(760, 13);
      this.btnViewLog.Name = "btnViewLog";
      this.btnViewLog.Size = new System.Drawing.Size(25, 25);
      this.btnViewLog.TabIndex = 0;
      this.btnViewLog.TabStop = false;
      this.btnViewLog.UseVisualStyleBackColor = true;
      this.btnViewLog.Click += new System.EventHandler(this.btnViewLog_Click);
      // 
      // MainCtrl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.pnlContent);
      this.Controls.Add(this.pnlFooter);
      this.Controls.Add(this.pnlHeader);
      this.Name = "MainCtrl";
      this.Size = new System.Drawing.Size(800, 450);
      this.Load += new System.EventHandler(this.MainCtrl_Load);
      this.pnlFooter.ResumeLayout(false);
      this.pnlContent.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel pnlFooter;
    private System.Windows.Forms.Panel pnlHeader;
    private System.Windows.Forms.Panel pnlContent;
    private Processing.ProgressCtrl progressCtrl1;
    private MainDeveloper mainDeveloper1;
    private Log.LogViewer logViewer1;
    private SIButton btnViewLog;
  }
}
