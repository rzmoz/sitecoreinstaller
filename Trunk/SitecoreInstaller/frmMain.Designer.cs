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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.pnlMainNavigation = new System.Windows.Forms.Panel();
            this.conMainContent = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.conMainContent)).BeginInit();
            this.conMainContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(626, 50);
            this.pnlHeader.TabIndex = 0;
            // 
            // pnlFooter
            // 
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 396);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(626, 100);
            this.pnlFooter.TabIndex = 1;
            // 
            // pnlMainNavigation
            // 
            this.pnlMainNavigation.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMainNavigation.Location = new System.Drawing.Point(0, 50);
            this.pnlMainNavigation.Name = "pnlMainNavigation";
            this.pnlMainNavigation.Size = new System.Drawing.Size(200, 346);
            this.pnlMainNavigation.TabIndex = 2;
            // 
            // conMainContent
            // 
            this.conMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conMainContent.IsSplitterFixed = true;
            this.conMainContent.Location = new System.Drawing.Point(200, 50);
            this.conMainContent.Name = "conMainContent";
            this.conMainContent.Size = new System.Drawing.Size(426, 346);
            this.conMainContent.SplitterDistance = 217;
            this.conMainContent.TabIndex = 3;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 496);
            this.Controls.Add(this.conMainContent);
            this.Controls.Add(this.pnlMainNavigation);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            ((System.ComponentModel.ISupportInitialize)(this.conMainContent)).EndInit();
            this.conMainContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlMainNavigation;
        private System.Windows.Forms.SplitContainer conMainContent;
    }
}