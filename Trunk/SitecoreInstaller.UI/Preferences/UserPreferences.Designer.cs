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
      this.databaseSettings1 = new SitecoreInstaller.UI.Preferences.DatabaseSettings();
      this.SuspendLayout();
      // 
      // databaseSettings1
      // 
      this.databaseSettings1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.databaseSettings1.Location = new System.Drawing.Point(0, 0);
      this.databaseSettings1.Name = "databaseSettings1";
      this.databaseSettings1.Size = new System.Drawing.Size(637, 386);
      this.databaseSettings1.TabIndex = 1;
      // 
      // UserPreferences
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.databaseSettings1);
      this.Name = "UserPreferences";
      this.Size = new System.Drawing.Size(637, 386);
      this.ResumeLayout(false);

    }

    #endregion

    private DatabaseSettings databaseSettings1;

  }
}
