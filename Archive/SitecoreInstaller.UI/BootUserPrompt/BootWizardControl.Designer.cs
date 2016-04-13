namespace SitecoreInstaller.UI.BootUserPrompt
{
    partial class BootWizardControl
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
            this.btnFullyAutomated = new SitecoreInstaller.UI.Forms.SIButton();
            this.btnAdvancedSetup = new SitecoreInstaller.UI.Forms.SIButton();
            this.SuspendLayout();
            // 
            // btnFullyAutomated
            // 
            this.btnFullyAutomated.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFullyAutomated.BottomDividerColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(46)))));
            this.btnFullyAutomated.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFullyAutomated.DrawBottomDivider = false;
            this.btnFullyAutomated.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.btnFullyAutomated.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFullyAutomated.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.btnFullyAutomated.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.btnFullyAutomated.Location = new System.Drawing.Point(100, 100);
            this.btnFullyAutomated.Name = "btnFullyAutomated";
            this.btnFullyAutomated.Size = new System.Drawing.Size(400, 100);
            this.btnFullyAutomated.TabIndex = 0;
            this.btnFullyAutomated.Text = "Just get me started";
            this.btnFullyAutomated.UseVisualStyleBackColor = true;
            this.btnFullyAutomated.Click += new System.EventHandler(this.btnFullyAutomated_Click);
            // 
            // btnAdvancedSetup
            // 
            this.btnAdvancedSetup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdvancedSetup.BottomDividerColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(46)))));
            this.btnAdvancedSetup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdvancedSetup.DrawBottomDivider = false;
            this.btnAdvancedSetup.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.btnAdvancedSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdvancedSetup.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.btnAdvancedSetup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.btnAdvancedSetup.Location = new System.Drawing.Point(100, 250);
            this.btnAdvancedSetup.Name = "btnAdvancedSetup";
            this.btnAdvancedSetup.Size = new System.Drawing.Size(400, 75);
            this.btnAdvancedSetup.TabIndex = 2;
            this.btnAdvancedSetup.Text = "Advanced setup";
            this.btnAdvancedSetup.UseVisualStyleBackColor = true;
            this.btnAdvancedSetup.Click += new System.EventHandler(this.btnAdvancedSetup_Click);
            // 
            // BootWizardControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAdvancedSetup);
            this.Controls.Add(this.btnFullyAutomated);
            this.Name = "BootWizardControl";
            this.Size = new System.Drawing.Size(600, 450);
            this.ResumeLayout(false);

        }

        #endregion

        private Forms.SIButton btnFullyAutomated;
        private Forms.SIButton btnAdvancedSetup;
    }
}
