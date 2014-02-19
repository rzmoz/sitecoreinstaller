namespace SitecoreInstaller.UI.Dialog
{
    partial class UserDialog
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
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlUserAccept = new System.Windows.Forms.Panel();
            this.btnAcceptYes = new SitecoreInstaller.UI.Forms.SIButton();
            this.btnAcceptNo = new SitecoreInstaller.UI.Forms.SIButton();
            this.lblText = new SitecoreInstaller.UI.Forms.SIH2();
            this.pnlContent.SuspendLayout();
            this.pnlUserAccept.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlContent.Controls.Add(this.pnlUserAccept);
            this.pnlContent.Controls.Add(this.lblText);
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(400, 200);
            this.pnlContent.TabIndex = 2;
            // 
            // pnlUserAccept
            // 
            this.pnlUserAccept.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlUserAccept.Controls.Add(this.btnAcceptYes);
            this.pnlUserAccept.Controls.Add(this.btnAcceptNo);
            this.pnlUserAccept.Location = new System.Drawing.Point(0, 149);
            this.pnlUserAccept.Name = "pnlUserAccept";
            this.pnlUserAccept.Size = new System.Drawing.Size(400, 50);
            this.pnlUserAccept.TabIndex = 2;
            // 
            // btnAcceptYes
            // 
            this.btnAcceptYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAcceptYes.BottomDividerColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(46)))));
            this.btnAcceptYes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAcceptYes.DrawBottomDivider = false;
            this.btnAcceptYes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.btnAcceptYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcceptYes.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnAcceptYes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.btnAcceptYes.Location = new System.Drawing.Point(230, 10);
            this.btnAcceptYes.Name = "btnAcceptYes";
            this.btnAcceptYes.Size = new System.Drawing.Size(75, 30);
            this.btnAcceptYes.TabIndex = 1;
            this.btnAcceptYes.Text = "Yes";
            this.btnAcceptYes.UseVisualStyleBackColor = true;
            this.btnAcceptYes.Click += new System.EventHandler(this.btnAcceptYes_Click);
            // 
            // btnAcceptNo
            // 
            this.btnAcceptNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAcceptNo.BottomDividerColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(46)))));
            this.btnAcceptNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAcceptNo.DrawBottomDivider = false;
            this.btnAcceptNo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.btnAcceptNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcceptNo.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnAcceptNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.btnAcceptNo.Location = new System.Drawing.Point(315, 10);
            this.btnAcceptNo.Name = "btnAcceptNo";
            this.btnAcceptNo.Size = new System.Drawing.Size(75, 30);
            this.btnAcceptNo.TabIndex = 0;
            this.btnAcceptNo.Text = "No";
            this.btnAcceptNo.UseVisualStyleBackColor = true;
            this.btnAcceptNo.Click += new System.EventHandler(this.btnAcceptNo_Click);
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.lblText.Location = new System.Drawing.Point(39, 39);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(55, 19);
            this.lblText.TabIndex = 0;
            this.lblText.Text = "lblText";
            // 
            // UserDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlContent);
            this.Name = "UserDialog";
            this.Size = new System.Drawing.Size(400, 200);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlUserAccept.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private Forms.SIH2 lblText;
        private System.Windows.Forms.Panel pnlUserAccept;
        private Forms.SIButton btnAcceptYes;
        private Forms.SIButton btnAcceptNo;
    }
}
