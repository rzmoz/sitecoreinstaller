namespace SitecoreInstaller.UI
{
  partial class MainSimple
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
      this.installCtrl1 = new SitecoreInstaller.UI.Simple.InstallCtrl();
      this.openSiteCtrl1 = new SitecoreInstaller.UI.Simple.OpenSiteCtrl();
      this.btnOpenSite = new SitecoreInstaller.UI.Forms.SIButton();
      this.btnUninstall = new SitecoreInstaller.UI.Forms.SIButton();
      this.btnInstall = new SitecoreInstaller.UI.Forms.SIButton();
      this.uninstallCtrl1 = new SitecoreInstaller.UI.Simple.UninstallCtrl();
      this.SuspendLayout();
      // 
      // installCtrl1
      // 
      this.installCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.installCtrl1.Location = new System.Drawing.Point(0, 0);
      this.installCtrl1.Name = "installCtrl1";
      this.installCtrl1.Size = new System.Drawing.Size(500, 300);
      this.installCtrl1.TabIndex = 4;
      this.installCtrl1.TabStop = false;
      this.installCtrl1.Visible = false;
      // 
      // openSiteCtrl1
      // 
      this.openSiteCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.openSiteCtrl1.Location = new System.Drawing.Point(0, 0);
      this.openSiteCtrl1.Name = "openSiteCtrl1";
      this.openSiteCtrl1.Size = new System.Drawing.Size(500, 300);
      this.openSiteCtrl1.TabIndex = 3;
      this.openSiteCtrl1.TabStop = false;
      this.openSiteCtrl1.Visible = false;
      // 
      // btnOpenSite
      // 
      this.btnOpenSite.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnOpenSite.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnOpenSite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnOpenSite.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnOpenSite.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnOpenSite.Location = new System.Drawing.Point(348, 92);
      this.btnOpenSite.Name = "btnOpenSite";
      this.btnOpenSite.Size = new System.Drawing.Size(100, 100);
      this.btnOpenSite.TabIndex = 2;
      this.btnOpenSite.UseVisualStyleBackColor = true;
      this.btnOpenSite.Click += new System.EventHandler(this.btnOpenSite_Click);
      // 
      // btnUninstall
      // 
      this.btnUninstall.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnUninstall.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnUninstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnUninstall.Font = new System.Drawing.Font("Segoe UI", 8F);
      this.btnUninstall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnUninstall.Location = new System.Drawing.Point(189, 92);
      this.btnUninstall.Name = "btnUninstall";
      this.btnUninstall.Size = new System.Drawing.Size(100, 100);
      this.btnUninstall.TabIndex = 1;
      this.btnUninstall.UseVisualStyleBackColor = true;
      this.btnUninstall.Click += new System.EventHandler(this.btnUninstall_Click);
      // 
      // btnInstall
      // 
      this.btnInstall.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnInstall.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnInstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnInstall.Font = new System.Drawing.Font("Segoe UI", 8F);
      this.btnInstall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnInstall.Location = new System.Drawing.Point(32, 92);
      this.btnInstall.Name = "btnInstall";
      this.btnInstall.Size = new System.Drawing.Size(100, 100);
      this.btnInstall.TabIndex = 0;
      this.btnInstall.UseVisualStyleBackColor = true;
      this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
      // 
      // uninstallCtrl1
      // 
      this.uninstallCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.uninstallCtrl1.Location = new System.Drawing.Point(0, 0);
      this.uninstallCtrl1.Name = "uninstallCtrl1";
      this.uninstallCtrl1.Size = new System.Drawing.Size(500, 300);
      this.uninstallCtrl1.TabIndex = 9;
      this.uninstallCtrl1.TabStop = false;
      this.uninstallCtrl1.Visible = false;
      // 
      // MainSimple
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.btnOpenSite);
      this.Controls.Add(this.btnUninstall);
      this.Controls.Add(this.btnInstall);
      this.Controls.Add(this.openSiteCtrl1);
      this.Controls.Add(this.installCtrl1);
      this.Controls.Add(this.uninstallCtrl1);
      this.Name = "MainSimple";
      this.Size = new System.Drawing.Size(500, 300);
      this.Resize += new System.EventHandler(this.MainSimple_Resize);
      this.ResumeLayout(false);

    }

    #endregion

    private Simple.OpenSiteCtrl openSiteCtrl1;
    private Simple.InstallCtrl installCtrl1;
    private Forms.SIButton btnOpenSite;
    private Forms.SIButton btnUninstall;
    private Forms.SIButton btnInstall;
    private Simple.UninstallCtrl uninstallCtrl1;

  }
}
