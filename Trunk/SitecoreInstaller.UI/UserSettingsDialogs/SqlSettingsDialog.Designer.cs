namespace SitecoreInstaller.UI.UserSettingsDialogs
{
    partial class SqlSettingsDialog
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.tbxSqlUserId = new System.Windows.Forms.TextBox();
            this.lblSqlUserId = new System.Windows.Forms.Label();
            this.tbxSqlPassword = new System.Windows.Forms.TextBox();
            this.lblSqlPassword = new System.Windows.Forms.Label();
            this.tbxSqlInstanceName = new System.Windows.Forms.TextBox();
            this.lblSqlInstanceName = new System.Windows.Forms.Label();
            this.btnTestSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(217)))));
            this.lblTitle.Location = new System.Drawing.Point(115, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(105, 24);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "Sql settings";
            // 
            // tbxSqlUserId
            // 
            this.tbxSqlUserId.Location = new System.Drawing.Point(115, 135);
            this.tbxSqlUserId.Name = "tbxSqlUserId";
            this.tbxSqlUserId.Size = new System.Drawing.Size(270, 20);
            this.tbxSqlUserId.TabIndex = 1;
            // 
            // lblSqlUserId
            // 
            this.lblSqlUserId.AutoSize = true;
            this.lblSqlUserId.Location = new System.Drawing.Point(115, 120);
            this.lblSqlUserId.Name = "lblSqlUserId";
            this.lblSqlUserId.Size = new System.Drawing.Size(200, 13);
            this.lblSqlUserId.TabIndex = 22;
            this.lblSqlUserId.Text = "Sql user id (must be in sysadmin Sql role):";
            // 
            // tbxSqlPassword
            // 
            this.tbxSqlPassword.Location = new System.Drawing.Point(115, 185);
            this.tbxSqlPassword.Name = "tbxSqlPassword";
            this.tbxSqlPassword.Size = new System.Drawing.Size(270, 20);
            this.tbxSqlPassword.TabIndex = 2;
            this.tbxSqlPassword.UseSystemPasswordChar = true;
            // 
            // lblSqlPassword
            // 
            this.lblSqlPassword.AutoSize = true;
            this.lblSqlPassword.Location = new System.Drawing.Point(115, 170);
            this.lblSqlPassword.Name = "lblSqlPassword";
            this.lblSqlPassword.Size = new System.Drawing.Size(73, 13);
            this.lblSqlPassword.TabIndex = 21;
            this.lblSqlPassword.Text = "Sql password:";
            // 
            // tbxSqlInstanceName
            // 
            this.tbxSqlInstanceName.Location = new System.Drawing.Point(115, 85);
            this.tbxSqlInstanceName.Name = "tbxSqlInstanceName";
            this.tbxSqlInstanceName.Size = new System.Drawing.Size(270, 20);
            this.tbxSqlInstanceName.TabIndex = 0;
            // 
            // lblSqlInstanceName
            // 
            this.lblSqlInstanceName.AutoSize = true;
            this.lblSqlInstanceName.Location = new System.Drawing.Point(115, 70);
            this.lblSqlInstanceName.Name = "lblSqlInstanceName";
            this.lblSqlInstanceName.Size = new System.Drawing.Size(97, 13);
            this.lblSqlInstanceName.TabIndex = 20;
            this.lblSqlInstanceName.Text = "Sql instance name:";
            // 
            // btnTestSettings
            // 
            this.btnTestSettings.Location = new System.Drawing.Point(265, 211);
            this.btnTestSettings.Name = "btnTestSettings";
            this.btnTestSettings.Size = new System.Drawing.Size(120, 23);
            this.btnTestSettings.TabIndex = 3;
            this.btnTestSettings.Text = "Test Sql settings";
            this.btnTestSettings.UseVisualStyleBackColor = false;
            this.btnTestSettings.Click += new System.EventHandler(this.btnTestSql_Click);
            // 
            // SqlSettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnTestSettings);
            this.Controls.Add(this.tbxSqlUserId);
            this.Controls.Add(this.lblSqlUserId);
            this.Controls.Add(this.tbxSqlPassword);
            this.Controls.Add(this.lblSqlPassword);
            this.Controls.Add(this.tbxSqlInstanceName);
            this.Controls.Add(this.lblSqlInstanceName);
            this.Controls.Add(this.lblTitle);
            this.Name = "SqlSettingsDialog";
            this.Load += new System.EventHandler(this.SqlSettingsDialog_Load);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.lblSqlInstanceName, 0);
            this.Controls.SetChildIndex(this.tbxSqlInstanceName, 0);
            this.Controls.SetChildIndex(this.lblSqlPassword, 0);
            this.Controls.SetChildIndex(this.tbxSqlPassword, 0);
            this.Controls.SetChildIndex(this.lblSqlUserId, 0);
            this.Controls.SetChildIndex(this.tbxSqlUserId, 0);
            this.Controls.SetChildIndex(this.btnTestSettings, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox tbxSqlUserId;
        private System.Windows.Forms.Label lblSqlUserId;
        private System.Windows.Forms.TextBox tbxSqlPassword;
        private System.Windows.Forms.Label lblSqlPassword;
        private System.Windows.Forms.TextBox tbxSqlInstanceName;
        private System.Windows.Forms.Label lblSqlInstanceName;
        private System.Windows.Forms.Button btnTestSettings;


    }
}
