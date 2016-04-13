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
      this.fldProjectfolder = new SitecoreInstaller.UI.Forms.SISelectFolder();
      this.fldBuildLibraryFolder = new SitecoreInstaller.UI.Forms.SISelectFolder();
      this.SuspendLayout();
      // 
      // fldProjectfolder
      // 
      this.fldProjectfolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.fldProjectfolder.Location = new System.Drawing.Point(0, 38);
      this.fldProjectfolder.Name = "fldProjectfolder";
      this.fldProjectfolder.Size = new System.Drawing.Size(500, 96);
      this.fldProjectfolder.TabIndex = 8;
      this.fldProjectfolder.Title = "Project Folder";
      // 
      // fldBuildLibraryFolder
      // 
      this.fldBuildLibraryFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.fldBuildLibraryFolder.Location = new System.Drawing.Point(0, 138);
      this.fldBuildLibraryFolder.Name = "fldBuildLibraryFolder";
      this.fldBuildLibraryFolder.Size = new System.Drawing.Size(500, 96);
      this.fldBuildLibraryFolder.TabIndex = 9;
      this.fldBuildLibraryFolder.Title = "Build Library Folder";
      // 
      // FoldersSettings
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.fldBuildLibraryFolder);
      this.Controls.Add(this.fldProjectfolder);
      this.Name = "FoldersSettings";
      this.Controls.SetChildIndex(this.fldProjectfolder, 0);
      this.Controls.SetChildIndex(this.fldBuildLibraryFolder, 0);
      this.ResumeLayout(false);

    }

    #endregion

    private Forms.SISelectFolder fldProjectfolder;
    private Forms.SISelectFolder fldBuildLibraryFolder;

  }
}
