namespace SitecoreInstaller.UI.Simple
{
    partial class InstallSimple
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
            this.tbxProjectName = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnInstall = new System.Windows.Forms.Button();
            this.selectLicense1 = new SitecoreInstaller.UI.SelectLicense();
            this.selectSitecore1 = new SitecoreInstaller.UI.SelectSitecore();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(217)))));
            this.lblTitle.Location = new System.Drawing.Point(25, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(170, 24);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Enter project name";
            // 
            // tbxProjectName
            // 
            this.tbxProjectName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxProjectName.Location = new System.Drawing.Point(25, 60);
            this.tbxProjectName.Name = "tbxProjectName";
            this.tbxProjectName.Size = new System.Drawing.Size(250, 20);
            this.tbxProjectName.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(27)))), ((int)(((byte)(82)))));
            this.btnCancel.Location = new System.Drawing.Point(25, 185);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Back";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnInstall
            // 
            this.btnInstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInstall.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInstall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(27)))), ((int)(((byte)(82)))));
            this.btnInstall.Location = new System.Drawing.Point(175, 185);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(100, 30);
            this.btnInstall.TabIndex = 3;
            this.btnInstall.Text = "Install";
            this.btnInstall.UseVisualStyleBackColor = false;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // selectLicense1
            // 
            this.selectLicense1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectLicense1.Location = new System.Drawing.Point(25, 128);
            this.selectLicense1.Name = "selectLicense1";
            this.selectLicense1.Size = new System.Drawing.Size(250, 50);
            this.selectLicense1.TabIndex = 4;
            this.selectLicense1.TabStop = false;
            // 
            // selectSitecore1
            // 
            this.selectSitecore1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectSitecore1.Location = new System.Drawing.Point(25, 81);
            this.selectSitecore1.Name = "selectSitecore1";
            this.selectSitecore1.Size = new System.Drawing.Size(250, 50);
            this.selectSitecore1.TabIndex = 1;
            // 
            // InstallSimple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.tbxProjectName);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.selectLicense1);
            this.Controls.Add(this.selectSitecore1);
            this.Name = "InstallSimple";
            this.Size = new System.Drawing.Size(300, 250);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox tbxProjectName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnInstall;
        private SelectLicense selectLicense1;
        private SelectSitecore selectSitecore1;
    }
}
