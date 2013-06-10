namespace SitecoreInstaller.UI.Preferences
{
  partial class SourcesSettings
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
      this.lblSources = new SitecoreInstaller.UI.Forms.SIH2();
      this.SuspendLayout();
      // 
      // lblSources
      // 
      this.lblSources.AutoSize = true;
      this.lblSources.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
      this.lblSources.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.lblSources.Location = new System.Drawing.Point(3, 0);
      this.lblSources.Name = "lblSources";
      this.lblSources.Size = new System.Drawing.Size(61, 19);
      this.lblSources.TabIndex = 0;
      this.lblSources.Text = "Sources";
      // 
      // SourcesSettings
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.lblSources);
      this.Name = "SourcesSettings";
      this.Size = new System.Drawing.Size(586, 334);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Forms.SIH2 lblSources;
  }
}
