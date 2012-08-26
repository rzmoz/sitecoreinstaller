namespace SitecoreInstaller.UI
{
    partial class PipelineStatus
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
            this.cmdOk = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tbxInfo = new System.Windows.Forms.TextBox();
            this.lblStatusMessage = new System.Windows.Forms.Label();
            this.pgbStatus = new System.Windows.Forms.ProgressBar();
            this.tbxMessages = new System.Windows.Forms.TextBox();
            this.picStatus = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdOk
            // 
            this.cmdOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOk.Location = new System.Drawing.Point(287, 224);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(90, 50);
            this.cmdOk.TabIndex = 16;
            this.cmdOk.Text = "Ok";
            this.cmdOk.UseVisualStyleBackColor = true;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(217)))));
            this.lblTitle.Location = new System.Drawing.Point(25, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(189, 24);
            this.lblTitle.TabIndex = 15;
            this.lblTitle.Text = "Something finished";
            // 
            // tbxInfo
            // 
            this.tbxInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxInfo.Location = new System.Drawing.Point(27, 78);
            this.tbxInfo.Name = "tbxInfo";
            this.tbxInfo.ReadOnly = true;
            this.tbxInfo.Size = new System.Drawing.Size(350, 20);
            this.tbxInfo.TabIndex = 14;
            this.tbxInfo.TabStop = false;
            // 
            // lblStatusMessage
            // 
            this.lblStatusMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatusMessage.AutoSize = true;
            this.lblStatusMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusMessage.Location = new System.Drawing.Point(26, 59);
            this.lblStatusMessage.Name = "lblStatusMessage";
            this.lblStatusMessage.Size = new System.Drawing.Size(94, 13);
            this.lblStatusMessage.TabIndex = 13;
            this.lblStatusMessage.Text = "status message";
            // 
            // pgbStatus
            // 
            this.pgbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pgbStatus.Location = new System.Drawing.Point(27, 104);
            this.pgbStatus.Name = "pgbStatus";
            this.pgbStatus.Size = new System.Drawing.Size(350, 20);
            this.pgbStatus.TabIndex = 12;
            // 
            // tbxMessages
            // 
            this.tbxMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxMessages.Location = new System.Drawing.Point(29, 78);
            this.tbxMessages.Multiline = true;
            this.tbxMessages.Name = "tbxMessages";
            this.tbxMessages.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbxMessages.Size = new System.Drawing.Size(348, 140);
            this.tbxMessages.TabIndex = 17;
            this.tbxMessages.TabStop = false;
            // 
            // picStatus
            // 
            this.picStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picStatus.Image = global::SitecoreInstaller.UI.Properties.Resources.error;
            this.picStatus.Location = new System.Drawing.Point(327, 22);
            this.picStatus.Name = "picStatus";
            this.picStatus.Size = new System.Drawing.Size(50, 50);
            this.picStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picStatus.TabIndex = 18;
            this.picStatus.TabStop = false;
            // 
            // PipelineStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picStatus);
            this.Controls.Add(this.cmdOk);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.tbxInfo);
            this.Controls.Add(this.lblStatusMessage);
            this.Controls.Add(this.pgbStatus);
            this.Controls.Add(this.tbxMessages);
            this.Name = "PipelineStatus";
            this.Size = new System.Drawing.Size(400, 300);
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdOk;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox tbxInfo;
        private System.Windows.Forms.Label lblStatusMessage;
        private System.Windows.Forms.ProgressBar pgbStatus;
        private System.Windows.Forms.TextBox tbxMessages;
        private System.Windows.Forms.PictureBox picStatus;


    }
}
