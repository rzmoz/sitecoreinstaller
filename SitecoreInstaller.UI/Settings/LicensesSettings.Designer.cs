namespace SitecoreInstaller.UI.Settings
{
    partial class LicensesSettings
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
            this.selectLicense1 = new SitecoreInstaller.UI.UserSelections.SelectLicense();
            this.siButton1 = new SitecoreInstaller.UI.Forms.SIButton();
            this.addLicenseDnDControl1 = new SitecoreInstaller.UI.Settings.AddLicenseDnDControl();
            this.SuspendLayout();
            // 
            // selectLicense1
            // 
            this.selectLicense1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectLicense1.Location = new System.Drawing.Point(7, 36);
            this.selectLicense1.Name = "selectLicense1";
            this.selectLicense1.Size = new System.Drawing.Size(486, 50);
            this.selectLicense1.TabIndex = 101;
            // 
            // siButton1
            // 
            this.siButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.siButton1.BottomDividerColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(46)))));
            this.siButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.siButton1.DrawBottomDivider = false;
            this.siButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.siButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.siButton1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.siButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.siButton1.Location = new System.Drawing.Point(340, 89);
            this.siButton1.Name = "siButton1";
            this.siButton1.Size = new System.Drawing.Size(153, 23);
            this.siButton1.TabIndex = 103;
            this.siButton1.Text = "Delete selected license";
            this.siButton1.UseVisualStyleBackColor = true;
            // 
            // addLicenseDnDControl1
            // 
            this.addLicenseDnDControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addLicenseDnDControl1.BackColor = System.Drawing.Color.White;
            this.addLicenseDnDControl1.ColorHasFile = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(202)))), ((int)(((byte)(255)))));
            this.addLicenseDnDControl1.ColorInitial = System.Drawing.Color.White;
            this.addLicenseDnDControl1.ColorOnHoverFileNotOk = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.addLicenseDnDControl1.ColorOnHoverFileOk = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(237)))), ((int)(((byte)(204)))));
            this.addLicenseDnDControl1.Label = "Drop files here";
            this.addLicenseDnDControl1.Location = new System.Drawing.Point(7, 118);
            this.addLicenseDnDControl1.Name = "addLicenseDnDControl1";
            this.addLicenseDnDControl1.Size = new System.Drawing.Size(486, 175);
            this.addLicenseDnDControl1.SupportedFileExtension = "xml";
            this.addLicenseDnDControl1.TabIndex = 104;
            // 
            // LicensesSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.addLicenseDnDControl1);
            this.Controls.Add(this.siButton1);
            this.Controls.Add(this.selectLicense1);
            this.Name = "LicensesSettings";
            this.Controls.SetChildIndex(this.selectLicense1, 0);
            this.Controls.SetChildIndex(this.siButton1, 0);
            this.Controls.SetChildIndex(this.addLicenseDnDControl1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private UserSelections.SelectLicense selectLicense1;
        private Forms.SIButton siButton1;
        private AddLicenseDnDControl addLicenseDnDControl1;
    }
}
