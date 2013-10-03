namespace SitecoreInstaller
{
  partial class FrmSplashScreen
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSplashScreen));
      this.lblTitle = new System.Windows.Forms.Label();
      this.picLogo = new System.Windows.Forms.PictureBox();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.lblLog = new SitecoreInstaller.UI.Forms.SILabel();
      this.stepWizard1 = new SitecoreInstaller.UI.FirstRun.StepWizard();
      ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
      this.SuspendLayout();
      // 
      // lblTitle
      // 
      this.lblTitle.BackColor = System.Drawing.Color.Transparent;
      this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblTitle.ForeColor = System.Drawing.Color.White;
      this.lblTitle.Location = new System.Drawing.Point(0, 0);
      this.lblTitle.Name = "lblTitle";
      this.lblTitle.Size = new System.Drawing.Size(602, 288);
      this.lblTitle.TabIndex = 0;
      this.lblTitle.Text = "SitecoreInstaller is loading...";
      this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // picLogo
      // 
      this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
      this.picLogo.Location = new System.Drawing.Point(155, 180);
      this.picLogo.Name = "picLogo";
      this.picLogo.Size = new System.Drawing.Size(75, 75);
      this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.picLogo.TabIndex = 1;
      this.picLogo.TabStop = false;
      // 
      // timer1
      // 
      this.timer1.Interval = 20;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // lblLog
      // 
      this.lblLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.lblLog.Font = new System.Drawing.Font("Segoe UI", 8F);
      this.lblLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.lblLog.Location = new System.Drawing.Point(49, 266);
      this.lblLog.Name = "lblLog";
      this.lblLog.Size = new System.Drawing.Size(541, 16);
      this.lblLog.TabIndex = 3;
      this.lblLog.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // stepWizard1
      // 
      this.stepWizard1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.stepWizard1.Location = new System.Drawing.Point(0, 0);
      this.stepWizard1.Name = "stepWizard1";
      this.stepWizard1.Size = new System.Drawing.Size(602, 288);
      this.stepWizard1.TabIndex = 2;
      this.stepWizard1.Visible = false;
      // 
      // FrmSplashScreen
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(46)))));
      this.ClientSize = new System.Drawing.Size(602, 288);
      this.Controls.Add(this.lblLog);
      this.Controls.Add(this.picLogo);
      this.Controls.Add(this.lblTitle);
      this.Controls.Add(this.stepWizard1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "FrmSplashScreen";
      this.Text = "SitecoreInstaller";
      ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.PictureBox picLogo;
    private System.Windows.Forms.Timer timer1;
    private UI.FirstRun.StepWizard stepWizard1;
    private UI.Forms.SILabel lblLog;

  }
}