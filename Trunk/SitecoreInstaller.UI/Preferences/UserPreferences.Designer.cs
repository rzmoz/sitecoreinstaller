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
      this.pnlButtons = new System.Windows.Forms.Panel();
      this.btnBack = new SitecoreInstaller.UI.Forms.SIButton();
      this.pnlContent = new System.Windows.Forms.Panel();
      this.databaseSettings1 = new SitecoreInstaller.UI.Preferences.DatabaseSettings();
      this.sourcesSettings1 = new SitecoreInstaller.UI.Preferences.SourcesSettings();
      this.pnlButtons.SuspendLayout();
      this.pnlContent.SuspendLayout();
      this.SuspendLayout();
      // 
      // pnlButtons
      // 
      this.pnlButtons.Controls.Add(this.btnBack);
      this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Left;
      this.pnlButtons.Location = new System.Drawing.Point(0, 0);
      this.pnlButtons.Name = "pnlButtons";
      this.pnlButtons.Size = new System.Drawing.Size(150, 386);
      this.pnlButtons.TabIndex = 0;
      // 
      // btnBack
      // 
      this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnBack.Dock = System.Windows.Forms.DockStyle.Top;
      this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnBack.Font = new System.Drawing.Font("Segoe UI", 8F);
      this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnBack.Location = new System.Drawing.Point(0, 0);
      this.btnBack.Name = "btnBack";
      this.btnBack.Size = new System.Drawing.Size(150, 85);
      this.btnBack.TabIndex = 0;
      this.btnBack.UseVisualStyleBackColor = true;
      this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
      // 
      // pnlContent
      // 
      this.pnlContent.Controls.Add(this.databaseSettings1);
      this.pnlContent.Controls.Add(this.sourcesSettings1);
      this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlContent.Location = new System.Drawing.Point(150, 0);
      this.pnlContent.Name = "pnlContent";
      this.pnlContent.Size = new System.Drawing.Size(487, 386);
      this.pnlContent.TabIndex = 1;
      // 
      // databaseSettings1
      // 
      this.databaseSettings1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.databaseSettings1.Label = "Sql Settings";
      this.databaseSettings1.Location = new System.Drawing.Point(0, 0);
      this.databaseSettings1.Name = "databaseSettings1";
      this.databaseSettings1.Size = new System.Drawing.Size(487, 386);
      this.databaseSettings1.TabIndex = 2;
      // 
      // sourcesSettings1
      // 
      this.sourcesSettings1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.sourcesSettings1.Location = new System.Drawing.Point(0, 0);
      this.sourcesSettings1.Name = "sourcesSettings1";
      this.sourcesSettings1.Size = new System.Drawing.Size(487, 386);
      this.sourcesSettings1.TabIndex = 3;
      // 
      // UserPreferences
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.pnlContent);
      this.Controls.Add(this.pnlButtons);
      this.Name = "UserPreferences";
      this.Size = new System.Drawing.Size(637, 386);
      this.pnlButtons.ResumeLayout(false);
      this.pnlContent.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel pnlButtons;
    private System.Windows.Forms.Panel pnlContent;
    private DatabaseSettings databaseSettings1;
    private SourcesSettings sourcesSettings1;
    private Forms.SIButton btnBack;


  }
}
