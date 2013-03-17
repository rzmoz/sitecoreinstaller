namespace SitecoreInstaller.UI
{
    partial class SelectLicense
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
      this.components = new System.ComponentModel.Container();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.cbxLicenses = new System.Windows.Forms.ComboBox();
      this.lblLicenses = new SitecoreInstaller.UI.Forms.SIH2();
      this.SuspendLayout();
      // 
      // cbxLicenses
      // 
      this.cbxLicenses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.cbxLicenses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbxLicenses.FormattingEnabled = true;
      this.cbxLicenses.Location = new System.Drawing.Point(0, 25);
      this.cbxLicenses.Name = "cbxLicenses";
      this.cbxLicenses.Size = new System.Drawing.Size(400, 21);
      this.cbxLicenses.TabIndex = 0;
      this.cbxLicenses.SelectedIndexChanged += new System.EventHandler(this.cbxLicenses_SelectedIndexChanged);
      // 
      // lblLicenses
      // 
      this.lblLicenses.AutoSize = true;
      this.lblLicenses.Font = new System.Drawing.Font("Segoe UI", 10F);
      this.lblLicenses.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.lblLicenses.Location = new System.Drawing.Point(0, 3);
      this.lblLicenses.Name = "lblLicenses";
      this.lblLicenses.Size = new System.Drawing.Size(56, 19);
      this.lblLicenses.TabIndex = 0;
      this.lblLicenses.Text = "License:";
      // 
      // SelectLicense
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.lblLicenses);
      this.Controls.Add(this.cbxLicenses);
      this.Name = "SelectLicense";
      this.Size = new System.Drawing.Size(400, 50);
      this.Load += new System.EventHandler(this.SelectLicense_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxLicenses;
        private System.Windows.Forms.ToolTip toolTip1;
        private Forms.SIH2 lblLicenses;
    }
}
