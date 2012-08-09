namespace SitecoreInstaller.UI.Developer
{
    partial class SelectionsDeveloper
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
            this._selectProjectName1 = new SitecoreInstaller.UI.SelectProjectName();
            this.selectModules1 = new SitecoreInstaller.UI.SelectModules();
            this.selectSitecore1 = new SitecoreInstaller.UI.SelectSitecore();
            this.selectLicense1 = new SitecoreInstaller.UI.SelectLicense();
            this.SuspendLayout();
            // 
            // _selectProjectName1
            // 
            this._selectProjectName1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._selectProjectName1.Location = new System.Drawing.Point(25, 0);
            this._selectProjectName1.Name = "_selectProjectName1";
            this._selectProjectName1.Size = new System.Drawing.Size(250, 50);
            this._selectProjectName1.TabIndex = 0;
            // 
            // selectModules1
            // 
            this.selectModules1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectModules1.Location = new System.Drawing.Point(25, 150);
            this.selectModules1.Name = "selectModules1";
            this.selectModules1.Size = new System.Drawing.Size(250, 225);
            this.selectModules1.TabIndex = 3;
            // 
            // selectSitecore1
            // 
            this.selectSitecore1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectSitecore1.Location = new System.Drawing.Point(25, 50);
            this.selectSitecore1.Name = "selectSitecore1";
            this.selectSitecore1.Size = new System.Drawing.Size(250, 50);
            this.selectSitecore1.TabIndex = 1;
            // 
            // selectLicense1
            // 
            this.selectLicense1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectLicense1.Location = new System.Drawing.Point(25, 100);
            this.selectLicense1.Name = "selectLicense1";
            this.selectLicense1.Size = new System.Drawing.Size(250, 50);
            this.selectLicense1.TabIndex = 2;
            // 
            // SelectionsDeveloper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._selectProjectName1);
            this.Controls.Add(this.selectModules1);
            this.Controls.Add(this.selectSitecore1);
            this.Controls.Add(this.selectLicense1);
            this.Name = "SelectionsDeveloper";
            this.Size = new System.Drawing.Size(300, 375);
            this.ResumeLayout(false);

        }

        #endregion

        private SelectModules selectModules1;
        private SelectSitecore selectSitecore1;
        private SelectLicense selectLicense1;
        private SelectProjectName _selectProjectName1;
    }
}
