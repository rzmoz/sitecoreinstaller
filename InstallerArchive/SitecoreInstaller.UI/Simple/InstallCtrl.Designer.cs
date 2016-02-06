namespace SitecoreInstaller.UI.Simple
{
  partial class InstallCtrl
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
      this.lblProjectName = new SitecoreInstaller.UI.Forms.SILabel();
      this.selectSitecore1 = new SitecoreInstaller.UI.UserSelections.SelectSitecore();
      this.btnBack = new SitecoreInstaller.UI.Forms.SIButton();
      this.btnInstall = new SitecoreInstaller.UI.Forms.SIButton();
      this.selectLicense1 = new SitecoreInstaller.UI.UserSelections.SelectLicense();
      this.tbxProjectName = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // lblProjectName
      // 
      this.lblProjectName.AutoSize = true;
      this.lblProjectName.Font = new System.Drawing.Font("Segoe UI", 10F);
      this.lblProjectName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.lblProjectName.Location = new System.Drawing.Point(50, 15);
      this.lblProjectName.Name = "lblProjectName";
      this.lblProjectName.Size = new System.Drawing.Size(92, 19);
      this.lblProjectName.TabIndex = 5;
      this.lblProjectName.Text = "Project name:";
      // 
      // selectSitecore1
      // 
      this.selectSitecore1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.selectSitecore1.Location = new System.Drawing.Point(50, 72);
      this.selectSitecore1.Name = "selectSitecore1";
      this.selectSitecore1.Size = new System.Drawing.Size(400, 50);
      this.selectSitecore1.TabIndex = 1;
      // 
      // btnBack
      // 
      this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnBack.Font = new System.Drawing.Font("Segoe UI", 8F);
      this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnBack.Location = new System.Drawing.Point(50, 231);
      this.btnBack.Name = "btnBack";
      this.btnBack.Size = new System.Drawing.Size(100, 50);
      this.btnBack.TabIndex = 4;
      this.btnBack.Text = "Back";
      this.btnBack.UseVisualStyleBackColor = true;
      this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
      // 
      // btnInstall
      // 
      this.btnInstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnInstall.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnInstall.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnInstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnInstall.Font = new System.Drawing.Font("Segoe UI", 8F);
      this.btnInstall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnInstall.Location = new System.Drawing.Point(350, 231);
      this.btnInstall.Name = "btnInstall";
      this.btnInstall.Size = new System.Drawing.Size(100, 50);
      this.btnInstall.TabIndex = 3;
      this.btnInstall.Text = "Install";
      this.btnInstall.UseVisualStyleBackColor = true;
      this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
      // 
      // selectLicense1
      // 
      this.selectLicense1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.selectLicense1.Location = new System.Drawing.Point(50, 139);
      this.selectLicense1.Name = "selectLicense1";
      this.selectLicense1.Size = new System.Drawing.Size(400, 50);
      this.selectLicense1.TabIndex = 2;
      // 
      // tbxProjectName
      // 
      this.tbxProjectName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbxProjectName.Location = new System.Drawing.Point(50, 36);
      this.tbxProjectName.Name = "tbxProjectName";
      this.tbxProjectName.Size = new System.Drawing.Size(400, 20);
      this.tbxProjectName.TabIndex = 0;
      // 
      // InstallCtrl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.lblProjectName);
      this.Controls.Add(this.selectSitecore1);
      this.Controls.Add(this.btnBack);
      this.Controls.Add(this.btnInstall);
      this.Controls.Add(this.selectLicense1);
      this.Controls.Add(this.tbxProjectName);
      this.Name = "InstallCtrl";
      this.Size = new System.Drawing.Size(500, 300);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox tbxProjectName;
    private UserSelections.SelectLicense selectLicense1;
    private Forms.SIButton btnBack;
    private Forms.SIButton btnInstall;
    private UserSelections.SelectSitecore selectSitecore1;
    private Forms.SILabel lblProjectName;
  }
}
