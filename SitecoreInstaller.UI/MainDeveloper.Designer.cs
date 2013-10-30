namespace SitecoreInstaller.UI
{
  using System;
  using SitecoreInstaller.UI.UserSelections;

  partial class MainDeveloper
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
      this.pnlUserSelections = new System.Windows.Forms.Panel();
      this.selectModules1 = new SitecoreInstaller.UI.UserSelections.SelectModules();
      this.selectClientInstall1 = new SitecoreInstaller.UI.UserSelections.SelectClientInstall();
      this.selectProjectName1 = new SitecoreInstaller.UI.UserSelections.SelectProjectName();
      this.selectSitecore1 = new SitecoreInstaller.UI.UserSelections.SelectSitecore();
      this.selectLicense1 = new SitecoreInstaller.UI.UserSelections.SelectLicense();
      this.mainDeveloperButtons1 = new SitecoreInstaller.UI.MainDeveloperButtons();
      this.pnlUserSelections.SuspendLayout();
      this.SuspendLayout();
      // 
      // pnlUserSelections
      // 
      this.pnlUserSelections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.pnlUserSelections.Controls.Add(this.selectModules1);
      this.pnlUserSelections.Controls.Add(this.selectClientInstall1);
      this.pnlUserSelections.Controls.Add(this.selectProjectName1);
      this.pnlUserSelections.Controls.Add(this.selectSitecore1);
      this.pnlUserSelections.Controls.Add(this.selectLicense1);
      this.pnlUserSelections.Location = new System.Drawing.Point(3, 3);
      this.pnlUserSelections.Name = "pnlUserSelections";
      this.pnlUserSelections.Size = new System.Drawing.Size(436, 467);
      this.pnlUserSelections.TabIndex = 8;
      // 
      // selectModules1
      // 
      this.selectModules1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.selectModules1.Location = new System.Drawing.Point(12, 177);
      this.selectModules1.Name = "selectModules1";
      this.selectModules1.Size = new System.Drawing.Size(410, 287);
      this.selectModules1.TabIndex = 12;
      // 
      // selectClientInstall1
      // 
      this.selectClientInstall1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.selectClientInstall1.Location = new System.Drawing.Point(12, 140);
      this.selectClientInstall1.Name = "selectClientInstall1";
      this.selectClientInstall1.Size = new System.Drawing.Size(410, 42);
      this.selectClientInstall1.TabIndex = 11;
      // 
      // selectProjectName1
      // 
      this.selectProjectName1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.selectProjectName1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
      this.selectProjectName1.Location = new System.Drawing.Point(12, 0);
      this.selectProjectName1.Name = "selectProjectName1";
      this.selectProjectName1.ProjectName = "";
      this.selectProjectName1.Size = new System.Drawing.Size(410, 50);
      this.selectProjectName1.TabIndex = 8;
      // 
      // selectSitecore1
      // 
      this.selectSitecore1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.selectSitecore1.Location = new System.Drawing.Point(12, 45);
      this.selectSitecore1.Name = "selectSitecore1";
      this.selectSitecore1.Size = new System.Drawing.Size(410, 50);
      this.selectSitecore1.TabIndex = 9;
      // 
      // selectLicense1
      // 
      this.selectLicense1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.selectLicense1.Location = new System.Drawing.Point(12, 90);
      this.selectLicense1.Name = "selectLicense1";
      this.selectLicense1.Size = new System.Drawing.Size(410, 50);
      this.selectLicense1.TabIndex = 10;
      // 
      // mainDeveloperButtons1
      // 
      this.mainDeveloperButtons1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.mainDeveloperButtons1.Location = new System.Drawing.Point(445, 0);
      this.mainDeveloperButtons1.Name = "mainDeveloperButtons1";
      this.mainDeveloperButtons1.Size = new System.Drawing.Size(186, 470);
      this.mainDeveloperButtons1.TabIndex = 10;
      // 
      // MainDeveloper
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.mainDeveloperButtons1);
      this.Controls.Add(this.pnlUserSelections);
      this.Name = "MainDeveloper";
      this.Size = new System.Drawing.Size(631, 470);
      this.pnlUserSelections.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel pnlUserSelections;
    private SelectProjectName selectProjectName1;
    private SelectSitecore selectSitecore1;
    private SelectLicense selectLicense1;
    private SelectModules selectModules1;
    private MainDeveloperButtons mainDeveloperButtons1;
    private SelectClientInstall selectClientInstall1;

  }
}
