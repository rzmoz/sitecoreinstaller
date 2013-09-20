namespace SitecoreInstaller.UI.FirstRun
{
    partial class StepWizard
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
            this.lblTitle = new SitecoreInstaller.UI.Forms.SIH1();
            this.SuspendLayout();
            // 
            // siButton1
            // 
            this.siButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.siButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.siButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.siButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.siButton1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.siButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.siButton1.Location = new System.Drawing.Point(558, 197);
            this.siButton1.Name = "siButton1";
            this.siButton1.Size = new System.Drawing.Size(75, 23);
            this.siButton1.TabIndex = 1;
            this.siButton1.Text = "siButton1";
            this.siButton1.UseVisualStyleBackColor = true;
            this.siButton1.Click += new System.EventHandler(this.siButton1_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(16, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(98, 21);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "StepWizard";
            // 
            // StepWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.siButton1);
            this.Controls.Add(this.lblTitle);
            this.Name = "StepWizard";
            this.Size = new System.Drawing.Size(680, 256);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Forms.SIH1 lblTitle;
        private Forms.SIButton siButton1;
    }
}
