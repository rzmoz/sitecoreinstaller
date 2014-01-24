namespace SitecoreInstaller.UI.Settings
{
  partial class UserSettings
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
            this.components = new System.ComponentModel.Container();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.autoSetupSettings1 = new SitecoreInstaller.UI.Settings.AutoSetupSettings();
            this.mongoSettings1 = new SitecoreInstaller.UI.Settings.MongoSettings();
            this.sqlSettings1 = new SitecoreInstaller.UI.Settings.SqlSettings();
            this.sourcesSettings1 = new SitecoreInstaller.UI.Settings.SourcesSettings();
            this.foldersSettings1 = new SitecoreInstaller.UI.Settings.FoldersSettings();
            this.licensesSettings1 = new SitecoreInstaller.UI.Settings.LicensesSettings();
            this.btnBack = new SitecoreInstaller.UI.Forms.SIButton();
            this.pnlButtons.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.AutoScroll = true;
            this.pnlButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlButtons.Controls.Add(this.btnBack);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlButtons.Location = new System.Drawing.Point(0, 0);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(150, 386);
            this.pnlButtons.TabIndex = 0;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.autoSetupSettings1);
            this.pnlContent.Controls.Add(this.mongoSettings1);
            this.pnlContent.Controls.Add(this.sqlSettings1);
            this.pnlContent.Controls.Add(this.sourcesSettings1);
            this.pnlContent.Controls.Add(this.foldersSettings1);
            this.pnlContent.Controls.Add(this.licensesSettings1);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(150, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(487, 386);
            this.pnlContent.TabIndex = 1;
            // 
            // autoSetupSettings1
            // 
            this.autoSetupSettings1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.autoSetupSettings1.Label = "Header";
            this.autoSetupSettings1.Location = new System.Drawing.Point(0, 0);
            this.autoSetupSettings1.Name = "autoSetupSettings1";
            this.autoSetupSettings1.Size = new System.Drawing.Size(487, 386);
            this.autoSetupSettings1.TabIndex = 6;
            // 
            // mongoSettings1
            // 
            this.mongoSettings1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mongoSettings1.Label = "Mongo Settings";
            this.mongoSettings1.Location = new System.Drawing.Point(0, 0);
            this.mongoSettings1.Name = "mongoSettings1";
            this.mongoSettings1.Size = new System.Drawing.Size(487, 386);
            this.mongoSettings1.TabIndex = 5;
            // 
            // sqlSettings1
            // 
            this.sqlSettings1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sqlSettings1.Label = "Sql Settings";
            this.sqlSettings1.Location = new System.Drawing.Point(0, 0);
            this.sqlSettings1.Name = "sqlSettings1";
            this.sqlSettings1.Size = new System.Drawing.Size(487, 386);
            this.sqlSettings1.TabIndex = 2;
            // 
            // sourcesSettings1
            // 
            this.sourcesSettings1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourcesSettings1.Label = "Header";
            this.sourcesSettings1.Location = new System.Drawing.Point(0, 0);
            this.sourcesSettings1.Name = "sourcesSettings1";
            this.sourcesSettings1.Size = new System.Drawing.Size(487, 386);
            this.sourcesSettings1.TabIndex = 3;
            // 
            // foldersSettings1
            // 
            this.foldersSettings1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.foldersSettings1.Label = "Header";
            this.foldersSettings1.Location = new System.Drawing.Point(0, 0);
            this.foldersSettings1.Name = "foldersSettings1";
            this.foldersSettings1.Size = new System.Drawing.Size(487, 386);
            this.foldersSettings1.TabIndex = 4;
            // 
            // licensesSettings1
            // 
            this.licensesSettings1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.licensesSettings1.Label = "Header";
            this.licensesSettings1.Location = new System.Drawing.Point(0, 0);
            this.licensesSettings1.Name = "licensesSettings1";
            this.licensesSettings1.Size = new System.Drawing.Size(487, 386);
            this.licensesSettings1.TabIndex = 7;
            // 
            // btnBack
            // 
            this.btnBack.BottomDividerColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(46)))));
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBack.DrawBottomDivider = false;
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
            // UserSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlButtons);
            this.Name = "UserSettings";
            this.Size = new System.Drawing.Size(637, 386);
            this.pnlButtons.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel pnlButtons;
    private System.Windows.Forms.Panel pnlContent;
    private SqlSettings sqlSettings1;
    private SourcesSettings sourcesSettings1;
    private Forms.SIButton btnBack;
    private FoldersSettings foldersSettings1;
    private System.Windows.Forms.ToolTip toolTip1;
    private MongoSettings mongoSettings1;
    private AutoSetupSettings autoSetupSettings1;
    private LicensesSettings licensesSettings1;
  }
}
