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
      this.selectProjectName1 = new SitecoreInstaller.UI.UserSelections.SelectProjectName();
      this.selectSitecore1 = new SitecoreInstaller.UI.UserSelections.SelectSitecore();
      this.selectLicense1 = new SitecoreInstaller.UI.UserSelections.SelectLicense();
      this.selectModules1 = new SitecoreInstaller.UI.UserSelections.SelectModules();
      this.rtbKeyboardShortcuts = new System.Windows.Forms.RichTextBox();
      this.pnlUserSelections.SuspendLayout();
      this.SuspendLayout();
      // 
      // pnlUserSelections
      // 
      this.pnlUserSelections.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
      this.pnlUserSelections.Controls.Add(this.selectProjectName1);
      this.pnlUserSelections.Controls.Add(this.selectSitecore1);
      this.pnlUserSelections.Controls.Add(this.selectLicense1);
      this.pnlUserSelections.Controls.Add(this.selectModules1);
      this.pnlUserSelections.Location = new System.Drawing.Point(3, 3);
      this.pnlUserSelections.Name = "pnlUserSelections";
      this.pnlUserSelections.Size = new System.Drawing.Size(311, 392);
      this.pnlUserSelections.TabIndex = 8;
      // 
      // selectProjectName1
      // 
      this.selectProjectName1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.selectProjectName1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
      this.selectProjectName1.Location = new System.Drawing.Point(12, 0);
      this.selectProjectName1.Name = "selectProjectName1";
      this.selectProjectName1.ProjectName = "";
      this.selectProjectName1.Size = new System.Drawing.Size(285, 50);
      this.selectProjectName1.TabIndex = 8;
      // 
      // selectSitecore1
      // 
      this.selectSitecore1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.selectSitecore1.Location = new System.Drawing.Point(12, 45);
      this.selectSitecore1.Name = "selectSitecore1";
      this.selectSitecore1.Size = new System.Drawing.Size(285, 50);
      this.selectSitecore1.TabIndex = 9;
      // 
      // selectLicense1
      // 
      this.selectLicense1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.selectLicense1.Location = new System.Drawing.Point(12, 90);
      this.selectLicense1.Name = "selectLicense1";
      this.selectLicense1.Size = new System.Drawing.Size(285, 50);
      this.selectLicense1.TabIndex = 10;
      // 
      // selectModules1
      // 
      this.selectModules1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.selectModules1.Location = new System.Drawing.Point(12, 136);
      this.selectModules1.Name = "selectModules1";
      this.selectModules1.Size = new System.Drawing.Size(285, 253);
      this.selectModules1.TabIndex = 11;
      // 
      // rtbKeyboardShortcuts
      // 
      this.rtbKeyboardShortcuts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.rtbKeyboardShortcuts.BackColor = System.Drawing.SystemColors.ControlDarkDark;
      this.rtbKeyboardShortcuts.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.rtbKeyboardShortcuts.Font = new System.Drawing.Font("Segoe UI", 10F);
      this.rtbKeyboardShortcuts.ForeColor = System.Drawing.Color.White;
      this.rtbKeyboardShortcuts.Location = new System.Drawing.Point(338, 26);
      this.rtbKeyboardShortcuts.Name = "rtbKeyboardShortcuts";
      this.rtbKeyboardShortcuts.ReadOnly = true;
      this.rtbKeyboardShortcuts.Size = new System.Drawing.Size(398, 354);
      this.rtbKeyboardShortcuts.TabIndex = 9;
      this.rtbKeyboardShortcuts.TabStop = false;
      this.rtbKeyboardShortcuts.Text = "CTRL + SHIFT + B = Install\nCTRL + SHIFT + U = Un-Install\nCTRL + SHIFT + R = Re-In" +
    "stall\nCTRL + SHIFT + L = Show / Hide Log\n";
      // 
      // MainDeveloper
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.rtbKeyboardShortcuts);
      this.Controls.Add(this.pnlUserSelections);
      this.Name = "MainDeveloper";
      this.Size = new System.Drawing.Size(753, 395);
      this.pnlUserSelections.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel pnlUserSelections;
    private SelectProjectName selectProjectName1;
    private SelectSitecore selectSitecore1;
    private SelectLicense selectLicense1;
    private SelectModules selectModules1;
    private System.Windows.Forms.RichTextBox rtbKeyboardShortcuts;

  }
}
