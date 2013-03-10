namespace SitecoreInstaller.UI
{
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
      this.selectModules1 = new SitecoreInstaller.UI.SelectModules();
      this.selectLicense1 = new SitecoreInstaller.UI.SelectLicense();
      this.selectSitecore1 = new SitecoreInstaller.UI.SelectSitecore();
      this.selectProjectName1 = new SitecoreInstaller.UI.SelectProjectName();
      this.pnlContent = new System.Windows.Forms.Panel();
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
      // selectModules1
      // 
      this.selectModules1.Location = new System.Drawing.Point(3, 147);
      this.selectModules1.Name = "selectModules1";
      this.selectModules1.Size = new System.Drawing.Size(400, 216);
      this.selectModules1.TabIndex = 2;
      // 
      // selectLicense1
      // 
      this.selectLicense1.Location = new System.Drawing.Point(3, 89);
      this.selectLicense1.Name = "selectLicense1";
      this.selectLicense1.Size = new System.Drawing.Size(400, 50);
      this.selectLicense1.TabIndex = 0;
      // 
      // selectSitecore1
      // 
      this.selectSitecore1.Location = new System.Drawing.Point(3, 42);
      this.selectSitecore1.Name = "selectSitecore1";
      this.selectSitecore1.Size = new System.Drawing.Size(400, 50);
      this.selectSitecore1.TabIndex = 3;
      // 
      // selectProjectName1
      // 
      this.selectProjectName1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
      this.selectProjectName1.Location = new System.Drawing.Point(3, 0);
      this.selectProjectName1.Name = "selectProjectName1";
      this.selectProjectName1.ProjectName = "";
      this.selectProjectName1.Size = new System.Drawing.Size(400, 50);
      this.selectProjectName1.TabIndex = 1;
      // 
      // pnlContent
      // 
      this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(69)))), ((int)(((byte)(79)))));
      this.pnlContent.Controls.Add(this.selectProjectName1);
      this.pnlContent.Controls.Add(this.selectSitecore1);
      this.pnlContent.Controls.Add(this.selectLicense1);
      this.pnlContent.Controls.Add(this.selectModules1);
      this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlContent.Location = new System.Drawing.Point(0, 30);
      this.pnlContent.Name = "pnlContent";
      this.pnlContent.Size = new System.Drawing.Size(800, 370);
      this.pnlContent.TabIndex = 1;
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
  }
}
