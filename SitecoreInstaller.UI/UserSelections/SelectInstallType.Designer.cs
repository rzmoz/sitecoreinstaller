namespace SitecoreInstaller.UI.UserSelections
{
  partial class SelectInstallType
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
      this.radInstallTypeFull = new System.Windows.Forms.RadioButton();
      this.radInstallTypeClient = new System.Windows.Forms.RadioButton();
      this.lblTitle = new SitecoreInstaller.UI.Forms.SIH2();
      this.SuspendLayout();
      // 
      // radInstallTypeFull
      // 
      this.radInstallTypeFull.AutoSize = true;
      this.radInstallTypeFull.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.radInstallTypeFull.Location = new System.Drawing.Point(3, 20);
      this.radInstallTypeFull.Name = "radInstallTypeFull";
      this.radInstallTypeFull.Size = new System.Drawing.Size(41, 17);
      this.radInstallTypeFull.TabIndex = 1;
      this.radInstallTypeFull.TabStop = true;
      this.radInstallTypeFull.Text = "Full";
      this.radInstallTypeFull.UseVisualStyleBackColor = true;
      this.radInstallTypeFull.CheckedChanged += new System.EventHandler(this.radInstallTypeFull_CheckedChanged);
      // 
      // radInstallTypeClient
      // 
      this.radInstallTypeClient.AutoSize = true;
      this.radInstallTypeClient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.radInstallTypeClient.Location = new System.Drawing.Point(50, 20);
      this.radInstallTypeClient.Name = "radInstallTypeClient";
      this.radInstallTypeClient.Size = new System.Drawing.Size(317, 17);
      this.radInstallTypeClient.TabIndex = 2;
      this.radInstallTypeClient.TabStop = true;
      this.radInstallTypeClient.Text = "Client (connectionstrings and databases must be set manually)";
      this.radInstallTypeClient.UseVisualStyleBackColor = true;
      this.radInstallTypeClient.CheckedChanged += new System.EventHandler(this.radInstallTypeClient_CheckedChanged);
      // 
      // lblTitle
      // 
      this.lblTitle.AutoSize = true;
      this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.lblTitle.Location = new System.Drawing.Point(0, 0);
      this.lblTitle.Name = "lblTitle";
      this.lblTitle.Size = new System.Drawing.Size(73, 17);
      this.lblTitle.TabIndex = 0;
      this.lblTitle.Text = "Install Type";
      // 
      // SelectInstallType
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.radInstallTypeClient);
      this.Controls.Add(this.radInstallTypeFull);
      this.Controls.Add(this.lblTitle);
      this.Name = "SelectInstallType";
      this.Size = new System.Drawing.Size(540, 42);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private Forms.SIH2 lblTitle;
    private System.Windows.Forms.RadioButton radInstallTypeFull;
    private System.Windows.Forms.RadioButton radInstallTypeClient;

  }
}
