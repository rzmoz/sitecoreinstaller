namespace SitecoreInstaller.UI
{
    partial class PipelineResult
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
            this.lblFinishTitle = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.tbxDetails = new System.Windows.Forms.TextBox();
            this.btnCopyToClipboard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFinishTitle
            // 
            this.lblFinishTitle.AutoSize = true;
            this.lblFinishTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinishTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(217)))));
            this.lblFinishTitle.Location = new System.Drawing.Point(25, 50);
            this.lblFinishTitle.Name = "lblFinishTitle";
            this.lblFinishTitle.Size = new System.Drawing.Size(189, 24);
            this.lblFinishTitle.TabIndex = 0;
            this.lblFinishTitle.Text = "Something finished";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(317, 47);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(71, 30);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbxDetails
            // 
            this.tbxDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxDetails.Location = new System.Drawing.Point(16, 112);
            this.tbxDetails.Multiline = true;
            this.tbxDetails.Name = "tbxDetails";
            this.tbxDetails.ReadOnly = true;
            this.tbxDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxDetails.Size = new System.Drawing.Size(372, 219);
            this.tbxDetails.TabIndex = 2;
            this.tbxDetails.WordWrap = false;
            // 
            // btnCopyToClipboard
            // 
            this.btnCopyToClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyToClipboard.Location = new System.Drawing.Point(238, 337);
            this.btnCopyToClipboard.Name = "btnCopyToClipboard";
            this.btnCopyToClipboard.Size = new System.Drawing.Size(150, 25);
            this.btnCopyToClipboard.TabIndex = 1;
            this.btnCopyToClipboard.Text = "Copy details to clipboard";
            this.btnCopyToClipboard.UseVisualStyleBackColor = false;
            this.btnCopyToClipboard.Click += new System.EventHandler(this.btnCopyToClipboard_Click);
            // 
            // PipelineResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnCopyToClipboard);
            this.Controls.Add(this.tbxDetails);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblFinishTitle);
            this.Name = "PipelineResult";
            this.Size = new System.Drawing.Size(400, 370);
            this.Load += new System.EventHandler(this.PipelineResult_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFinishTitle;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox tbxDetails;
        private System.Windows.Forms.Button btnCopyToClipboard;
    }
}
