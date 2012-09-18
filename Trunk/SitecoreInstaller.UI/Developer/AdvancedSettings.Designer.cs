namespace SitecoreInstaller.UI.Developer
{
    partial class AdvancedSettings
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
            this.lblManagedPipelineMode = new System.Windows.Forms.Label();
            this.cbxManagedPipelineMode = new System.Windows.Forms.ComboBox();
            this.chk32BitEnabled = new System.Windows.Forms.CheckBox();
            this.lbl32BitEnabled = new System.Windows.Forms.Label();
            this.lblClrVersion = new System.Windows.Forms.Label();
            this.cbxClrVersion = new System.Windows.Forms.ComboBox();
            this.lblInstallType = new System.Windows.Forms.Label();
            this.cbxInstallType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblManagedPipelineMode
            // 
            this.lblManagedPipelineMode.AutoSize = true;
            this.lblManagedPipelineMode.Location = new System.Drawing.Point(11, 111);
            this.lblManagedPipelineMode.Name = "lblManagedPipelineMode";
            this.lblManagedPipelineMode.Size = new System.Drawing.Size(73, 13);
            this.lblManagedPipelineMode.TabIndex = 20;
            this.lblManagedPipelineMode.Text = "Pipeline mode";
            // 
            // cbxManagedPipelineMode
            // 
            this.cbxManagedPipelineMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxManagedPipelineMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxManagedPipelineMode.FormattingEnabled = true;
            this.cbxManagedPipelineMode.Location = new System.Drawing.Point(11, 126);
            this.cbxManagedPipelineMode.Name = "cbxManagedPipelineMode";
            this.cbxManagedPipelineMode.Size = new System.Drawing.Size(80, 21);
            this.cbxManagedPipelineMode.TabIndex = 17;
            // 
            // chk32BitEnabled
            // 
            this.chk32BitEnabled.AutoSize = true;
            this.chk32BitEnabled.Location = new System.Drawing.Point(36, 81);
            this.chk32BitEnabled.Name = "chk32BitEnabled";
            this.chk32BitEnabled.Size = new System.Drawing.Size(15, 14);
            this.chk32BitEnabled.TabIndex = 16;
            this.chk32BitEnabled.UseVisualStyleBackColor = true;
            // 
            // lbl32BitEnabled
            // 
            this.lbl32BitEnabled.AutoSize = true;
            this.lbl32BitEnabled.Location = new System.Drawing.Point(11, 65);
            this.lbl32BitEnabled.Name = "lbl32BitEnabled";
            this.lbl32BitEnabled.Size = new System.Drawing.Size(74, 13);
            this.lbl32BitEnabled.TabIndex = 19;
            this.lbl32BitEnabled.Text = "32-bit enabled";
            // 
            // lblClrVersion
            // 
            this.lblClrVersion.AutoSize = true;
            this.lblClrVersion.Location = new System.Drawing.Point(11, 10);
            this.lblClrVersion.Name = "lblClrVersion";
            this.lblClrVersion.Size = new System.Drawing.Size(65, 13);
            this.lblClrVersion.TabIndex = 18;
            this.lblClrVersion.Text = "CLR version";
            // 
            // cbxClrVersion
            // 
            this.cbxClrVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxClrVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxClrVersion.FormattingEnabled = true;
            this.cbxClrVersion.Location = new System.Drawing.Point(11, 25);
            this.cbxClrVersion.Name = "cbxClrVersion";
            this.cbxClrVersion.Size = new System.Drawing.Size(80, 21);
            this.cbxClrVersion.TabIndex = 15;
            // 
            // lblInstallType
            // 
            this.lblInstallType.AutoSize = true;
            this.lblInstallType.Location = new System.Drawing.Point(8, 172);
            this.lblInstallType.Name = "lblInstallType";
            this.lblInstallType.Size = new System.Drawing.Size(57, 13);
            this.lblInstallType.TabIndex = 22;
            this.lblInstallType.Text = "Install type";
            // 
            // cbxInstallType
            // 
            this.cbxInstallType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxInstallType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxInstallType.FormattingEnabled = true;
            this.cbxInstallType.Location = new System.Drawing.Point(8, 187);
            this.cbxInstallType.Name = "cbxInstallType";
            this.cbxInstallType.Size = new System.Drawing.Size(80, 21);
            this.cbxInstallType.TabIndex = 21;
            // 
            // AdvancedSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblInstallType);
            this.Controls.Add(this.cbxInstallType);
            this.Controls.Add(this.lblManagedPipelineMode);
            this.Controls.Add(this.cbxManagedPipelineMode);
            this.Controls.Add(this.chk32BitEnabled);
            this.Controls.Add(this.lbl32BitEnabled);
            this.Controls.Add(this.lblClrVersion);
            this.Controls.Add(this.cbxClrVersion);
            this.Name = "AdvancedSettings";
            this.Size = new System.Drawing.Size(100, 250);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblManagedPipelineMode;
        private System.Windows.Forms.ComboBox cbxManagedPipelineMode;
        private System.Windows.Forms.CheckBox chk32BitEnabled;
        private System.Windows.Forms.Label lbl32BitEnabled;
        private System.Windows.Forms.Label lblClrVersion;
        private System.Windows.Forms.ComboBox cbxClrVersion;
        private System.Windows.Forms.Label lblInstallType;
        private System.Windows.Forms.ComboBox cbxInstallType;
    }
}
