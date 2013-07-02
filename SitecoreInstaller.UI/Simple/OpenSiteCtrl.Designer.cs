namespace SitecoreInstaller.UI.Simple
{
  partial class OpenSiteCtrl
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
      this.btnOpenSite = new SitecoreInstaller.UI.Forms.SIButton();
      this.selectProjectName1 = new SitecoreInstaller.UI.UserSelections.SelectProjectName();
      this.btnBack = new SitecoreInstaller.UI.Forms.SIButton();
      this.SuspendLayout();
      // 
      // btnOpenSite
      // 
      this.btnOpenSite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOpenSite.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnOpenSite.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnOpenSite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnOpenSite.Font = new System.Drawing.Font("Segoe UI", 8F);
      this.btnOpenSite.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnOpenSite.Location = new System.Drawing.Point(350, 150);
      this.btnOpenSite.Name = "btnOpenSite";
      this.btnOpenSite.Size = new System.Drawing.Size(100, 50);
      this.btnOpenSite.TabIndex = 0;
      this.btnOpenSite.Text = "Open Site";
      this.btnOpenSite.UseVisualStyleBackColor = true;
      this.btnOpenSite.Click += new System.EventHandler(this.btnOpenSite_Click);
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
      this.selectProjectName1.TabIndex = 1;
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
      this.btnBack.TabIndex = 2;
      this.btnBack.Text = "Back";
      this.btnBack.UseVisualStyleBackColor = true;
      this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
      // 
      // OpenSiteCtrl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.btnBack);
      this.Controls.Add(this.selectProjectName1);
      this.Controls.Add(this.btnOpenSite);
      this.Name = "OpenSiteCtrl";
      this.Size = new System.Drawing.Size(500, 300);
      this.ResumeLayout(false);

    }

    #endregion

    private Forms.SIButton btnOpenSite;
    private UserSelections.SelectProjectName selectProjectName1;
    private Forms.SIButton btnBack;
  }
}
