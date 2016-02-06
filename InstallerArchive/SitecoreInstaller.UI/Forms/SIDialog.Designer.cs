namespace SitecoreInstaller.UI.Forms
{
  partial class SIDialog
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
      this.lblTitle = new SitecoreInstaller.UI.Forms.SILabel();
      this.tbxText = new System.Windows.Forms.TextBox();
      this.btnYes = new SitecoreInstaller.UI.Forms.SIButton();
      this.btnNo = new SitecoreInstaller.UI.Forms.SIButton();
      this.btnCancel = new SitecoreInstaller.UI.Forms.SIButton();
      this.BtnOk = new SitecoreInstaller.UI.Forms.SIButton();
      this.SuspendLayout();
      // 
      // lblTitle
      // 
      this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.lblTitle.AutoSize = true;
      this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F);
      this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.lblTitle.Location = new System.Drawing.Point(90, 61);
      this.lblTitle.Name = "lblTitle";
      this.lblTitle.Size = new System.Drawing.Size(39, 21);
      this.lblTitle.TabIndex = 0;
      this.lblTitle.Text = "Title";
      // 
      // tbxText
      // 
      this.tbxText.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.tbxText.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.tbxText.Location = new System.Drawing.Point(94, 85);
      this.tbxText.Multiline = true;
      this.tbxText.Name = "tbxText";
      this.tbxText.ReadOnly = true;
      this.tbxText.Size = new System.Drawing.Size(354, 116);
      this.tbxText.TabIndex = 1;
      // 
      // btnYes
      // 
      this.btnYes.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.btnYes.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnYes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnYes.Font = new System.Drawing.Font("Segoe UI", 8F);
      this.btnYes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnYes.Location = new System.Drawing.Point(373, 207);
      this.btnYes.Name = "btnYes";
      this.btnYes.Size = new System.Drawing.Size(75, 23);
      this.btnYes.TabIndex = 2;
      this.btnYes.Text = "Yes";
      this.btnYes.UseVisualStyleBackColor = true;
      // 
      // btnNo
      // 
      this.btnNo.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.btnNo.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnNo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnNo.Font = new System.Drawing.Font("Segoe UI", 8F);
      this.btnNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnNo.Location = new System.Drawing.Point(292, 207);
      this.btnNo.Name = "btnNo";
      this.btnNo.Size = new System.Drawing.Size(75, 23);
      this.btnNo.TabIndex = 3;
      this.btnNo.Text = "No";
      this.btnNo.UseVisualStyleBackColor = true;
      // 
      // btnCancel
      // 
      this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
      this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 8F);
      this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.btnCancel.Location = new System.Drawing.Point(373, 236);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 4;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      // 
      // BtnOk
      // 
      this.BtnOk.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.BtnOk.Cursor = System.Windows.Forms.Cursors.Hand;
      this.BtnOk.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.BtnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.BtnOk.Font = new System.Drawing.Font("Segoe UI", 8F);
      this.BtnOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.BtnOk.Location = new System.Drawing.Point(292, 236);
      this.BtnOk.Name = "BtnOk";
      this.BtnOk.Size = new System.Drawing.Size(75, 23);
      this.BtnOk.TabIndex = 5;
      this.BtnOk.Text = "Ok";
      this.BtnOk.UseVisualStyleBackColor = true;
      // 
      // SIDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.BtnOk);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnNo);
      this.Controls.Add(this.btnYes);
      this.Controls.Add(this.tbxText);
      this.Controls.Add(this.lblTitle);
      this.Name = "SIDialog";
      this.Size = new System.Drawing.Size(548, 348);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private SILabel lblTitle;
    private System.Windows.Forms.TextBox tbxText;
    private SIButton btnYes;
    private SIButton btnNo;
    private SIButton btnCancel;
    private SIButton BtnOk;
  }
}
