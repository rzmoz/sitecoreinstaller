namespace SitecoreInstaller.UI.UserSelections
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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
      this.chkModules = new System.Windows.Forms.CheckedListBox();
      this.lblModules = new SitecoreInstaller.UI.Forms.SIH2();
      this.SuspendLayout();
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
      // lblModules
      // 
      this.lblModules.AutoSize = true;
      this.lblModules.Font = new System.Drawing.Font("Segoe UI", 10F);
      this.lblModules.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.lblModules.Location = new System.Drawing.Point(0, 5);
      this.lblModules.Name = "lblModules";
      this.lblModules.Size = new System.Drawing.Size(65, 19);
      this.lblModules.TabIndex = 1;
      this.lblModules.Text = "Modules:";
      // 
      // SelectModules
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.lblModules);
      this.Controls.Add(this.chkModules);
      this.Name = "SelectModules";
      this.Size = new System.Drawing.Size(400, 216);
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox chkModules;
        private Forms.SIH2 lblModules;
    }
}
