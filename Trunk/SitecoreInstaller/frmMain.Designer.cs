namespace SitecoreInstaller
{
    using SitecoreInstaller.UI.Developer;
    using SitecoreInstaller.UI.Simple;

    partial class FrmMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sitecoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.installSitecoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uninstallSitecoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openSitecoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFrontendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsWizardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sqlSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildLibraryFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sitecoreStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.licenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.urlPostfixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.useDeveloperLayoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshSelectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doNothingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onlineHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.mainDeveloper1 = new SitecoreInstaller.UI.Developer.MainDeveloper();
            this.pipelineProgress1 = new SitecoreInstaller.UI.PipelineProgress();
            this.mainSimple1 = new SitecoreInstaller.UI.Simple.MainSimple();
            this.stepWizardDialog1 = new SitecoreInstaller.UI.UserSettingsDialogs.StepWizardDialog();
            this.logger1 = new SitecoreInstaller.UI.Logger();
            this.menuStrip1.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sitecoreToolStripMenuItem,
            this.preferencesToolStripMenuItem,
            this.viewToolStripMenuItem1,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(400, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sitecoreToolStripMenuItem
            // 
            this.sitecoreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.installSitecoreToolStripMenuItem,
            this.uninstallSitecoreToolStripMenuItem,
            this.openSitecoreToolStripMenuItem,
            this.openFrontendToolStripMenuItem});
            this.sitecoreToolStripMenuItem.Name = "sitecoreToolStripMenuItem";
            this.sitecoreToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.U)));
            this.sitecoreToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.sitecoreToolStripMenuItem.Text = "&Sitecore";
            // 
            // installSitecoreToolStripMenuItem
            // 
            this.installSitecoreToolStripMenuItem.Name = "installSitecoreToolStripMenuItem";
            this.installSitecoreToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.B)));
            this.installSitecoreToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.installSitecoreToolStripMenuItem.Text = "Install Sitecore!";
            this.installSitecoreToolStripMenuItem.Click += new System.EventHandler(this.installSitecoreToolStripMenuItem_Click);
            // 
            // uninstallSitecoreToolStripMenuItem
            // 
            this.uninstallSitecoreToolStripMenuItem.Name = "uninstallSitecoreToolStripMenuItem";
            this.uninstallSitecoreToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.U)));
            this.uninstallSitecoreToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.uninstallSitecoreToolStripMenuItem.Text = "Uninstall Sitecore";
            this.uninstallSitecoreToolStripMenuItem.Click += new System.EventHandler(this.uninstallSitecoreToolStripMenuItem_Click);
            // 
            // openSitecoreToolStripMenuItem
            // 
            this.openSitecoreToolStripMenuItem.Name = "openSitecoreToolStripMenuItem";
            this.openSitecoreToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.openSitecoreToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.openSitecoreToolStripMenuItem.Text = "Open Sitecore";
            this.openSitecoreToolStripMenuItem.Click += new System.EventHandler(this.openSitecoreToolStripMenuItem_Click);
            // 
            // openFrontendToolStripMenuItem
            // 
            this.openFrontendToolStripMenuItem.Name = "openFrontendToolStripMenuItem";
            this.openFrontendToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openFrontendToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.openFrontendToolStripMenuItem.Text = "Open Frontend";
            this.openFrontendToolStripMenuItem.Click += new System.EventHandler(this.openFrontendToolStripMenuItem_Click);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsWizardToolStripMenuItem,
            this.sqlSettingsToolStripMenuItem,
            this.projectToolStripMenuItem,
            this.buildLibraryFolderToolStripMenuItem,
            this.sitecoreStripMenuItem,
            this.licenseToolStripMenuItem,
            this.urlPostfixToolStripMenuItem});
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            // 
            // settingsWizardToolStripMenuItem
            // 
            this.settingsWizardToolStripMenuItem.Name = "settingsWizardToolStripMenuItem";
            this.settingsWizardToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.settingsWizardToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.settingsWizardToolStripMenuItem.Text = "Setup guide";
            this.settingsWizardToolStripMenuItem.Click += new System.EventHandler(this.settingsWizardToolStripMenuItem_Click);
            // 
            // sqlSettingsToolStripMenuItem
            // 
            this.sqlSettingsToolStripMenuItem.Name = "sqlSettingsToolStripMenuItem";
            this.sqlSettingsToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.sqlSettingsToolStripMenuItem.Text = "Sql settings...";
            this.sqlSettingsToolStripMenuItem.Click += new System.EventHandler(this.sqlSettingsToolStripMenuItem_Click);
            // 
            // projectToolStripMenuItem
            // 
            this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
            this.projectToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.projectToolStripMenuItem.Text = "Project folder...";
            this.projectToolStripMenuItem.Click += new System.EventHandler(this.projectToolStripMenuItem_Click);
            // 
            // buildLibraryFolderToolStripMenuItem
            // 
            this.buildLibraryFolderToolStripMenuItem.Name = "buildLibraryFolderToolStripMenuItem";
            this.buildLibraryFolderToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.buildLibraryFolderToolStripMenuItem.Text = "Build library folder...";
            this.buildLibraryFolderToolStripMenuItem.Click += new System.EventHandler(this.buildLibraryFolderToolStripMenuItem_Click);
            // 
            // sitecoreStripMenuItem
            // 
            this.sitecoreStripMenuItem.Name = "sitecoreStripMenuItem";
            this.sitecoreStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.sitecoreStripMenuItem.Text = "Sitecore files...";
            this.sitecoreStripMenuItem.Click += new System.EventHandler(this.sitecoreStripMenuItem_Click);
            // 
            // licenseToolStripMenuItem
            // 
            this.licenseToolStripMenuItem.Name = "licenseToolStripMenuItem";
            this.licenseToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.licenseToolStripMenuItem.Text = "Licenses...";
            this.licenseToolStripMenuItem.Click += new System.EventHandler(this.licenseToolStripMenuItem_Click);
            // 
            // urlPostfixToolStripMenuItem
            // 
            this.urlPostfixToolStripMenuItem.Name = "urlPostfixToolStripMenuItem";
            this.urlPostfixToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.urlPostfixToolStripMenuItem.Text = "Url Postfix...";
            this.urlPostfixToolStripMenuItem.Click += new System.EventHandler(this.urlPostfixToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem1
            // 
            this.viewToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.useDeveloperLayoutToolStripMenuItem,
            this.refreshSelectionsToolStripMenuItem,
            this.clearLogToolStripMenuItem,
            this.doNothingToolStripMenuItem,
            this.showLogToolStripMenuItem});
            this.viewToolStripMenuItem1.Name = "viewToolStripMenuItem1";
            this.viewToolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem1.Text = "View";
            // 
            // useDeveloperLayoutToolStripMenuItem
            // 
            this.useDeveloperLayoutToolStripMenuItem.Name = "useDeveloperLayoutToolStripMenuItem";
            this.useDeveloperLayoutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.D)));
            this.useDeveloperLayoutToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.useDeveloperLayoutToolStripMenuItem.Text = "Use Developer layout";
            this.useDeveloperLayoutToolStripMenuItem.Click += new System.EventHandler(this.useDeveloperLayoutToolStripMenuItem_Click);
            // 
            // refreshSelectionsToolStripMenuItem
            // 
            this.refreshSelectionsToolStripMenuItem.Name = "refreshSelectionsToolStripMenuItem";
            this.refreshSelectionsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.refreshSelectionsToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.refreshSelectionsToolStripMenuItem.Text = "Update lists";
            this.refreshSelectionsToolStripMenuItem.Click += new System.EventHandler(this.updateSelectionsToolStripMenuItem_Click);
            // 
            // clearLogToolStripMenuItem
            // 
            this.clearLogToolStripMenuItem.Name = "clearLogToolStripMenuItem";
            this.clearLogToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.clearLogToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.clearLogToolStripMenuItem.Text = "Clear log";
            this.clearLogToolStripMenuItem.Click += new System.EventHandler(this.clearLogToolStripMenuItem_Click);
            // 
            // doNothingToolStripMenuItem
            // 
            this.doNothingToolStripMenuItem.Name = "doNothingToolStripMenuItem";
            this.doNothingToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
            this.doNothingToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.doNothingToolStripMenuItem.Text = "Do Nothing...";
            this.doNothingToolStripMenuItem.Click += new System.EventHandler(this.doNothingToolStripMenuItem_Click_1);
            // 
            // showLogToolStripMenuItem
            // 
            this.showLogToolStripMenuItem.Name = "showLogToolStripMenuItem";
            this.showLogToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.L)));
            this.showLogToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.showLogToolStripMenuItem.Text = "Show Log";
            this.showLogToolStripMenuItem.Click += new System.EventHandler(this.showLogToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.onlineHelpToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // onlineHelpToolStripMenuItem
            // 
            this.onlineHelpToolStripMenuItem.Name = "onlineHelpToolStripMenuItem";
            this.onlineHelpToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.onlineHelpToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.onlineHelpToolStripMenuItem.Text = "Online help";
            this.onlineHelpToolStripMenuItem.Click += new System.EventHandler(this.onlineHelpToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.aboutToolStripMenuItem.Text = "About..";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.Controls.Add(this.mainDeveloper1);
            this.pnlMain.Controls.Add(this.pipelineProgress1);
            this.pnlMain.Controls.Add(this.mainSimple1);
            this.pnlMain.Controls.Add(this.stepWizardDialog1);
            this.pnlMain.Location = new System.Drawing.Point(0, 24);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(400, 400);
            this.pnlMain.TabIndex = 1;
            // 
            // mainDeveloper1
            // 
            this.mainDeveloper1.BackColor = System.Drawing.Color.White;
            this.mainDeveloper1.Location = new System.Drawing.Point(12, 53);
            this.mainDeveloper1.Name = "mainDeveloper1";
            this.mainDeveloper1.Size = new System.Drawing.Size(288, 323);
            this.mainDeveloper1.TabIndex = 6;
            // 
            // pipelineProgress1
            // 
            this.pipelineProgress1.BackColor = System.Drawing.Color.White;
            this.pipelineProgress1.Location = new System.Drawing.Point(37, 18);
            this.pipelineProgress1.Name = "pipelineProgress1";
            this.pipelineProgress1.Size = new System.Drawing.Size(284, 164);
            this.pipelineProgress1.TabIndex = 5;
            // 
            // mainSimple1
            // 
            this.mainSimple1.BackColor = System.Drawing.Color.White;
            this.mainSimple1.Location = new System.Drawing.Point(203, 36);
            this.mainSimple1.Name = "mainSimple1";
            this.mainSimple1.Size = new System.Drawing.Size(197, 146);
            this.mainSimple1.TabIndex = 3;
            // 
            // stepWizardDialog1
            // 
            this.stepWizardDialog1.BackColor = System.Drawing.Color.White;
            this.stepWizardDialog1.Location = new System.Drawing.Point(28, 53);
            this.stepWizardDialog1.Name = "stepWizardDialog1";
            this.stepWizardDialog1.Size = new System.Drawing.Size(400, 300);
            this.stepWizardDialog1.TabIndex = 7;
            // 
            // logger1
            // 
            this.logger1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logger1.BackColor = System.Drawing.Color.White;
            this.logger1.Location = new System.Drawing.Point(0, 424);
            this.logger1.Name = "logger1";
            this.logger1.ShowLogLevels = false;
            this.logger1.Size = new System.Drawing.Size(400, 200);
            this.logger1.TabIndex = 5;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 624);
            this.Controls.Add(this.logger1);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SitecoreInstaller";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sitecoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem installSitecoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uninstallSitecoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onlineHelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem useDeveloperLayoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshSelectionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doNothingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSitecoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFrontendToolStripMenuItem;
        private System.Windows.Forms.Panel pnlMain;
        private MainDeveloper mainDeveloper1;
        private UI.PipelineProgress pipelineProgress1;
        private MainSimple mainSimple1;
        private UI.Logger logger1;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sqlSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sitecoreStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsWizardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem licenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buildLibraryFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem urlPostfixToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLogToolStripMenuItem;
        private UI.UserSettingsDialogs.StepWizardDialog stepWizardDialog1;
    }
}