namespace SitecoreInstaller.UI
{
    partial class PipelineProgress
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
            this.pgbStatus = new System.Windows.Forms.ProgressBar();
            this.lblStatusMessage = new System.Windows.Forms.Label();
            this.tbxInfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // pgbStatus
            // 
            this.pgbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgbStatus.Location = new System.Drawing.Point(25, 50);
            this.pgbStatus.Name = "pgbStatus";
            this.pgbStatus.Size = new System.Drawing.Size(350, 20);
            this.pgbStatus.TabIndex = 0;
            // 
            // lblStatusMessage
            // 
            this.lblStatusMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatusMessage.AutoSize = true;
            this.lblStatusMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusMessage.Location = new System.Drawing.Point(25, 75);
            this.lblStatusMessage.Name = "lblStatusMessage";
            this.lblStatusMessage.Size = new System.Drawing.Size(94, 13);
            this.lblStatusMessage.TabIndex = 1;
            this.lblStatusMessage.Text = "status message";
            // 
            // tbxInfo
            // 
            this.tbxInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxInfo.Location = new System.Drawing.Point(25, 95);
            this.tbxInfo.Name = "tbxInfo";
            this.tbxInfo.ReadOnly = true;
            this.tbxInfo.Size = new System.Drawing.Size(350, 20);
            this.tbxInfo.TabIndex = 2;
            // 
            // PipelineProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbxInfo);
            this.Controls.Add(this.lblStatusMessage);
            this.Controls.Add(this.pgbStatus);
            this.Name = "PipelineProgress";
            this.Size = new System.Drawing.Size(400, 170);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pgbStatus;
        private System.Windows.Forms.Label lblStatusMessage;
        private System.Windows.Forms.TextBox tbxInfo;
    }
}
