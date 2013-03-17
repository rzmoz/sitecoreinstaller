namespace SitecoreInstaller.UI
{
    partial class SelectSitecore
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
      this.cbxSitecore = new System.Windows.Forms.ComboBox();
      this.lblSitecore = new SitecoreInstaller.UI.Forms.SIH2();
      this.SuspendLayout();
      // 
      // cbxSitecore
      // 
      this.cbxSitecore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.cbxSitecore.BackColor = System.Drawing.SystemColors.Window;
      this.cbxSitecore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbxSitecore.FormattingEnabled = true;
      this.cbxSitecore.Location = new System.Drawing.Point(0, 25);
      this.cbxSitecore.Name = "cbxSitecore";
      this.cbxSitecore.Size = new System.Drawing.Size(400, 21);
      this.cbxSitecore.TabIndex = 0;
      this.cbxSitecore.SelectedIndexChanged += new System.EventHandler(this.cbxSitecore_SelectedIndexChanged);
      // 
      // lblSitecore
      // 
      this.lblSitecore.AutoSize = true;
      this.lblSitecore.Font = new System.Drawing.Font("Segoe UI", 10F);
      this.lblSitecore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.lblSitecore.Location = new System.Drawing.Point(0, 3);
      this.lblSitecore.Name = "lblSitecore";
      this.lblSitecore.Size = new System.Drawing.Size(60, 19);
      this.lblSitecore.TabIndex = 1;
      this.lblSitecore.Text = "Sitecore:";
      // 
      // SelectSitecore
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.lblSitecore);
      this.Controls.Add(this.cbxSitecore);
      this.Name = "SelectSitecore";
      this.Size = new System.Drawing.Size(400, 50);
      this.Load += new System.EventHandler(this.SelectSitecore_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxSitecore;
        private Forms.SIH2 lblSitecore;
    }
}
