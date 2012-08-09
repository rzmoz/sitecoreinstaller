namespace SitecoreInstaller.UI.UserSettingsDialogs
{
    partial class UrlPostfixDialog
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
            this.tbxUrlPostfix = new System.Windows.Forms.TextBox();
            this.lblUrlPostfix = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tbxDescription = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbxUrlPostfix
            // 
            this.tbxUrlPostfix.Location = new System.Drawing.Point(115, 139);
            this.tbxUrlPostfix.Name = "tbxUrlPostfix";
            this.tbxUrlPostfix.Size = new System.Drawing.Size(270, 20);
            this.tbxUrlPostfix.TabIndex = 26;
            // 
            // lblUrlPostfix
            // 
            this.lblUrlPostfix.AutoSize = true;
            this.lblUrlPostfix.Location = new System.Drawing.Point(115, 124);
            this.lblUrlPostfix.Name = "lblUrlPostfix";
            this.lblUrlPostfix.Size = new System.Drawing.Size(56, 13);
            this.lblUrlPostfix.TabIndex = 28;
            this.lblUrlPostfix.Text = "Url postfix:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(217)))));
            this.lblTitle.Location = new System.Drawing.Point(115, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(147, 24);
            this.lblTitle.TabIndex = 27;
            this.lblTitle.Text = "Browser settings";
            // 
            // tbxDescription
            // 
            this.tbxDescription.BackColor = System.Drawing.Color.White;
            this.tbxDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxDescription.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbxDescription.Location = new System.Drawing.Point(115, 70);
            this.tbxDescription.Multiline = true;
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.ReadOnly = true;
            this.tbxDescription.Size = new System.Drawing.Size(270, 42);
            this.tbxDescription.TabIndex = 37;
            this.tbxDescription.TabStop = false;
            this.tbxDescription.Text = "Postfix is added to the url in browser. Use for easier adding of local sites to t" +
    "rusted zone.\r\nBlank is a valid value.";
            // 
            // UrlPostfixDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbxDescription);
            this.Controls.Add(this.tbxUrlPostfix);
            this.Controls.Add(this.lblUrlPostfix);
            this.Controls.Add(this.lblTitle);
            this.Name = "UrlPostfixDialog";
            this.Load += new System.EventHandler(this.UrlPostfixDialog_Load);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.lblUrlPostfix, 0);
            this.Controls.SetChildIndex(this.tbxUrlPostfix, 0);
            this.Controls.SetChildIndex(this.tbxDescription, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxUrlPostfix;
        private System.Windows.Forms.Label lblUrlPostfix;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox tbxDescription;
    }
}
