namespace SitecoreInstaller.UI.Simple
{
  partial class UninstallCtrl
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
      this.selectProjectName1 = new SitecoreInstaller.UI.UserSelections.SelectProjectName();
      this.btnBack = new SitecoreInstaller.UI.Forms.SIButton();
      this.btnUninstall = new SitecoreInstaller.UI.Forms.SIButton();
      this.SuspendLayout();
      // 
      // selectProjectName1
      // 
      this.selectProjectName1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.selectProjectName1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
      this.selectProjectName1.Location = new System.Drawing.Point(50, 80);
      this.selectProjectName1.Name = "selectProjectName1";
      this.selectProjectName1.ProjectName = "";
      this.selectProjectName1.Size = new System.Drawing.Size(400, 50);
      this.selectProjectName1.TabIndex = 0;
      // 
      // btnBack
      // 
      this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnBack.Font = new System.Drawing.Font("Segoe UI", 8F);
      this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnBack.Location = new System.Drawing.Point(50, 150);
      this.btnBack.Name = "btnBack";
      this.btnBack.Size = new System.Drawing.Size(100, 50);
      this.btnBack.TabIndex = 4;
      this.btnBack.Text = "Back";
      this.btnBack.UseVisualStyleBackColor = true;
      this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
      // 
      // btnUninstall
      // 
      this.btnUninstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnUninstall.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnUninstall.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnUninstall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnUninstall.Font = new System.Drawing.Font("Segoe UI", 8F);
      this.btnUninstall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnUninstall.Location = new System.Drawing.Point(350, 150);
      this.btnUninstall.Name = "btnUninstall";
      this.btnUninstall.Size = new System.Drawing.Size(100, 50);
      this.btnUninstall.TabIndex = 3;
      this.btnUninstall.Text = "Uninstall";
      this.btnUninstall.UseVisualStyleBackColor = true;
      this.btnUninstall.Click += new System.EventHandler(this.btnUninstall_Click);
      // 
      // UninstallCtrl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.btnBack);
      this.Controls.Add(this.btnUninstall);
      this.Controls.Add(this.selectProjectName1);
      this.Name = "UninstallCtrl";
      this.Size = new System.Drawing.Size(500, 300);
      this.ResumeLayout(false);

    }

    #endregion

    private UserSelections.SelectProjectName selectProjectName1;
    private Forms.SIButton btnBack;
    private Forms.SIButton btnUninstall;
  }
}
