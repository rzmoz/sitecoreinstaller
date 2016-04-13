namespace SitecoreInstaller.UI.Settings
{
    partial class MongoSettings
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
            this.btnTestMongoSettings = new SitecoreInstaller.UI.Forms.SIButton();
            this.tbxMongoPassword = new System.Windows.Forms.TextBox();
            this.lblMongoPassword = new SitecoreInstaller.UI.Forms.SIH2();
            this.tbxMongoUsername = new System.Windows.Forms.TextBox();
            this.lblMongoUsername = new SitecoreInstaller.UI.Forms.SIH2();
            this.tbxMongoPort = new System.Windows.Forms.TextBox();
            this.lblPort = new SitecoreInstaller.UI.Forms.SIH2();
            this.tbxMongoEndpoint = new System.Windows.Forms.TextBox();
            this.lblMongoEndpoint = new SitecoreInstaller.UI.Forms.SIH2();
            this.SuspendLayout();
            // 
            // btnTestMongoSettings
            // 
            this.btnTestMongoSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestMongoSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTestMongoSettings.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.btnTestMongoSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestMongoSettings.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnTestMongoSettings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.btnTestMongoSettings.Location = new System.Drawing.Point(321, 226);
            this.btnTestMongoSettings.Name = "btnTestMongoSettings";
            this.btnTestMongoSettings.Size = new System.Drawing.Size(172, 23);
            this.btnTestMongoSettings.TabIndex = 4;
            this.btnTestMongoSettings.Text = "Test Mongo settings";
            this.btnTestMongoSettings.UseVisualStyleBackColor = true;
            this.btnTestMongoSettings.Click += new System.EventHandler(this.btnTestMongoSettings_Click);
            // 
            // tbxMongoPassword
            // 
            this.tbxMongoPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxMongoPassword.Location = new System.Drawing.Point(7, 190);
            this.tbxMongoPassword.Name = "tbxMongoPassword";
            this.tbxMongoPassword.Size = new System.Drawing.Size(486, 20);
            this.tbxMongoPassword.TabIndex = 3;
            // 
            // lblMongoPassword
            // 
            this.lblMongoPassword.AutoSize = true;
            this.lblMongoPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMongoPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.lblMongoPassword.Location = new System.Drawing.Point(3, 168);
            this.lblMongoPassword.Name = "lblMongoPassword";
            this.lblMongoPassword.Size = new System.Drawing.Size(73, 19);
            this.lblMongoPassword.TabIndex = 25;
            this.lblMongoPassword.Text = "Password";
            // 
            // tbxMongoUsername
            // 
            this.tbxMongoUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxMongoUsername.Location = new System.Drawing.Point(7, 145);
            this.tbxMongoUsername.Name = "tbxMongoUsername";
            this.tbxMongoUsername.Size = new System.Drawing.Size(486, 20);
            this.tbxMongoUsername.TabIndex = 2;
            // 
            // lblMongoUsername
            // 
            this.lblMongoUsername.AutoSize = true;
            this.lblMongoUsername.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMongoUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.lblMongoUsername.Location = new System.Drawing.Point(3, 123);
            this.lblMongoUsername.Name = "lblMongoUsername";
            this.lblMongoUsername.Size = new System.Drawing.Size(76, 19);
            this.lblMongoUsername.TabIndex = 23;
            this.lblMongoUsername.Text = "Username";
            // 
            // tbxMongoPort
            // 
            this.tbxMongoPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxMongoPort.Location = new System.Drawing.Point(7, 100);
            this.tbxMongoPort.Name = "tbxMongoPort";
            this.tbxMongoPort.Size = new System.Drawing.Size(486, 20);
            this.tbxMongoPort.TabIndex = 1;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.lblPort.Location = new System.Drawing.Point(3, 78);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(38, 19);
            this.lblPort.TabIndex = 21;
            this.lblPort.Text = "Port";
            // 
            // tbxMongoEndpoint
            // 
            this.tbxMongoEndpoint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxMongoEndpoint.Location = new System.Drawing.Point(7, 55);
            this.tbxMongoEndpoint.Name = "tbxMongoEndpoint";
            this.tbxMongoEndpoint.Size = new System.Drawing.Size(486, 20);
            this.tbxMongoEndpoint.TabIndex = 0;
            // 
            // lblMongoEndpoint
            // 
            this.lblMongoEndpoint.AutoSize = true;
            this.lblMongoEndpoint.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMongoEndpoint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.lblMongoEndpoint.Location = new System.Drawing.Point(3, 33);
            this.lblMongoEndpoint.Name = "lblMongoEndpoint";
            this.lblMongoEndpoint.Size = new System.Drawing.Size(68, 19);
            this.lblMongoEndpoint.TabIndex = 19;
            this.lblMongoEndpoint.Text = "Endpoint";
            // 
            // MongoSettings
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
            this.Name = "MongoSettings";
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

        private Forms.SIButton btnTestMongoSettings;
        private System.Windows.Forms.TextBox tbxMongoPassword;
        private Forms.SIH2 lblMongoPassword;
        private System.Windows.Forms.TextBox tbxMongoUsername;
        private Forms.SIH2 lblMongoUsername;
        private System.Windows.Forms.TextBox tbxMongoPort;
        private Forms.SIH2 lblPort;
        private System.Windows.Forms.TextBox tbxMongoEndpoint;
        private Forms.SIH2 lblMongoEndpoint;
    }
}
