namespace SitecoreInstaller.UI.UserSettingsDialogs
{
    partial class LicenseFileDialog
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
            this.selectLicense1 = new SitecoreInstaller.UI.SelectLicense();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tbxMoreOptions = new System.Windows.Forms.TextBox();
            this.lnkAdd = new System.Windows.Forms.LinkLabel();
            this.lnkRemoveSelected = new System.Windows.Forms.LinkLabel();
            this.tbxDescription = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // selectLicense1
            // 
            this.selectLicense1.Location = new System.Drawing.Point(115, 98);
            this.selectLicense1.Name = "selectLicense1";
            this.selectLicense1.Size = new System.Drawing.Size(270, 50);
            this.selectLicense1.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(217)))));
            this.lblTitle.Location = new System.Drawing.Point(115, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(85, 24);
            this.lblTitle.TabIndex = 24;
            this.lblTitle.Text = "Licenses";
            // 
            // tbxMoreOptions
            // 
            this.tbxMoreOptions.BackColor = System.Drawing.Color.White;
            this.tbxMoreOptions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxMoreOptions.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbxMoreOptions.Location = new System.Drawing.Point(115, 166);
            this.tbxMoreOptions.Multiline = true;
            this.tbxMoreOptions.Name = "tbxMoreOptions";
            this.tbxMoreOptions.ReadOnly = true;
            this.tbxMoreOptions.Size = new System.Drawing.Size(270, 78);
            this.tbxMoreOptions.TabIndex = 26;
            this.tbxMoreOptions.TabStop = false;
            this.tbxMoreOptions.Text = "Options:\r\n»\r\n\r\n»";
            // 
            // lnkAdd
            // 
            this.lnkAdd.AutoSize = true;
            this.lnkAdd.Location = new System.Drawing.Point(126, 183);
            this.lnkAdd.Name = "lnkAdd";
            this.lnkAdd.Size = new System.Drawing.Size(85, 13);
            this.lnkAdd.TabIndex = 27;
            this.lnkAdd.TabStop = true;
            this.lnkAdd.Text = "Add new license";
            this.lnkAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAddLicense_LinkClicked);
            // 
            // lnkRemoveSelected
            // 
            this.lnkRemoveSelected.AutoSize = true;
            this.lnkRemoveSelected.Location = new System.Drawing.Point(126, 208);
            this.lnkRemoveSelected.Name = "lnkRemoveSelected";
            this.lnkRemoveSelected.Size = new System.Drawing.Size(126, 13);
            this.lnkRemoveSelected.TabIndex = 28;
            this.lnkRemoveSelected.TabStop = true;
            this.lnkRemoveSelected.Text = "Remove selected license";
            this.lnkRemoveSelected.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRemoveSelected_LinkClicked);
            // 
            // tbxDescription
            // 
            this.tbxDescription.BackColor = System.Drawing.Color.White;
            this.tbxDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxDescription.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbxDescription.Location = new System.Drawing.Point(115, 70);
            this.tbxDescription.Multiline = true;
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.ReadOnly = true;
            this.tbxDescription.Size = new System.Drawing.Size(270, 22);
            this.tbxDescription.TabIndex = 29;
            this.tbxDescription.TabStop = false;
            this.tbxDescription.Text = "Maintain available licenses.";
            // 
            // LicenseFileDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbxDescription);
            this.Controls.Add(this.selectLicense1);
            this.Controls.Add(this.lnkRemoveSelected);
            this.Controls.Add(this.lnkAdd);
            this.Controls.Add(this.tbxMoreOptions);
            this.Controls.Add(this.lblTitle);
            this.Name = "LicenseFileDialog";
            this.Load += new System.EventHandler(this.LicenseFileDialog_Load);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.tbxMoreOptions, 0);
            this.Controls.SetChildIndex(this.lnkAdd, 0);
            this.Controls.SetChildIndex(this.lnkRemoveSelected, 0);
            this.Controls.SetChildIndex(this.selectLicense1, 0);
            this.Controls.SetChildIndex(this.tbxDescription, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SelectLicense selectLicense1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox tbxMoreOptions;
        private System.Windows.Forms.LinkLabel lnkAdd;
        private System.Windows.Forms.LinkLabel lnkRemoveSelected;
        private System.Windows.Forms.TextBox tbxDescription;
    }
}
