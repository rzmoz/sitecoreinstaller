namespace SitecoreInstaller.UI.UserSelections
{
  partial class SelectClientInstall
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
      this.chkClientInstall = new System.Windows.Forms.CheckBox();
      this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
      this.lblTitle = new SitecoreInstaller.UI.Forms.SIH2();
      this.SuspendLayout();
      // 
      // chkClientInstall
      // 
      this.chkClientInstall.AutoSize = true;
      this.chkClientInstall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.chkClientInstall.Location = new System.Drawing.Point(3, 22);
      this.chkClientInstall.Name = "chkClientInstall";
      this.chkClientInstall.Size = new System.Drawing.Size(165, 17);
      this.chkClientInstall.TabIndex = 1;
      this.chkClientInstall.Text = "Install with Client only settings";
      this.chkClientInstall.UseVisualStyleBackColor = true;
      this.chkClientInstall.CheckedChanged += new System.EventHandler(this.chkClientInstall_CheckedChanged);
      // 
      // lblTitle
      // 
      this.lblTitle.AutoSize = true;
      this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.lblTitle.Location = new System.Drawing.Point(0, 0);
      this.lblTitle.Name = "lblTitle";
      this.lblTitle.Size = new System.Drawing.Size(77, 17);
      this.lblTitle.TabIndex = 0;
      this.lblTitle.Text = "Client Install";
      // 
      // SelectClientInstall
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.chkClientInstall);
      this.Controls.Add(this.lblTitle);
      this.Name = "SelectClientInstall";
      this.Size = new System.Drawing.Size(540, 42);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Forms.SIH2 lblTitle;
    private System.Windows.Forms.CheckBox chkClientInstall;
    private System.Windows.Forms.ToolTip toolTip1;

  }
}
