namespace SitecoreInstaller.UI.SDN
{
  partial class SdnLogin
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
      this.lblUsername = new SitecoreInstaller.UI.Forms.SILabel();
      this.tbxUsername = new SitecoreInstaller.UI.Forms.SITextBox();
      this.lblPassword = new SitecoreInstaller.UI.Forms.SILabel();
      this.tbxPassword = new SitecoreInstaller.UI.Forms.SITextBox();
      this.btnVerify = new SitecoreInstaller.UI.Forms.SIButton();
      this.SuspendLayout();
      // 
      // lblUsername
      // 
      this.lblUsername.AutoSize = true;
      this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 8F);
      this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.lblUsername.Location = new System.Drawing.Point(3, 32);
      this.lblUsername.Name = "lblUsername";
      this.lblUsername.Size = new System.Drawing.Size(58, 13);
      this.lblUsername.TabIndex = 0;
      this.lblUsername.Text = "Username";
      // 
      // tbxUsername
      // 
      this.tbxUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbxUsername.Location = new System.Drawing.Point(6, 48);
      this.tbxUsername.Name = "tbxUsername";
      this.tbxUsername.Size = new System.Drawing.Size(511, 20);
      this.tbxUsername.TabIndex = 1;
      // 
      // lblPassword
      // 
      this.lblPassword.AutoSize = true;
      this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 8F);
      this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.lblPassword.Location = new System.Drawing.Point(3, 90);
      this.lblPassword.Name = "lblPassword";
      this.lblPassword.Size = new System.Drawing.Size(56, 13);
      this.lblPassword.TabIndex = 2;
      this.lblPassword.Text = "Password";
      // 
      // tbxPassword
      // 
      this.tbxPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tbxPassword.Location = new System.Drawing.Point(6, 106);
      this.tbxPassword.Name = "tbxPassword";
      this.tbxPassword.Size = new System.Drawing.Size(511, 20);
      this.tbxPassword.TabIndex = 3;
      // 
      // btnVerify
      // 
      this.btnVerify.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnVerify.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnVerify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnVerify.Font = new System.Drawing.Font("Segoe UI", 8F);
      this.btnVerify.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnVerify.Location = new System.Drawing.Point(374, 166);
      this.btnVerify.Name = "btnVerify";
      this.btnVerify.Size = new System.Drawing.Size(143, 23);
      this.btnVerify.TabIndex = 4;
      this.btnVerify.Text = "Verify credentials";
      this.btnVerify.UseVisualStyleBackColor = true;
      this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
      // 
      // SdnLogin
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.btnVerify);
      this.Controls.Add(this.tbxPassword);
      this.Controls.Add(this.lblPassword);
      this.Controls.Add(this.tbxUsername);
      this.Controls.Add(this.lblUsername);
      this.Name = "SdnLogin";
      this.Size = new System.Drawing.Size(520, 352);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Forms.SILabel lblUsername;
    private Forms.SITextBox tbxUsername;
    private Forms.SILabel lblPassword;
    private Forms.SITextBox tbxPassword;
    private Forms.SIButton btnVerify;
  }
}
