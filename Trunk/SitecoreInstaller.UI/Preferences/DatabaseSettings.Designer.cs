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
      this.lblInstanceName = new SitecoreInstaller.UI.Forms.SIH2();
      this.tbxInstanceName = new System.Windows.Forms.TextBox();
      this.lblLogin = new SitecoreInstaller.UI.Forms.SIH2();
      this.tbxLogin = new System.Windows.Forms.TextBox();
      this.lblPassword = new SitecoreInstaller.UI.Forms.SIH2();
      this.tbxPassword = new System.Windows.Forms.TextBox();
      this.siButton1 = new SitecoreInstaller.UI.Forms.SIButton();
      this.SuspendLayout();
      // 
      // lblInstanceName
      // 
      this.lblInstanceName.AutoSize = true;
      this.lblInstanceName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
      this.lblInstanceName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.lblInstanceName.Location = new System.Drawing.Point(3, 33);
      this.lblInstanceName.Name = "lblInstanceName";
      this.lblInstanceName.Size = new System.Drawing.Size(104, 19);
      this.lblInstanceName.TabIndex = 3;
      this.lblInstanceName.Text = "Instance name";
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
      this.lblLogin.Size = new System.Drawing.Size(46, 19);
      this.lblLogin.TabIndex = 5;
      this.lblLogin.Text = "Login";
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
      this.lblPassword.Size = new System.Drawing.Size(73, 19);
      this.lblPassword.TabIndex = 7;
      this.lblPassword.Text = "Password";
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
      // siButton1
      // 
      this.siButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.siButton1.Cursor = System.Windows.Forms.Cursors.Hand;
      this.siButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.siButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.siButton1.Font = new System.Drawing.Font("Segoe UI", 8F);
      this.siButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.siButton1.Location = new System.Drawing.Point(373, 171);
      this.siButton1.Name = "siButton1";
      this.siButton1.Size = new System.Drawing.Size(120, 52);
      this.siButton1.TabIndex = 9;
      this.siButton1.Text = "Test Sql settings";
      this.siButton1.UseVisualStyleBackColor = true;
      this.siButton1.Click += new System.EventHandler(this.siButton1_Click);
      // 
      // DatabaseSettings
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.siButton1);
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
      this.Controls.SetChildIndex(this.siButton1, 0);
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
    private Forms.SIButton siButton1;

  }
}
