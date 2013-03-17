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
      this.picWaitingAni = new System.Windows.Forms.PictureBox();
      this.lblStatusMessage = new SitecoreInstaller.UI.Forms.SIH2();
      this.lblTitle = new SitecoreInstaller.UI.Forms.SIH1();
      this.btnOk = new SitecoreInstaller.UI.Forms.SIButton();
      ((System.ComponentModel.ISupportInitialize)(this.picWaitingAni)).BeginInit();
      this.SuspendLayout();
      // 
      // picWaitingAni
      // 
      this.picWaitingAni.Image = global::SitecoreInstaller.UI.Properties.Resources.Spinner;
      this.picWaitingAni.Location = new System.Drawing.Point(77, 115);
      this.picWaitingAni.Name = "picWaitingAni";
      this.picWaitingAni.Size = new System.Drawing.Size(150, 150);
      this.picWaitingAni.TabIndex = 2;
      this.picWaitingAni.TabStop = false;
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
      this.btnOk.Location = new System.Drawing.Point(713, 303);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(75, 51);
      this.btnOk.TabIndex = 3;
      this.btnOk.Text = "Ok";
      this.btnOk.UseVisualStyleBackColor = true;
      this.btnOk.Click += new System.EventHandler(this.siButton1_Click);
      // 
      // ProgressCtrl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.lblStatusMessage);
      this.Controls.Add(this.lblTitle);
      this.Controls.Add(this.btnOk);
      this.Controls.Add(this.picWaitingAni);
      this.Name = "ProgressCtrl";
      this.Size = new System.Drawing.Size(800, 370);
      this.Load += new System.EventHandler(this.ProgressCtrl_Load);
      ((System.ComponentModel.ISupportInitialize)(this.picWaitingAni)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox picWaitingAni;
    private SIButton btnOk;
    private SIH1 lblTitle;
    private SIH2 lblStatusMessage;
  }
}
