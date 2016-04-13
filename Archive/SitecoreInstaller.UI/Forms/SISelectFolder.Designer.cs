namespace SitecoreInstaller.UI.Forms
{
  partial class SISelectFolder
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
      this.lblTitle = new SitecoreInstaller.UI.Forms.SIH2();
      this.tbxFolder = new System.Windows.Forms.TextBox();
      this.btnBrowse = new SitecoreInstaller.UI.Forms.SIButton();
      this.SuspendLayout();
      // 
      // lblTitle
      // 
      this.lblTitle.AutoSize = true;
      this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
      this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.lblTitle.Location = new System.Drawing.Point(3, 0);
      this.lblTitle.Name = "lblTitle";
      this.lblTitle.Size = new System.Drawing.Size(38, 19);
      this.lblTitle.TabIndex = 4;
      this.lblTitle.Text = "Title";
      // 
      // tbxFolder
      // 
      this.tbxFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbxFolder.Font = new System.Drawing.Font("Segoe UI", 8.5F);
      this.tbxFolder.Location = new System.Drawing.Point(6, 22);
      this.tbxFolder.Name = "tbxFolder";
      this.tbxFolder.Size = new System.Drawing.Size(387, 23);
      this.tbxFolder.TabIndex = 0;
      // 
      // btnBrowse
      // 
      this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnBrowse.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnBrowse.Font = new System.Drawing.Font("Segoe UI", 8F);
      this.btnBrowse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnBrowse.Location = new System.Drawing.Point(399, 22);
      this.btnBrowse.Name = "btnBrowse";
      this.btnBrowse.Size = new System.Drawing.Size(75, 23);
      this.btnBrowse.TabIndex = 1;
      this.btnBrowse.Text = "Browse...";
      this.btnBrowse.UseVisualStyleBackColor = true;
      this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
      // 
      // SISelectFolder
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.btnBrowse);
      this.Controls.Add(this.tbxFolder);
      this.Controls.Add(this.lblTitle);
      this.Name = "SISelectFolder";
      this.Size = new System.Drawing.Size(480, 84);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private SIH2 lblTitle;
    private System.Windows.Forms.TextBox tbxFolder;
    private SIButton btnBrowse;
  }
}
