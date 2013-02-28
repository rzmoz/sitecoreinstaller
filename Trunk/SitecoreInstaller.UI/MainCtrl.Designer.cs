namespace SitecoreInstaller.UI
{
  partial class MainCtrl
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
      this.pnlFooter = new System.Windows.Forms.Panel();
      this.pnlHeader = new System.Windows.Forms.Panel();
      this.pnlContent = new System.Windows.Forms.Panel();
      this.progressCtrl1 = new SitecoreInstaller.UI.Processing.ProgressCtrl();
      this.pnlContent.SuspendLayout();
      this.SuspendLayout();
      // 
      // pnlFooter
      // 
      this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(69)))), ((int)(((byte)(79)))));
      this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.pnlFooter.Location = new System.Drawing.Point(0, 400);
      this.pnlFooter.Name = "pnlFooter";
      this.pnlFooter.Size = new System.Drawing.Size(800, 50);
      this.pnlFooter.TabIndex = 2;
      // 
      // pnlHeader
      // 
      this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(69)))), ((int)(((byte)(79)))));
      this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnlHeader.Location = new System.Drawing.Point(0, 0);
      this.pnlHeader.Name = "pnlHeader";
      this.pnlHeader.Size = new System.Drawing.Size(800, 30);
      this.pnlHeader.TabIndex = 3;
      // 
      // pnlContent
      // 
      this.pnlContent.Controls.Add(this.progressCtrl1);
      this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlContent.Location = new System.Drawing.Point(0, 30);
      this.pnlContent.Name = "pnlContent";
      this.pnlContent.Size = new System.Drawing.Size(800, 370);
      this.pnlContent.TabIndex = 1;
      // 
      // progressCtrl1
      // 
      this.progressCtrl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.progressCtrl1.Location = new System.Drawing.Point(0, 0);
      this.progressCtrl1.Name = "progressCtrl1";
      this.progressCtrl1.Size = new System.Drawing.Size(800, 370);
      this.progressCtrl1.TabIndex = 0;
      // 
      // MainCtrl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.pnlContent);
      this.Controls.Add(this.pnlFooter);
      this.Controls.Add(this.pnlHeader);
      this.Name = "MainCtrl";
      this.Size = new System.Drawing.Size(800, 450);
      this.pnlContent.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel pnlFooter;
    private System.Windows.Forms.Panel pnlHeader;
    private System.Windows.Forms.Panel pnlContent;
    private Processing.ProgressCtrl progressCtrl1;
  }
}
