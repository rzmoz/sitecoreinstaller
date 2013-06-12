namespace SitecoreInstaller.UI
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainCtrl));
      this.pnlFooter = new System.Windows.Forms.Panel();
      this.showHidePreferenecsButton1 = new SitecoreInstaller.UI.Preferences.ShowHidePreferenecsButton();
      this.showHideLogViewerButton1 = new SitecoreInstaller.UI.Log.ShowHideLogViewerButton();
      this.pnlHeader = new System.Windows.Forms.Panel();
      this.pnlContent = new System.Windows.Forms.Panel();
      this.mainSimple1 = new SitecoreInstaller.UI.MainSimple();
      this.logViewer1 = new SitecoreInstaller.UI.Log.LogViewer();
      this.userPreferences1 = new SitecoreInstaller.UI.Preferences.UserPreferences();
      this.mainDeveloper1 = new SitecoreInstaller.UI.MainDeveloper();
      this.progressCtrl1 = new SitecoreInstaller.UI.Processing.ProgressCtrl();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.pnlFooter.SuspendLayout();
      this.pnlContent.SuspendLayout();
      this.SuspendLayout();
      // 
      // pnlFooter
      // 
      this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(46)))));
      this.pnlFooter.Controls.Add(this.showHidePreferenecsButton1);
      this.pnlFooter.Controls.Add(this.showHideLogViewerButton1);
      this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.pnlFooter.Location = new System.Drawing.Point(0, 400);
      this.pnlFooter.Name = "pnlFooter";
      this.pnlFooter.Size = new System.Drawing.Size(800, 50);
      this.pnlFooter.TabIndex = 2;
      // 
      // showHidePreferenecsButton1
      // 
      this.showHidePreferenecsButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.showHidePreferenecsButton1.BackColorSelected = System.Drawing.Color.Empty;
      this.showHidePreferenecsButton1.Cursor = System.Windows.Forms.Cursors.Hand;
      this.showHidePreferenecsButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.showHidePreferenecsButton1.FlatAppearance.BorderSize = 0;
      this.showHidePreferenecsButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.showHidePreferenecsButton1.Font = new System.Drawing.Font("Segoe UI", 8F);
      this.showHidePreferenecsButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.showHidePreferenecsButton1.ForeColorSelected = System.Drawing.Color.Empty;
      this.showHidePreferenecsButton1.Location = new System.Drawing.Point(13, 13);
      this.showHidePreferenecsButton1.Name = "showHidePreferenecsButton1";
      this.showHidePreferenecsButton1.Size = new System.Drawing.Size(25, 25);
      this.showHidePreferenecsButton1.TabIndex = 1;
      this.showHidePreferenecsButton1.UseVisualStyleBackColor = true;
      // 
      // showHideLogViewerButton1
      // 
      this.showHideLogViewerButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.showHideLogViewerButton1.Cursor = System.Windows.Forms.Cursors.Hand;
      this.showHideLogViewerButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.showHideLogViewerButton1.FlatAppearance.BorderSize = 0;
      this.showHideLogViewerButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.showHideLogViewerButton1.Font = new System.Drawing.Font("Segoe UI", 8F);
      this.showHideLogViewerButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.showHideLogViewerButton1.Image = ((System.Drawing.Image)(resources.GetObject("showHideLogViewerButton1.Image")));
      this.showHideLogViewerButton1.Location = new System.Drawing.Point(759, 13);
      this.showHideLogViewerButton1.Name = "showHideLogViewerButton1";
      this.showHideLogViewerButton1.Size = new System.Drawing.Size(25, 25);
      this.showHideLogViewerButton1.TabIndex = 0;
      this.showHideLogViewerButton1.TabStop = false;
      this.showHideLogViewerButton1.UseVisualStyleBackColor = true;
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
      this.pnlContent.Controls.Add(this.mainSimple1);
      this.pnlContent.Controls.Add(this.logViewer1);
      this.pnlContent.Controls.Add(this.userPreferences1);
      this.pnlContent.Controls.Add(this.mainDeveloper1);
      this.pnlContent.Controls.Add(this.progressCtrl1);
      this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlContent.Location = new System.Drawing.Point(0, 30);
      this.pnlContent.Name = "pnlContent";
      this.pnlContent.Size = new System.Drawing.Size(800, 370);
      this.pnlContent.TabIndex = 1;
      // 
      // mainSimple1
      // 
      this.mainSimple1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mainSimple1.Location = new System.Drawing.Point(0, 0);
      this.mainSimple1.Name = "mainSimple1";
      this.mainSimple1.Size = new System.Drawing.Size(800, 370);
      this.mainSimple1.TabIndex = 8;
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
      // userPreferences1
      // 
      this.userPreferences1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.userPreferences1.Location = new System.Drawing.Point(0, 0);
      this.userPreferences1.Name = "userPreferences1";
      this.userPreferences1.Size = new System.Drawing.Size(800, 370);
      this.userPreferences1.TabIndex = 9;
      this.userPreferences1.TabStop = false;
      // 
      // mainDeveloper1
      // 
      this.mainDeveloper1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mainDeveloper1.Location = new System.Drawing.Point(0, 0);
      this.mainDeveloper1.Name = "mainDeveloper1";
      this.mainDeveloper1.Size = new System.Drawing.Size(800, 370);
      this.mainDeveloper1.TabIndex = 0;
      // 
      // progressCtrl1
      // 
      this.progressCtrl1.BackColor = System.Drawing.Color.White;
      this.progressCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.progressCtrl1.Location = new System.Drawing.Point(0, 0);
      this.progressCtrl1.Name = "progressCtrl1";
      this.progressCtrl1.Size = new System.Drawing.Size(800, 370);
      this.progressCtrl1.TabIndex = 6;
      this.progressCtrl1.TabStop = false;
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
    private Log.ShowHideLogViewerButton showHideLogViewerButton1;
    private MainSimple mainSimple1;
    private Preferences.UserPreferences userPreferences1;
    private Preferences.ShowHidePreferenecsButton showHidePreferenecsButton1;
    private System.Windows.Forms.ToolTip toolTip1;
  }
}
