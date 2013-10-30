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
      this.mainCtrl1 = new SitecoreInstaller.UI.MainCtrl();
      this.splashScreen1 = new SitecoreInstaller.UI.Loading.SplashScreen();
      this.SuspendLayout();
      // 
      // mainCtrl1
      // 
      this.mainCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mainCtrl1.Location = new System.Drawing.Point(0, 0);
      this.mainCtrl1.Name = "mainCtrl1";
      this.mainCtrl1.Size = new System.Drawing.Size(584, 412);
      this.mainCtrl1.TabIndex = 0;
      // 
      // splashScreen1
      // 
      this.splashScreen1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(46)))));
      this.splashScreen1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splashScreen1.Location = new System.Drawing.Point(0, 0);
      this.splashScreen1.Name = "splashScreen1";
      this.splashScreen1.Size = new System.Drawing.Size(584, 412);
      this.splashScreen1.TabIndex = 1;
      // 
      // FrmMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.White;
      this.ClientSize = new System.Drawing.Size(584, 412);
      this.Controls.Add(this.splashScreen1);
      this.Controls.Add(this.mainCtrl1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "FrmMain";
      this.Text = "SitecoreInstaller";
      this.ResumeLayout(false);

        }

        #endregion

        private UI.MainCtrl mainCtrl1;
        private UI.Loading.SplashScreen splashScreen1;

    }
}