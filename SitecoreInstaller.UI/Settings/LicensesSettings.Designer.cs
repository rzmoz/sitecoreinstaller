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
            this.btnDeleteSelectedLicense = new SitecoreInstaller.UI.Forms.SIButton();
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
            // btnDeleteSelectedLicense
            // 
            this.btnDeleteSelectedLicense.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteSelectedLicense.BottomDividerColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(46)))));
            this.btnDeleteSelectedLicense.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeleteSelectedLicense.DrawBottomDivider = false;
            this.btnDeleteSelectedLicense.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.btnDeleteSelectedLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteSelectedLicense.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnDeleteSelectedLicense.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.btnDeleteSelectedLicense.Location = new System.Drawing.Point(340, 89);
            this.btnDeleteSelectedLicense.Name = "btnDeleteSelectedLicense";
            this.btnDeleteSelectedLicense.Size = new System.Drawing.Size(153, 23);
            this.btnDeleteSelectedLicense.TabIndex = 103;
            this.btnDeleteSelectedLicense.Text = "Delete selected license";
            this.btnDeleteSelectedLicense.UseVisualStyleBackColor = true;
            this.btnDeleteSelectedLicense.Click += new System.EventHandler(this.btnDeleteSelectedLicense_Click);
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
            this.addLicenseDnDControl1.UpdateTextWithFileNamesAfterDrop = true;
            // 
            // LicensesSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.addLicenseDnDControl1);
            this.Controls.Add(this.btnDeleteSelectedLicense);
            this.Controls.Add(this.selectLicense1);
            this.Name = "LicensesSettings";
            this.Controls.SetChildIndex(this.selectLicense1, 0);
            this.Controls.SetChildIndex(this.btnDeleteSelectedLicense, 0);
            this.Controls.SetChildIndex(this.addLicenseDnDControl1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private UserSelections.SelectLicense selectLicense1;
        private Forms.SIButton btnDeleteSelectedLicense;
        private AddLicenseDnDControl addLicenseDnDControl1;
    }
}
