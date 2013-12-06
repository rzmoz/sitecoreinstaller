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
            this.siButton1 = new SitecoreInstaller.UI.Forms.SIButton();
            this.SuspendLayout();
            // 
            // siButton1
            // 
            this.siButton1.BottomDividerColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(46)))));
            this.siButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.siButton1.DrawBottomDivider = false;
            this.siButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.siButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.siButton1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.siButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.siButton1.Location = new System.Drawing.Point(341, 116);
            this.siButton1.Name = "siButton1";
            this.siButton1.Size = new System.Drawing.Size(75, 23);
            this.siButton1.TabIndex = 0;
            this.siButton1.Text = "siButton1";
            this.siButton1.UseVisualStyleBackColor = true;
            this.siButton1.Click += new System.EventHandler(this.siButton1_Click);
            // 
            // BootWizardControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.siButton1);
            this.Name = "BootWizardControl";
            this.Size = new System.Drawing.Size(499, 327);
            this.ResumeLayout(false);

        }

        #endregion

        private Forms.SIButton siButton1;
    }
}
