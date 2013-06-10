namespace SitecoreInstaller.UI.Preferences
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
      this.tbxInstanceName = new System.Windows.Forms.TextBox();
      this.tbxLogin = new System.Windows.Forms.TextBox();
      this.tbxPassword = new System.Windows.Forms.TextBox();
      this.btnSave = new SitecoreInstaller.UI.Forms.SIButton();
      this.lblPassword = new SitecoreInstaller.UI.Forms.SIH2();
      this.lblLogin = new SitecoreInstaller.UI.Forms.SIH2();
      this.lblSqlInstanceName = new SitecoreInstaller.UI.Forms.SIH2();
      this.SuspendLayout();
      // 
      // tbxInstanceName
      // 
      this.tbxInstanceName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbxInstanceName.Location = new System.Drawing.Point(7, 22);
      this.tbxInstanceName.Name = "tbxInstanceName";
      this.tbxInstanceName.Size = new System.Drawing.Size(512, 20);
      this.tbxInstanceName.TabIndex = 1;
      // 
      // tbxLogin
      // 
      this.tbxLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbxLogin.Location = new System.Drawing.Point(7, 67);
      this.tbxLogin.Name = "tbxLogin";
      this.tbxLogin.Size = new System.Drawing.Size(512, 20);
      this.tbxLogin.TabIndex = 3;
      // 
      // tbxPassword
      // 
      this.tbxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbxPassword.Location = new System.Drawing.Point(7, 112);
      this.tbxPassword.Name = "tbxPassword";
      this.tbxPassword.Size = new System.Drawing.Size(512, 20);
      this.tbxPassword.TabIndex = 5;
      // 
      // btnSave
      // 
      this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnSave.Font = new System.Drawing.Font("Segoe UI", 8F);
      this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnSave.Location = new System.Drawing.Point(444, 311);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(75, 23);
      this.btnSave.TabIndex = 6;
      this.btnSave.Text = "Save";
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
      // 
      // lblPassword
      // 
      this.lblPassword.AutoSize = true;
      this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
      this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.lblPassword.Location = new System.Drawing.Point(3, 90);
      this.lblPassword.Name = "lblPassword";
      this.lblPassword.Size = new System.Drawing.Size(73, 19);
      this.lblPassword.TabIndex = 4;
      this.lblPassword.Text = "Password";
      // 
      // lblLogin
      // 
      this.lblLogin.AutoSize = true;
      this.lblLogin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
      this.lblLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.lblLogin.Location = new System.Drawing.Point(3, 45);
      this.lblLogin.Name = "lblLogin";
      this.lblLogin.Size = new System.Drawing.Size(46, 19);
      this.lblLogin.TabIndex = 2;
      this.lblLogin.Text = "Login";
      // 
      // lblSqlInstanceName
      // 
      this.lblSqlInstanceName.AutoSize = true;
      this.lblSqlInstanceName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
      this.lblSqlInstanceName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.lblSqlInstanceName.Location = new System.Drawing.Point(3, 0);
      this.lblSqlInstanceName.Name = "lblSqlInstanceName";
      this.lblSqlInstanceName.Size = new System.Drawing.Size(104, 19);
      this.lblSqlInstanceName.TabIndex = 0;
      this.lblSqlInstanceName.Text = "Instance name";
      // 
      // DatabaseSettings
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.btnSave);
      this.Controls.Add(this.tbxPassword);
      this.Controls.Add(this.lblPassword);
      this.Controls.Add(this.tbxLogin);
      this.Controls.Add(this.lblLogin);
      this.Controls.Add(this.tbxInstanceName);
      this.Controls.Add(this.lblSqlInstanceName);
      this.Name = "DatabaseSettings";
      this.Size = new System.Drawing.Size(522, 337);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Forms.SIH2 lblSqlInstanceName;
    private System.Windows.Forms.TextBox tbxInstanceName;
    private Forms.SIH2 lblLogin;
    private System.Windows.Forms.TextBox tbxLogin;
    private Forms.SIH2 lblPassword;
    private System.Windows.Forms.TextBox tbxPassword;
    private Forms.SIButton btnSave;
  }
}
