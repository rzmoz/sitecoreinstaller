namespace SitecoreInstaller.UI.Preferences
{
  partial class UserPreferences
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
      this.siLabel1 = new SitecoreInstaller.UI.Forms.SILabel();
      this.btnSave = new SitecoreInstaller.UI.Forms.SIButton();
      this.SuspendLayout();
      // 
      // siLabel1
      // 
      this.siLabel1.AutoSize = true;
      this.siLabel1.Font = new System.Drawing.Font("Segoe UI", 8F);
      this.siLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.siLabel1.Location = new System.Drawing.Point(12, 32);
      this.siLabel1.Name = "siLabel1";
      this.siLabel1.Size = new System.Drawing.Size(48, 13);
      this.siLabel1.TabIndex = 0;
      this.siLabel1.Text = "siLabel1";
      // 
      // btnSave
      // 
      this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnSave.Font = new System.Drawing.Font("Segoe UI", 8F);
      this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnSave.Location = new System.Drawing.Point(559, 360);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(75, 23);
      this.btnSave.TabIndex = 1;
      this.btnSave.Text = "Save";
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
      // 
      // UserPreferences
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.btnSave);
      this.Controls.Add(this.siLabel1);
      this.Name = "UserPreferences";
      this.Size = new System.Drawing.Size(637, 386);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Forms.SILabel siLabel1;
    private Forms.SIButton btnSave;
  }
}
