namespace SitecoreInstaller.UI.Dialogs
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlUserAccept = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.btnAcceptNo = new SitecoreInstaller.UI.Forms.SIButton();
            this.btnAcceptYes = new SitecoreInstaller.UI.Forms.SIButton();
            this.pnlUserAccept.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(450, 50);
            this.pnlHeader.TabIndex = 0;
            // 
            // pnlUserAccept
            // 
            this.pnlUserAccept.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlUserAccept.Controls.Add(this.btnAcceptYes);
            this.pnlUserAccept.Controls.Add(this.btnAcceptNo);
            this.pnlUserAccept.Location = new System.Drawing.Point(0, 250);
            this.pnlUserAccept.Name = "pnlUserAccept";
            this.pnlUserAccept.Size = new System.Drawing.Size(450, 50);
            this.pnlUserAccept.TabIndex = 1;
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.Location = new System.Drawing.Point(0, 50);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(450, 200);
            this.pnlContent.TabIndex = 2;
            // 
            // btnAcceptNo
            // 
            this.btnAcceptNo.BottomDividerColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(46)))));
            this.btnAcceptNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAcceptNo.DrawBottomDivider = false;
            this.btnAcceptNo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.btnAcceptNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcceptNo.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnAcceptNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.btnAcceptNo.Location = new System.Drawing.Point(365, 10);
            this.btnAcceptNo.Name = "btnAcceptNo";
            this.btnAcceptNo.Size = new System.Drawing.Size(75, 30);
            this.btnAcceptNo.TabIndex = 0;
            this.btnAcceptNo.Text = "No";
            this.btnAcceptNo.UseVisualStyleBackColor = true;
            // 
            // btnAcceptYes
            // 
            this.btnAcceptYes.BottomDividerColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(46)))));
            this.btnAcceptYes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAcceptYes.DrawBottomDivider = false;
            this.btnAcceptYes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.btnAcceptYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcceptYes.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnAcceptYes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(176)))), ((int)(((byte)(176)))));
            this.btnAcceptYes.Location = new System.Drawing.Point(280, 10);
            this.btnAcceptYes.Name = "btnAcceptYes";
            this.btnAcceptYes.Size = new System.Drawing.Size(75, 30);
            this.btnAcceptYes.TabIndex = 1;
            this.btnAcceptYes.Text = "Yes";
            this.btnAcceptYes.UseVisualStyleBackColor = true;
            // 
            // UserDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlUserAccept);
            this.Controls.Add(this.pnlHeader);
            this.Name = "UserDialog";
            this.Size = new System.Drawing.Size(450, 300);
            this.pnlUserAccept.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlUserAccept;
        private System.Windows.Forms.Panel pnlContent;
        private Forms.SIButton btnAcceptYes;
        private Forms.SIButton btnAcceptNo;
    }
}
