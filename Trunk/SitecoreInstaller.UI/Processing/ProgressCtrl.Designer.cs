namespace SitecoreInstaller.UI.Processing
{
  using SitecoreInstaller.UI.Forms;

  partial class ProgressCtrl
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
      this.lblInfo = new SitecoreInstaller.UI.Forms.SILabel();
      this.lblProgress = new SitecoreInstaller.UI.Forms.SILabel();
      this.lblStatusMessage = new SitecoreInstaller.UI.Forms.SIH2();
      this.lblTitle = new SitecoreInstaller.UI.Forms.SIH1();
      this.btnOk = new SitecoreInstaller.UI.Forms.SIButton();
      this.picWaitAnimation = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.picWaitAnimation)).BeginInit();
      this.SuspendLayout();
      // 
      // lblInfo
      // 
      this.lblInfo.AutoSize = true;
      this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 8F);
      this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.lblInfo.Location = new System.Drawing.Point(74, 84);
      this.lblInfo.Name = "lblInfo";
      this.lblInfo.Size = new System.Drawing.Size(71, 13);
      this.lblInfo.TabIndex = 7;
      this.lblInfo.Text = "Processing...";
      // 
      // lblProgress
      // 
      this.lblProgress.AutoSize = true;
      this.lblProgress.Font = new System.Drawing.Font("Segoe UI", 8F);
      this.lblProgress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.lblProgress.Location = new System.Drawing.Point(74, 119);
      this.lblProgress.Name = "lblProgress";
      this.lblProgress.Size = new System.Drawing.Size(66, 13);
      this.lblProgress.TabIndex = 6;
      this.lblProgress.Text = "Executing...";
      // 
      // lblStatusMessage
      // 
      this.lblStatusMessage.AutoSize = true;
      this.lblStatusMessage.Font = new System.Drawing.Font("Segoe UI", 10F);
      this.lblStatusMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.lblStatusMessage.Location = new System.Drawing.Point(73, 65);
      this.lblStatusMessage.Name = "lblStatusMessage";
      this.lblStatusMessage.Size = new System.Drawing.Size(103, 19);
      this.lblStatusMessage.TabIndex = 5;
      this.lblStatusMessage.Text = "status message";
      // 
      // lblTitle
      // 
      this.lblTitle.AutoSize = true;
      this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
      this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(250)))));
      this.lblTitle.Location = new System.Drawing.Point(73, 44);
      this.lblTitle.Name = "lblTitle";
      this.lblTitle.Size = new System.Drawing.Size(160, 21);
      this.lblTitle.TabIndex = 4;
      this.lblTitle.Text = "Something finished";
      // 
      // btnOk
      // 
      this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOk.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnOk.Font = new System.Drawing.Font("Segoe UI", 8F);
      this.btnOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnOk.Location = new System.Drawing.Point(662, 283);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(75, 51);
      this.btnOk.TabIndex = 3;
      this.btnOk.Text = "Ok";
      this.btnOk.UseVisualStyleBackColor = true;
      this.btnOk.Click += new System.EventHandler(this.siButton1_Click);
      // 
      // picWaitAnimation
      // 
      this.picWaitAnimation.Image = global::SitecoreInstaller.UI.Properties.Resources.spinner;
      this.picWaitAnimation.Location = new System.Drawing.Point(76, 147);
      this.picWaitAnimation.Name = "picWaitAnimation";
      this.picWaitAnimation.Size = new System.Drawing.Size(129, 134);
      this.picWaitAnimation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.picWaitAnimation.TabIndex = 8;
      this.picWaitAnimation.TabStop = false;
      // 
      // ProgressCtrl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.picWaitAnimation);
      this.Controls.Add(this.lblInfo);
      this.Controls.Add(this.lblProgress);
      this.Controls.Add(this.lblStatusMessage);
      this.Controls.Add(this.lblTitle);
      this.Controls.Add(this.btnOk);
      this.Name = "ProgressCtrl";
      this.Size = new System.Drawing.Size(800, 370);
      this.Load += new System.EventHandler(this.ProgressCtrl_Load);
      ((System.ComponentModel.ISupportInitialize)(this.picWaitAnimation)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private SIButton btnOk;
    private SIH1 lblTitle;
    private SIH2 lblStatusMessage;
    private SILabel lblProgress;
    private SILabel lblInfo;
    private System.Windows.Forms.PictureBox picWaitAnimation;
  }
}
