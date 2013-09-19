namespace SitecoreInstaller.UI.Settings
{
  partial class DatabaseSettings
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
      this.lblInstanceName = new SitecoreInstaller.UI.Forms.SIH2();
      this.tbxInstanceName = new System.Windows.Forms.TextBox();
      this.lblLogin = new SitecoreInstaller.UI.Forms.SIH2();
      this.tbxLogin = new System.Windows.Forms.TextBox();
      this.lblPassword = new SitecoreInstaller.UI.Forms.SIH2();
      this.tbxPassword = new System.Windows.Forms.TextBox();
      this.btnTestSqlSettings = new SitecoreInstaller.UI.Forms.SIButton();
      this.lblMongoEndpoint = new SitecoreInstaller.UI.Forms.SIH2();
      this.tbxMongoEndpoint = new System.Windows.Forms.TextBox();
      this.lblPort = new SitecoreInstaller.UI.Forms.SIH2();
      this.tbxMongoPort = new System.Windows.Forms.TextBox();
      this.tbxMongoPassword = new System.Windows.Forms.TextBox();
      this.lblMongoPassword = new SitecoreInstaller.UI.Forms.SIH2();
      this.tbxMongoUsername = new System.Windows.Forms.TextBox();
      this.lblMongoUsername = new SitecoreInstaller.UI.Forms.SIH2();
      this.btnTestMongoSettings = new SitecoreInstaller.UI.Forms.SIButton();
      this.SuspendLayout();
      // 
      // lblInstanceName
      // 
      this.lblInstanceName.AutoSize = true;
      this.lblInstanceName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
      this.lblInstanceName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.lblInstanceName.Location = new System.Drawing.Point(3, 33);
      this.lblInstanceName.Name = "lblInstanceName";
      this.lblInstanceName.Size = new System.Drawing.Size(148, 19);
      this.lblInstanceName.TabIndex = 3;
      this.lblInstanceName.Text = "MsSql Instance name";
      // 
      // tbxInstanceName
      // 
      this.tbxInstanceName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbxInstanceName.Location = new System.Drawing.Point(7, 55);
      this.tbxInstanceName.Name = "tbxInstanceName";
      this.tbxInstanceName.Size = new System.Drawing.Size(486, 20);
      this.tbxInstanceName.TabIndex = 4;
      // 
      // lblLogin
      // 
      this.lblLogin.AutoSize = true;
      this.lblLogin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
      this.lblLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.lblLogin.Location = new System.Drawing.Point(3, 78);
      this.lblLogin.Name = "lblLogin";
      this.lblLogin.Size = new System.Drawing.Size(90, 19);
      this.lblLogin.TabIndex = 5;
      this.lblLogin.Text = "MsSql Login";
      // 
      // tbxLogin
      // 
      this.tbxLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbxLogin.Location = new System.Drawing.Point(7, 100);
      this.tbxLogin.Name = "tbxLogin";
      this.tbxLogin.Size = new System.Drawing.Size(486, 20);
      this.tbxLogin.TabIndex = 6;
      // 
      // lblPassword
      // 
      this.lblPassword.AutoSize = true;
      this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
      this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.lblPassword.Location = new System.Drawing.Point(3, 123);
      this.lblPassword.Name = "lblPassword";
      this.lblPassword.Size = new System.Drawing.Size(117, 19);
      this.lblPassword.TabIndex = 7;
      this.lblPassword.Text = "MsSql Password";
      // 
      // tbxPassword
      // 
      this.tbxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbxPassword.Location = new System.Drawing.Point(7, 145);
      this.tbxPassword.Name = "tbxPassword";
      this.tbxPassword.Size = new System.Drawing.Size(486, 20);
      this.tbxPassword.TabIndex = 8;
      // 
      // btnTestSqlSettings
      // 
      this.btnTestSqlSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnTestSqlSettings.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnTestSqlSettings.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnTestSqlSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnTestSqlSettings.Font = new System.Drawing.Font("Segoe UI", 8F);
      this.btnTestSqlSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnTestSqlSettings.Location = new System.Drawing.Point(321, 182);
      this.btnTestSqlSettings.Name = "btnTestSqlSettings";
      this.btnTestSqlSettings.Size = new System.Drawing.Size(172, 23);
      this.btnTestSqlSettings.TabIndex = 9;
      this.btnTestSqlSettings.Text = "Test Sql settings";
      this.btnTestSqlSettings.UseVisualStyleBackColor = true;
      this.btnTestSqlSettings.Click += new System.EventHandler(this.btnTestSqlSettings_Click);
      // 
      // lblMongoEndpoint
      // 
      this.lblMongoEndpoint.AutoSize = true;
      this.lblMongoEndpoint.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
      this.lblMongoEndpoint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.lblMongoEndpoint.Location = new System.Drawing.Point(3, 206);
      this.lblMongoEndpoint.Name = "lblMongoEndpoint";
      this.lblMongoEndpoint.Size = new System.Drawing.Size(121, 19);
      this.lblMongoEndpoint.TabIndex = 10;
      this.lblMongoEndpoint.Text = "Mongo endpoint";
      // 
      // tbxMongoEndpoint
      // 
      this.tbxMongoEndpoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbxMongoEndpoint.Location = new System.Drawing.Point(7, 228);
      this.tbxMongoEndpoint.Name = "tbxMongoEndpoint";
      this.tbxMongoEndpoint.Size = new System.Drawing.Size(486, 20);
      this.tbxMongoEndpoint.TabIndex = 11;
      // 
      // lblPort
      // 
      this.lblPort.AutoSize = true;
      this.lblPort.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
      this.lblPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.lblPort.Location = new System.Drawing.Point(3, 251);
      this.lblPort.Name = "lblPort";
      this.lblPort.Size = new System.Drawing.Size(90, 19);
      this.lblPort.TabIndex = 12;
      this.lblPort.Text = "Mongo port";
      // 
      // tbxMongoPort
      // 
      this.tbxMongoPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbxMongoPort.Location = new System.Drawing.Point(7, 273);
      this.tbxMongoPort.Name = "tbxMongoPort";
      this.tbxMongoPort.Size = new System.Drawing.Size(486, 20);
      this.tbxMongoPort.TabIndex = 13;
      // 
      // tbxMongoPassword
      // 
      this.tbxMongoPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbxMongoPassword.Location = new System.Drawing.Point(7, 363);
      this.tbxMongoPassword.Name = "tbxMongoPassword";
      this.tbxMongoPassword.Size = new System.Drawing.Size(486, 20);
      this.tbxMongoPassword.TabIndex = 17;
      // 
      // lblMongoPassword
      // 
      this.lblMongoPassword.AutoSize = true;
      this.lblMongoPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
      this.lblMongoPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.lblMongoPassword.Location = new System.Drawing.Point(3, 341);
      this.lblMongoPassword.Name = "lblMongoPassword";
      this.lblMongoPassword.Size = new System.Drawing.Size(125, 19);
      this.lblMongoPassword.TabIndex = 16;
      this.lblMongoPassword.Text = "Mongo password";
      // 
      // tbxMongoUsername
      // 
      this.tbxMongoUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbxMongoUsername.Location = new System.Drawing.Point(7, 318);
      this.tbxMongoUsername.Name = "tbxMongoUsername";
      this.tbxMongoUsername.Size = new System.Drawing.Size(486, 20);
      this.tbxMongoUsername.TabIndex = 15;
      // 
      // lblMongoUsername
      // 
      this.lblMongoUsername.AutoSize = true;
      this.lblMongoUsername.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
      this.lblMongoUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.lblMongoUsername.Location = new System.Drawing.Point(3, 296);
      this.lblMongoUsername.Name = "lblMongoUsername";
      this.lblMongoUsername.Size = new System.Drawing.Size(126, 19);
      this.lblMongoUsername.TabIndex = 14;
      this.lblMongoUsername.Text = "Mongo username";
      // 
      // btnTestMongoSettings
      // 
      this.btnTestMongoSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnTestMongoSettings.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnTestMongoSettings.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnTestMongoSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnTestMongoSettings.Font = new System.Drawing.Font("Segoe UI", 8F);
      this.btnTestMongoSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnTestMongoSettings.Location = new System.Drawing.Point(321, 399);
      this.btnTestMongoSettings.Name = "btnTestMongoSettings";
      this.btnTestMongoSettings.Size = new System.Drawing.Size(172, 23);
      this.btnTestMongoSettings.TabIndex = 18;
      this.btnTestMongoSettings.Text = "Test Mongo settings";
      this.btnTestMongoSettings.UseVisualStyleBackColor = true;
      this.btnTestMongoSettings.Click += new System.EventHandler(this.btnTestMongoSettings_Click);
      // 
      // DatabaseSettings
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.btnTestMongoSettings);
      this.Controls.Add(this.tbxMongoPassword);
      this.Controls.Add(this.lblMongoPassword);
      this.Controls.Add(this.tbxMongoUsername);
      this.Controls.Add(this.lblMongoUsername);
      this.Controls.Add(this.tbxMongoPort);
      this.Controls.Add(this.lblPort);
      this.Controls.Add(this.tbxMongoEndpoint);
      this.Controls.Add(this.lblMongoEndpoint);
      this.Controls.Add(this.btnTestSqlSettings);
      this.Controls.Add(this.tbxPassword);
      this.Controls.Add(this.lblPassword);
      this.Controls.Add(this.tbxLogin);
      this.Controls.Add(this.lblLogin);
      this.Controls.Add(this.tbxInstanceName);
      this.Controls.Add(this.lblInstanceName);
      this.Name = "DatabaseSettings";
      this.Controls.SetChildIndex(this.lblInstanceName, 0);
      this.Controls.SetChildIndex(this.tbxInstanceName, 0);
      this.Controls.SetChildIndex(this.lblLogin, 0);
      this.Controls.SetChildIndex(this.tbxLogin, 0);
      this.Controls.SetChildIndex(this.lblPassword, 0);
      this.Controls.SetChildIndex(this.tbxPassword, 0);
      this.Controls.SetChildIndex(this.btnTestSqlSettings, 0);
      this.Controls.SetChildIndex(this.lblMongoEndpoint, 0);
      this.Controls.SetChildIndex(this.tbxMongoEndpoint, 0);
      this.Controls.SetChildIndex(this.lblPort, 0);
      this.Controls.SetChildIndex(this.tbxMongoPort, 0);
      this.Controls.SetChildIndex(this.lblMongoUsername, 0);
      this.Controls.SetChildIndex(this.tbxMongoUsername, 0);
      this.Controls.SetChildIndex(this.lblMongoPassword, 0);
      this.Controls.SetChildIndex(this.tbxMongoPassword, 0);
      this.Controls.SetChildIndex(this.btnTestMongoSettings, 0);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Forms.SIH2 lblInstanceName;
    private System.Windows.Forms.TextBox tbxInstanceName;
    private Forms.SIH2 lblLogin;
    private System.Windows.Forms.TextBox tbxLogin;
    private Forms.SIH2 lblPassword;
    private System.Windows.Forms.TextBox tbxPassword;
    private Forms.SIButton btnTestSqlSettings;
    private Forms.SIH2 lblMongoEndpoint;
    private System.Windows.Forms.TextBox tbxMongoEndpoint;
    private Forms.SIH2 lblPort;
    private System.Windows.Forms.TextBox tbxMongoPort;
    private System.Windows.Forms.TextBox tbxMongoPassword;
    private Forms.SIH2 lblMongoPassword;
    private System.Windows.Forms.TextBox tbxMongoUsername;
    private Forms.SIH2 lblMongoUsername;
    private Forms.SIButton btnTestMongoSettings;

  }
}
