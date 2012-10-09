namespace SitecoreInstaller.UI
{
    partial class SelectDatabases
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.clbDatabases = new System.Windows.Forms.CheckedListBox();
            this.cmdOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clbDatabases
            // 
            this.clbDatabases.CheckOnClick = true;
            this.clbDatabases.FormattingEnabled = true;
            this.clbDatabases.Location = new System.Drawing.Point(12, 12);
            this.clbDatabases.Name = "clbDatabases";
            this.clbDatabases.Size = new System.Drawing.Size(260, 214);
            this.clbDatabases.TabIndex = 1;
            this.clbDatabases.TabStop = false;
            // 
            // cmdOk
            // 
            this.cmdOk.Location = new System.Drawing.Point(197, 232);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(75, 23);
            this.cmdOk.TabIndex = 0;
            this.cmdOk.Text = "Ok";
            this.cmdOk.UseVisualStyleBackColor = true;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // SelectDatabases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.cmdOk);
            this.Controls.Add(this.clbDatabases);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SelectDatabases";
            this.Text = "Select databases";
            this.Load += new System.EventHandler(this.SelectDatabases_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbDatabases;
        private System.Windows.Forms.Button cmdOk;
    }
}