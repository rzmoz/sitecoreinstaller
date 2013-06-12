namespace SitecoreInstaller.UI
{
  partial class MainSimple
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
      this.btnInstall = new SitecoreInstaller.UI.Forms.SIButton();
      this.btnUninstall = new SitecoreInstaller.UI.Forms.SIButton();
      this.btnOpenSite = new SitecoreInstaller.UI.Forms.SIButton();
      this.SuspendLayout();
      // 
      // btnInstall
      // 
      this.btnInstall.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnInstall.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnInstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnInstall.Font = new System.Drawing.Font("Segoe UI", 8F);
      this.btnInstall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnInstall.Location = new System.Drawing.Point(56, 92);
      this.btnInstall.Name = "btnInstall";
      this.btnInstall.Size = new System.Drawing.Size(75, 93);
      this.btnInstall.TabIndex = 0;
      this.btnInstall.Text = "siButton1";
      this.btnInstall.UseVisualStyleBackColor = true;
      // 
      // btnUninstall
      // 
      this.btnUninstall.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnUninstall.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnUninstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnUninstall.Font = new System.Drawing.Font("Segoe UI", 8F);
      this.btnUninstall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnUninstall.Location = new System.Drawing.Point(183, 92);
      this.btnUninstall.Name = "btnUninstall";
      this.btnUninstall.Size = new System.Drawing.Size(75, 93);
      this.btnUninstall.TabIndex = 1;
      this.btnUninstall.Text = "siButton2";
      this.btnUninstall.UseVisualStyleBackColor = true;
      // 
      // btnOpenSite
      // 
      this.btnOpenSite.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnOpenSite.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnOpenSite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnOpenSite.Font = new System.Drawing.Font("Segoe UI", 8F);
      this.btnOpenSite.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnOpenSite.Location = new System.Drawing.Point(308, 92);
      this.btnOpenSite.Name = "btnOpenSite";
      this.btnOpenSite.Size = new System.Drawing.Size(75, 93);
      this.btnOpenSite.TabIndex = 2;
      this.btnOpenSite.Text = "siButton3";
      this.btnOpenSite.UseVisualStyleBackColor = true;
      // 
      // MainSimple
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.btnOpenSite);
      this.Controls.Add(this.btnUninstall);
      this.Controls.Add(this.btnInstall);
      this.Name = "MainSimple";
      this.Size = new System.Drawing.Size(500, 300);
      this.Resize += new System.EventHandler(this.MainSimple_Resize);
      this.ResumeLayout(false);

    }

    #endregion

    private Forms.SIButton btnInstall;
    private Forms.SIButton btnUninstall;
    private Forms.SIButton btnOpenSite;

  }
}
