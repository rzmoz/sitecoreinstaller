namespace SitecoreInstaller.UI.UserSelections
{
    partial class SelectProjectName
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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
      this.cbxProjectName = new System.Windows.Forms.ComboBox();
      this.lblProjectName = new SitecoreInstaller.UI.Forms.SIH2();
      this.SuspendLayout();
      // 
      // cbxProjectName
      // 
      this.cbxProjectName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.cbxProjectName.FormattingEnabled = true;
      this.cbxProjectName.Location = new System.Drawing.Point(0, 25);
      this.cbxProjectName.Name = "cbxProjectName";
      this.cbxProjectName.Size = new System.Drawing.Size(400, 21);
      this.cbxProjectName.TabIndex = 1;
      this.cbxProjectName.SelectedIndexChanged += new System.EventHandler(this.cbxProjectName_SelectedIndexChanged);
      this.cbxProjectName.TextUpdate += new System.EventHandler(this.cbxProjectName_TextUpdate);
      // 
      // lblProjectName
      // 
      this.lblProjectName.AutoSize = true;
      this.lblProjectName.Font = new System.Drawing.Font("Segoe UI", 10F);
      this.lblProjectName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
      this.lblProjectName.Location = new System.Drawing.Point(0, 3);
      this.lblProjectName.Name = "lblProjectName";
      this.lblProjectName.Size = new System.Drawing.Size(92, 19);
      this.lblProjectName.TabIndex = 2;
      this.lblProjectName.Text = "Project name:";
      // 
      // SelectProjectName
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.lblProjectName);
      this.Controls.Add(this.cbxProjectName);
      this.Name = "SelectProjectName";
      this.Size = new System.Drawing.Size(400, 50);
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxProjectName;
        private Forms.SIH2 lblProjectName;
    }
}
