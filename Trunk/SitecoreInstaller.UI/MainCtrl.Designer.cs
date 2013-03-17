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
      this.pnlFooter = new System.Windows.Forms.Panel();
      this.pnlHeader = new System.Windows.Forms.Panel();
      this.pnlContent = new System.Windows.Forms.Panel();
      this.selectProjectName1 = new SitecoreInstaller.UI.SelectProjectName();
      this.selectSitecore1 = new SitecoreInstaller.UI.SelectSitecore();
      this.selectLicense1 = new SitecoreInstaller.UI.SelectLicense();
      this.selectModules1 = new SitecoreInstaller.UI.SelectModules();
      this.btnInstall = new SIButton();
      this.btnUninstall = new SIButton();
      this.progressCtrl1 = new SitecoreInstaller.UI.Processing.ProgressCtrl();
      this.pnlContent.SuspendLayout();
      this.SuspendLayout();
      // 
      // pnlFooter
      // 
      this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(46)))));
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
      this.pnlContent.Controls.Add(this.btnUninstall);
      this.pnlContent.Controls.Add(this.btnInstall);
      this.pnlContent.Controls.Add(this.selectProjectName1);
      this.pnlContent.Controls.Add(this.selectSitecore1);
      this.pnlContent.Controls.Add(this.selectLicense1);
      this.pnlContent.Controls.Add(this.selectModules1);
      this.pnlContent.Controls.Add(this.progressCtrl1);
      this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlContent.Location = new System.Drawing.Point(0, 30);
      this.pnlContent.Name = "pnlContent";
      this.pnlContent.Size = new System.Drawing.Size(800, 370);
      this.pnlContent.TabIndex = 1;
      // 
      // selectProjectName1
      // 
      this.selectProjectName1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
      this.selectProjectName1.Location = new System.Drawing.Point(3, 0);
      this.selectProjectName1.Name = "selectProjectName1";
      this.selectProjectName1.ProjectName = "";
      this.selectProjectName1.Size = new System.Drawing.Size(400, 50);
      this.selectProjectName1.TabIndex = 0;
      // 
      // selectSitecore1
      // 
      this.selectSitecore1.Location = new System.Drawing.Point(3, 42);
      this.selectSitecore1.Name = "selectSitecore1";
      this.selectSitecore1.Size = new System.Drawing.Size(400, 50);
      this.selectSitecore1.TabIndex = 1;
      // 
      // selectLicense1
      // 
      this.selectLicense1.Location = new System.Drawing.Point(3, 89);
      this.selectLicense1.Name = "selectLicense1";
      this.selectLicense1.Size = new System.Drawing.Size(400, 50);
      this.selectLicense1.TabIndex = 2;
      // 
      // selectModules1
      // 
      this.selectModules1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.selectModules1.Location = new System.Drawing.Point(3, 136);
      this.selectModules1.Name = "selectModules1";
      this.selectModules1.Size = new System.Drawing.Size(400, 231);
      this.selectModules1.TabIndex = 3;
      // 
      // btnInstall
      // 
      this.btnInstall.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnInstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnInstall.Font = new System.Drawing.Font("Segoe UI", 8F);
      this.btnInstall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnInstall.Location = new System.Drawing.Point(409, 173);
      this.btnInstall.Name = "btnInstall";
      this.btnInstall.Size = new System.Drawing.Size(75, 23);
      this.btnInstall.TabIndex = 4;
      this.btnInstall.Text = "Install";
      this.btnInstall.UseVisualStyleBackColor = true;
      this.btnInstall.Click += new System.EventHandler(this.siButton1_Click);
      // 
      // btnUninstall
      // 
      this.btnUninstall.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnUninstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnUninstall.Font = new System.Drawing.Font("Segoe UI", 8F);
      this.btnUninstall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnUninstall.Location = new System.Drawing.Point(410, 203);
      this.btnUninstall.Name = "btnUninstall";
      this.btnUninstall.Size = new System.Drawing.Size(75, 23);
      this.btnUninstall.TabIndex = 5;
      this.btnUninstall.Text = "Uninstall";
      this.btnUninstall.UseVisualStyleBackColor = true;
      this.btnUninstall.Click += new System.EventHandler(this.btnUninstall_Click);
      // 
      // progressCtrl1
      // 
      this.progressCtrl1.Location = new System.Drawing.Point(-3, 1);
      this.progressCtrl1.Name = "progressCtrl1";
      this.progressCtrl1.Size = new System.Drawing.Size(800, 370);
      this.progressCtrl1.TabIndex = 6;
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
      this.pnlContent.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel pnlFooter;
    private System.Windows.Forms.Panel pnlHeader;
    private SelectModules selectModules1;
    private SelectLicense selectLicense1;
    private SelectSitecore selectSitecore1;
    private SelectProjectName selectProjectName1;
    private System.Windows.Forms.Panel pnlContent;
    private SIButton btnInstall;
    private SIButton btnUninstall;
    private Processing.ProgressCtrl progressCtrl1;
  }
}
