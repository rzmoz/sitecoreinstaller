namespace SitecoreInstaller.UI
{
    partial class SelectModules
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
            this.lblModules = new System.Windows.Forms.Label();
            this.chkModules = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // lblModules
            // 
            this.lblModules.AutoSize = true;
            this.lblModules.Location = new System.Drawing.Point(0, 10);
            this.lblModules.Name = "lblModules";
            this.lblModules.Size = new System.Drawing.Size(50, 13);
            this.lblModules.TabIndex = 0;
            this.lblModules.Text = "Modules:";
            // 
            // chkModules
            // 
            this.chkModules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkModules.CheckOnClick = true;
            this.chkModules.FormattingEnabled = true;
            this.chkModules.Location = new System.Drawing.Point(0, 25);
            this.chkModules.Name = "chkModules";
            this.chkModules.ScrollAlwaysVisible = true;
            this.chkModules.Size = new System.Drawing.Size(400, 184);
            this.chkModules.TabIndex = 0;
            this.chkModules.ThreeDCheckBoxes = true;
            // 
            // SelectModules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkModules);
            this.Controls.Add(this.lblModules);
            this.Name = "SelectModules";
            this.Size = new System.Drawing.Size(400, 216);
            this.Load += new System.EventHandler(this.SelectModules_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblModules;
        private System.Windows.Forms.CheckedListBox chkModules;
    }
}
