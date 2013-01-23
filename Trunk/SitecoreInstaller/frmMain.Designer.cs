namespace SitecoreInstaller
{
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.conMainContent = new System.Windows.Forms.SplitContainer();
            this.pnlMainNavigation = new System.Windows.Forms.Panel();
            this.mainNavigationCtrl1 = new SitecoreInstaller.UI.Navigation.MainNavigationCtrl();
            ((System.ComponentModel.ISupportInitialize)(this.conMainContent)).BeginInit();
            this.conMainContent.SuspendLayout();
            this.pnlMainNavigation.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(69)))), ((int)(((byte)(79)))));
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(698, 30);
            this.pnlHeader.TabIndex = 0;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(69)))), ((int)(((byte)(79)))));
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 315);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(698, 50);
            this.pnlFooter.TabIndex = 1;
            // 
            // conMainContent
            // 
            this.conMainContent.BackColor = System.Drawing.Color.White;
            this.conMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conMainContent.IsSplitterFixed = true;
            this.conMainContent.Location = new System.Drawing.Point(200, 30);
            this.conMainContent.Name = "conMainContent";
            this.conMainContent.Size = new System.Drawing.Size(498, 285);
            this.conMainContent.SplitterDistance = 252;
            this.conMainContent.TabIndex = 3;
            // 
            // pnlMainNavigation
            // 
            this.pnlMainNavigation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(177)))), ((int)(((byte)(209)))));
            this.pnlMainNavigation.Controls.Add(this.mainNavigationCtrl1);
            this.pnlMainNavigation.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMainNavigation.Location = new System.Drawing.Point(0, 30);
            this.pnlMainNavigation.Name = "pnlMainNavigation";
            this.pnlMainNavigation.Size = new System.Drawing.Size(200, 285);
            this.pnlMainNavigation.TabIndex = 2;
            // 
            // mainNavigationCtrl1
            // 
            this.mainNavigationCtrl1.BackColor = System.Drawing.Color.Transparent;
            this.mainNavigationCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainNavigationCtrl1.Location = new System.Drawing.Point(0, 0);
            this.mainNavigationCtrl1.Name = "mainNavigationCtrl1";
            this.mainNavigationCtrl1.Size = new System.Drawing.Size(200, 285);
            this.mainNavigationCtrl1.TabIndex = 0;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 365);
            this.Controls.Add(this.conMainContent);
            this.Controls.Add(this.pnlMainNavigation);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "SitecoreInstaller";
            ((System.ComponentModel.ISupportInitialize)(this.conMainContent)).EndInit();
            this.conMainContent.ResumeLayout(false);
            this.pnlMainNavigation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.SplitContainer conMainContent;
        private System.Windows.Forms.Panel pnlMainNavigation;
        private UI.Navigation.MainNavigationCtrl mainNavigationCtrl1;
    }
}