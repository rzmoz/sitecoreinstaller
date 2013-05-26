namespace SitecoreInstaller.UI.Log
{
  partial class LogViewer
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
      this.rtbLog = new System.Windows.Forms.RichTextBox();
      this.chkFollowLogTrail = new System.Windows.Forms.CheckBox();
      this.SuspendLayout();
      // 
      // rtbLog
      // 
      this.rtbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.rtbLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.rtbLog.Location = new System.Drawing.Point(0, 30);
      this.rtbLog.Name = "rtbLog";
      this.rtbLog.Size = new System.Drawing.Size(800, 220);
      this.rtbLog.TabIndex = 0;
      this.rtbLog.Text = "";
      // 
      // chkFollowLogTrail
      // 
      this.chkFollowLogTrail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.chkFollowLogTrail.AutoSize = true;
      this.chkFollowLogTrail.Location = new System.Drawing.Point(721, 7);
      this.chkFollowLogTrail.Name = "chkFollowLogTrail";
      this.chkFollowLogTrail.Size = new System.Drawing.Size(75, 17);
      this.chkFollowLogTrail.TabIndex = 4;
      this.chkFollowLogTrail.TabStop = false;
      this.chkFollowLogTrail.Text = "Follow trail";
      this.chkFollowLogTrail.UseVisualStyleBackColor = true;
      this.chkFollowLogTrail.CheckedChanged += new System.EventHandler(this.chkFollowLogTrail_CheckedChanged);
      // 
      // LogViewer
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.chkFollowLogTrail);
      this.Controls.Add(this.rtbLog);
      this.Name = "LogViewer";
      this.Size = new System.Drawing.Size(800, 250);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.RichTextBox rtbLog;
    private System.Windows.Forms.CheckBox chkFollowLogTrail;
  }
}
