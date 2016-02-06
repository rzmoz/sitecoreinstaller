namespace SitecoreInstaller.UI.Settings
{
    partial class AutoSetupSettings
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
            this.btnFullyAutomated.Location = new System.Drawing.Point(50, 100);
            this.btnFullyAutomated.Name = "btnFullyAutomated";
            this.btnFullyAutomated.Size = new System.Drawing.Size(400, 100);
            this.btnFullyAutomated.TabIndex = 101;
            this.btnFullyAutomated.Text = "Run Auto Setup";
            this.btnFullyAutomated.UseVisualStyleBackColor = true;
            this.btnFullyAutomated.Click += new System.EventHandler(this.btnFullyAutomated_Click);
            // 
            // AutoSetupSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnFullyAutomated);
            this.Name = "AutoSetupSettings";
            this.Controls.SetChildIndex(this.btnFullyAutomated, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private Forms.SIButton btnFullyAutomated;
    }
}
