namespace SitecoreInstaller.UI.Navigation
{
    partial class MainNavigationCtrl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainNavigationCtrl));
            this.btnSettings = new SitecoreInstaller.UI.Navigation.MainNavigationButton();
            this.btnMySitecores = new SitecoreInstaller.UI.Navigation.MainNavigationButton();
            this.btnInstallNewSitecore = new SitecoreInstaller.UI.Navigation.MainNavigationButton();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(177)))), ((int)(((byte)(209)))));
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(155)))), ((int)(((byte)(189)))));
            this.btnSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(193)))), ((int)(((byte)(222)))));
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSettings.ForeColor = System.Drawing.Color.White;
            this.btnSettings.Image = global::SitecoreInstaller.UI.Properties.Resources.settings;
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.Location = new System.Drawing.Point(0, 350);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(200, 50);
            this.btnSettings.TabIndex = 2;
            this.btnSettings.Text = "Settings";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSettings.UseVisualStyleBackColor = false;
            // 
            // btnMySitecores
            // 
            this.btnMySitecores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(177)))), ((int)(((byte)(209)))));
            this.btnMySitecores.FlatAppearance.BorderSize = 0;
            this.btnMySitecores.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(155)))), ((int)(((byte)(189)))));
            this.btnMySitecores.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(193)))), ((int)(((byte)(222)))));
            this.btnMySitecores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMySitecores.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnMySitecores.ForeColor = System.Drawing.Color.White;
            this.btnMySitecores.Image = global::SitecoreInstaller.UI.Properties.Resources.ExistingInstallations;
            this.btnMySitecores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMySitecores.Location = new System.Drawing.Point(0, 0);
            this.btnMySitecores.Name = "btnMySitecores";
            this.btnMySitecores.Size = new System.Drawing.Size(200, 50);
            this.btnMySitecores.TabIndex = 0;
            this.btnMySitecores.Text = "My Sitecores";
            this.btnMySitecores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMySitecores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMySitecores.UseVisualStyleBackColor = false;
            // 
            // btnInstallNewSitecore
            // 
            this.btnInstallNewSitecore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(177)))), ((int)(((byte)(209)))));
            this.btnInstallNewSitecore.FlatAppearance.BorderSize = 0;
            this.btnInstallNewSitecore.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(155)))), ((int)(((byte)(189)))));
            this.btnInstallNewSitecore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(193)))), ((int)(((byte)(222)))));
            this.btnInstallNewSitecore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstallNewSitecore.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnInstallNewSitecore.ForeColor = System.Drawing.Color.White;
            this.btnInstallNewSitecore.Image = ((System.Drawing.Image)(resources.GetObject("btnInstallNewSitecore.Image")));
            this.btnInstallNewSitecore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInstallNewSitecore.Location = new System.Drawing.Point(0, 50);
            this.btnInstallNewSitecore.Name = "btnInstallNewSitecore";
            this.btnInstallNewSitecore.Size = new System.Drawing.Size(200, 50);
            this.btnInstallNewSitecore.TabIndex = 1;
            this.btnInstallNewSitecore.Text = "Install New Sitecore";
            this.btnInstallNewSitecore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInstallNewSitecore.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInstallNewSitecore.UseVisualStyleBackColor = false;
            // 
            // MainNavigationCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnMySitecores);
            this.Controls.Add(this.btnInstallNewSitecore);
            this.Name = "MainNavigationCtrl";
            this.Size = new System.Drawing.Size(200, 400);
            this.ResumeLayout(false);

        }

        #endregion

        private MainNavigationButton btnSettings;
        private MainNavigationButton btnMySitecores;
        private MainNavigationButton btnInstallNewSitecore;




    }
}
