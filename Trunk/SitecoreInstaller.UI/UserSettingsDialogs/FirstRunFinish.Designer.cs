namespace SitecoreInstaller.UI.UserSettingsDialogs
{
    partial class FirstRunFinish
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
            this.tbxDescription = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.tbxDescription.Size = new System.Drawing.Size(270, 124);
            this.tbxDescription.TabIndex = 28;
            this.tbxDescription.TabStop = false;
            this.tbxDescription.Text = "Thank you for using SitecoreInstaller.\r\nYou are now ready to install Sitecore!";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(217)))));
            this.lblTitle.Location = new System.Drawing.Point(115, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(142, 24);
            this.lblTitle.TabIndex = 27;
            this.lblTitle.Text = "Setup complete";
            // 
            // FirstRunFinish
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbxDescription);
            this.Controls.Add(this.lblTitle);
            this.Name = "FirstRunFinish";
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.tbxDescription, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxDescription;
        private System.Windows.Forms.Label lblTitle;

    }
}
