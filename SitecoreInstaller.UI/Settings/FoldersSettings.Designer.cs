namespace SitecoreInstaller.UI.Settings
{
  partial class FoldersSettings
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
      this.lblBuildLibraryFolder = new SitecoreInstaller.UI.Forms.SIH2();
      this.tbxBuildLibraryFolder = new System.Windows.Forms.TextBox();
      this.lblProjectFolder = new SitecoreInstaller.UI.Forms.SIH2();
      this.tbxProjectFolder = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // lblBuildLibraryFolder
      // 
      this.lblBuildLibraryFolder.AutoSize = true;
      this.lblBuildLibraryFolder.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
      this.lblBuildLibraryFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.lblBuildLibraryFolder.Location = new System.Drawing.Point(3, 33);
      this.lblBuildLibraryFolder.Name = "lblBuildLibraryFolder";
      this.lblBuildLibraryFolder.Size = new System.Drawing.Size(137, 19);
      this.lblBuildLibraryFolder.TabIndex = 3;
      this.lblBuildLibraryFolder.Text = "Build library folder";
      // 
      // tbxBuildLibraryFolder
      // 
      this.tbxBuildLibraryFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbxBuildLibraryFolder.Location = new System.Drawing.Point(7, 55);
      this.tbxBuildLibraryFolder.Name = "tbxBuildLibraryFolder";
      this.tbxBuildLibraryFolder.Size = new System.Drawing.Size(486, 20);
      this.tbxBuildLibraryFolder.TabIndex = 5;
      // 
      // lblProjectFolder
      // 
      this.lblProjectFolder.AutoSize = true;
      this.lblProjectFolder.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
      this.lblProjectFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.lblProjectFolder.Location = new System.Drawing.Point(3, 143);
      this.lblProjectFolder.Name = "lblProjectFolder";
      this.lblProjectFolder.Size = new System.Drawing.Size(102, 19);
      this.lblProjectFolder.TabIndex = 6;
      this.lblProjectFolder.Text = "Project folder";
      // 
      // tbxProjectFolder
      // 
      this.tbxProjectFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbxProjectFolder.Location = new System.Drawing.Point(7, 165);
      this.tbxProjectFolder.Name = "tbxProjectFolder";
      this.tbxProjectFolder.Size = new System.Drawing.Size(486, 20);
      this.tbxProjectFolder.TabIndex = 7;
      // 
      // FoldersSettings
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tbxProjectFolder);
      this.Controls.Add(this.lblProjectFolder);
      this.Controls.Add(this.tbxBuildLibraryFolder);
      this.Controls.Add(this.lblBuildLibraryFolder);
      this.Name = "FoldersSettings";
      this.Controls.SetChildIndex(this.lblBuildLibraryFolder, 0);
      this.Controls.SetChildIndex(this.tbxBuildLibraryFolder, 0);
      this.Controls.SetChildIndex(this.lblProjectFolder, 0);
      this.Controls.SetChildIndex(this.tbxProjectFolder, 0);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Forms.SIH2 lblBuildLibraryFolder;
    private System.Windows.Forms.TextBox tbxBuildLibraryFolder;
    private Forms.SIH2 lblProjectFolder;
    private System.Windows.Forms.TextBox tbxProjectFolder;
  }
}
