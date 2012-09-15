namespace SitecoreInstaller.UI.Simple
{
    partial class ReinstallSimple
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnReinstall = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.selectLicense1 = new SitecoreInstaller.UI.SelectLicense();
            this.selectProjectName1 = new SitecoreInstaller.UI.SelectProjectName();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(27)))), ((int)(((byte)(82)))));
            this.btnCancel.Location = new System.Drawing.Point(25, 200);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Back";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnReinstall
            // 
            this.btnReinstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReinstall.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReinstall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(27)))), ((int)(((byte)(82)))));
            this.btnReinstall.Location = new System.Drawing.Point(275, 200);
            this.btnReinstall.Name = "btnReinstall";
            this.btnReinstall.Size = new System.Drawing.Size(100, 30);
            this.btnReinstall.TabIndex = 8;
            this.btnReinstall.Text = "Reinstall";
            this.btnReinstall.UseVisualStyleBackColor = false;
            this.btnReinstall.Click += new System.EventHandler(this.btnReinstall_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(217)))));
            this.lblTitle.Location = new System.Drawing.Point(25, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(170, 24);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "Enter project name";
            // 
            // selectLicense1
            // 
            this.selectLicense1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectLicense1.Location = new System.Drawing.Point(25, 128);
            this.selectLicense1.Name = "selectLicense1";
            this.selectLicense1.Size = new System.Drawing.Size(350, 50);
            this.selectLicense1.TabIndex = 10;
            this.selectLicense1.TabStop = false;
            // 
            // selectProjectName1
            // 
            this.selectProjectName1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectProjectName1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.selectProjectName1.Location = new System.Drawing.Point(25, 66);
            this.selectProjectName1.Name = "selectProjectName1";
            this.selectProjectName1.ProjectName = "";
            this.selectProjectName1.Size = new System.Drawing.Size(350, 50);
            this.selectProjectName1.TabIndex = 11;
            // 
            // ReinstallSimple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.selectProjectName1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnReinstall);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.selectLicense1);
            this.Name = "ReinstallSimple";
            this.Size = new System.Drawing.Size(400, 300);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnReinstall;
        private System.Windows.Forms.Label lblTitle;
        private SelectLicense selectLicense1;
        private SelectProjectName selectProjectName1;
    }
}
