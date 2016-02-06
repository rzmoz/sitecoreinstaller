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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.progressCtrl1 = new SitecoreInstaller.UI.Processing.ProgressCtrl();
            this.mainSimple1 = new SitecoreInstaller.UI.MainSimple();
            this.sdnLogin1 = new SitecoreInstaller.UI.SDN.SdnLogin();
            this.logViewer1 = new SitecoreInstaller.UI.Log.LogViewer();
            this.userPreferences1 = new SitecoreInstaller.UI.Settings.UserSettings();
            this.mainDeveloper1 = new SitecoreInstaller.UI.MainDeveloper();
            this.showHideSettingsButton1 = new SitecoreInstaller.UI.Settings.ShowHideSettingsButton();
            this.showHideLogViewerButton1 = new SitecoreInstaller.UI.Log.ShowHideLogViewerButton();
            this.btnSdn = new SitecoreInstaller.UI.SDN.SdnLoginButton();
            this.pnlFooter.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(46)))));
            this.pnlFooter.Controls.Add(this.showHideSettingsButton1);
            this.pnlFooter.Controls.Add(this.showHideLogViewerButton1);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 400);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(800, 50);
            this.pnlFooter.TabIndex = 2;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(46)))));
            this.pnlHeader.Controls.Add(this.btnSdn);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(800, 30);
            this.pnlHeader.TabIndex = 3;
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(69)))), ((int)(((byte)(79)))));
            this.pnlContent.Controls.Add(this.progressCtrl1);
            this.pnlContent.Controls.Add(this.mainSimple1);
            this.pnlContent.Controls.Add(this.sdnLogin1);
            this.pnlContent.Controls.Add(this.logViewer1);
            this.pnlContent.Controls.Add(this.userPreferences1);
            this.pnlContent.Controls.Add(this.mainDeveloper1);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 30);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(800, 370);
            this.pnlContent.TabIndex = 1;
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
            // mainSimple1
            // 
            this.mainSimple1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSimple1.Location = new System.Drawing.Point(0, 0);
            this.mainSimple1.Name = "mainSimple1";
            this.mainSimple1.Size = new System.Drawing.Size(800, 370);
            this.mainSimple1.TabIndex = 8;
            // 
            // sdnLogin1
            // 
            this.sdnLogin1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sdnLogin1.Location = new System.Drawing.Point(0, 0);
            this.sdnLogin1.Name = "sdnLogin1";
            this.sdnLogin1.Size = new System.Drawing.Size(800, 370);
            this.sdnLogin1.TabIndex = 10;
            // 
            // logViewer1
            // 
            this.logViewer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(46)))));
            this.logViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logViewer1.Location = new System.Drawing.Point(0, 0);
            this.logViewer1.Name = "logViewer1";
            this.logViewer1.Size = new System.Drawing.Size(800, 370);
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
            // showHideSettingsButton1
            // 
            this.showHideSettingsButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.showHideSettingsButton1.BackColorSelected = System.Drawing.Color.Empty;
            this.showHideSettingsButton1.BottomDividerColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(46)))));
            this.showHideSettingsButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showHideSettingsButton1.DrawBottomDivider = false;
            this.showHideSettingsButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.showHideSettingsButton1.FlatAppearance.BorderSize = 0;
            this.showHideSettingsButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showHideSettingsButton1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.showHideSettingsButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.showHideSettingsButton1.ForeColorSelected = System.Drawing.Color.Empty;
            this.showHideSettingsButton1.Image = ((System.Drawing.Image)(resources.GetObject("showHideSettingsButton1.Image")));
            this.showHideSettingsButton1.ImageActive = ((System.Drawing.Image)(resources.GetObject("showHideSettingsButton1.ImageActive")));
            this.showHideSettingsButton1.Location = new System.Drawing.Point(13, 13);
            this.showHideSettingsButton1.Name = "showHideSettingsButton1";
            this.showHideSettingsButton1.Size = new System.Drawing.Size(25, 25);
            this.showHideSettingsButton1.TabIndex = 1;
            this.showHideSettingsButton1.ToolTipTextActive = "Open Settings";
            this.showHideSettingsButton1.ToolTipTextDeActive = "";
            this.showHideSettingsButton1.UseVisualStyleBackColor = true;
            // 
            // showHideLogViewerButton1
            // 
            this.showHideLogViewerButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.showHideLogViewerButton1.BottomDividerColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(46)))));
            this.showHideLogViewerButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showHideLogViewerButton1.DrawBottomDivider = false;
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
            // btnSdn
            // 
            this.btnSdn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSdn.BackColorSelected = System.Drawing.Color.Empty;
            this.btnSdn.BottomDividerColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(46)))));
            this.btnSdn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSdn.DrawBottomDivider = false;
            this.btnSdn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.btnSdn.FlatAppearance.BorderSize = 0;
            this.btnSdn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSdn.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnSdn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.btnSdn.ForeColorSelected = System.Drawing.Color.Empty;
            this.btnSdn.Image = ((System.Drawing.Image)(resources.GetObject("btnSdn.Image")));
            this.btnSdn.ImageActive = ((System.Drawing.Image)(resources.GetObject("btnSdn.ImageActive")));
            this.btnSdn.Location = new System.Drawing.Point(759, 2);
            this.btnSdn.Name = "btnSdn";
            this.btnSdn.Size = new System.Drawing.Size(25, 25);
            this.btnSdn.TabIndex = 0;
            this.btnSdn.ToolTipTextActive = null;
            this.btnSdn.ToolTipTextDeActive = null;
            this.btnSdn.UseVisualStyleBackColor = true;
            this.btnSdn.Visible = false;
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
            this.pnlFooter.ResumeLayout(false);
            this.pnlHeader.ResumeLayout(false);
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
    private Settings.UserSettings userPreferences1;
    private Settings.ShowHideSettingsButton showHideSettingsButton1;
    private System.Windows.Forms.ToolTip toolTip1;
    private SDN.SdnLoginButton btnSdn;
    private SDN.SdnLogin sdnLogin1;
  }
}
