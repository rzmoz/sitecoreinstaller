namespace SitecoreInstaller.UI.Loading
{
  partial class SplashScreen
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
      this.picLogo = new System.Windows.Forms.PictureBox();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
      this.SuspendLayout();
      // 
      // picLogo
      // 
      this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
      this.picLogo.Location = new System.Drawing.Point(262, 238);
      this.picLogo.Name = "picLogo";
      this.picLogo.Size = new System.Drawing.Size(75, 75);
      this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.picLogo.TabIndex = 2;
      this.picLogo.TabStop = false;
      // 
      // timer1
      // 
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // SplashScreen
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.picLogo);
      this.Name = "SplashScreen";
      this.Size = new System.Drawing.Size(637, 353);
      ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox picLogo;
    private System.Windows.Forms.Timer timer1;
  }
}
