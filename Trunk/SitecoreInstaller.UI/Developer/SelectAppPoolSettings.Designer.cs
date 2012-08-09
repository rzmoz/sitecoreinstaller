namespace SitecoreInstaller.UI.Developer
{
    partial class SelectAppPoolSettings
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
            this.SuspendLayout();
            // 
            // lblManagedPipelineMode
            // 
            this.lblManagedPipelineMode.AutoSize = true;
            this.lblManagedPipelineMode.Location = new System.Drawing.Point(10, 106);
            this.lblManagedPipelineMode.Name = "lblManagedPipelineMode";
            this.lblManagedPipelineMode.Size = new System.Drawing.Size(73, 13);
            this.lblManagedPipelineMode.TabIndex = 14;
            this.lblManagedPipelineMode.Text = "Pipeline mode";
            // 
            // cbxManagedPipelineMode
            // 
            this.cbxManagedPipelineMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxManagedPipelineMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxManagedPipelineMode.FormattingEnabled = true;
            this.cbxManagedPipelineMode.Location = new System.Drawing.Point(10, 121);
            this.cbxManagedPipelineMode.Name = "cbxManagedPipelineMode";
            this.cbxManagedPipelineMode.Size = new System.Drawing.Size(80, 21);
            this.cbxManagedPipelineMode.TabIndex = 11;
            // 
            // chk32BitEnabled
            // 
            this.chk32BitEnabled.AutoSize = true;
            this.chk32BitEnabled.Location = new System.Drawing.Point(35, 76);
            this.chk32BitEnabled.Name = "chk32BitEnabled";
            this.chk32BitEnabled.Size = new System.Drawing.Size(15, 14);
            this.chk32BitEnabled.TabIndex = 10;
            this.chk32BitEnabled.UseVisualStyleBackColor = true;
            // 
            // lbl32BitEnabled
            // 
            this.lbl32BitEnabled.AutoSize = true;
            this.lbl32BitEnabled.Location = new System.Drawing.Point(10, 60);
            this.lbl32BitEnabled.Name = "lbl32BitEnabled";
            this.lbl32BitEnabled.Size = new System.Drawing.Size(74, 13);
            this.lbl32BitEnabled.TabIndex = 13;
            this.lbl32BitEnabled.Text = "32-bit enabled";
            // 
            // lblClrVersion
            // 
            this.lblClrVersion.AutoSize = true;
            this.lblClrVersion.Location = new System.Drawing.Point(10, 5);
            this.lblClrVersion.Name = "lblClrVersion";
            this.lblClrVersion.Size = new System.Drawing.Size(65, 13);
            this.lblClrVersion.TabIndex = 12;
            this.lblClrVersion.Text = "CLR version";
            // 
            // cbxClrVersion
            // 
            this.cbxClrVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxClrVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxClrVersion.FormattingEnabled = true;
            this.cbxClrVersion.Location = new System.Drawing.Point(10, 20);
            this.cbxClrVersion.Name = "cbxClrVersion";
            this.cbxClrVersion.Size = new System.Drawing.Size(80, 21);
            this.cbxClrVersion.TabIndex = 9;
            // 
            // SelectAppPoolSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblManagedPipelineMode);
            this.Controls.Add(this.cbxManagedPipelineMode);
            this.Controls.Add(this.chk32BitEnabled);
            this.Controls.Add(this.lbl32BitEnabled);
            this.Controls.Add(this.lblClrVersion);
            this.Controls.Add(this.cbxClrVersion);
            this.Name = "SelectAppPoolSettings";
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

    }
}
