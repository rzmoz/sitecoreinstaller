namespace SitecoreInstaller.UI
{
    partial class Logger
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
            this.btnClearLog = new System.Windows.Forms.Button();
            this.chkWarning = new System.Windows.Forms.CheckBox();
            this.chkInfo = new System.Windows.Forms.CheckBox();
            this.chkDebug = new System.Windows.Forms.CheckBox();
            this.chkError = new System.Windows.Forms.CheckBox();
            this.chkProfiling = new System.Windows.Forms.CheckBox();
            this.chkFollowLogTrail = new System.Windows.Forms.CheckBox();
            this.rteEventLog = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnClearLog
            // 
            this.btnClearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearLog.Location = new System.Drawing.Point(521, 5);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(76, 23);
            this.btnClearLog.TabIndex = 48;
            this.btnClearLog.Text = "Clear log";
            this.btnClearLog.UseVisualStyleBackColor = false;
            this.btnClearLog.Click += new System.EventHandler(this.ClearLog);
            // 
            // chkWarning
            // 
            this.chkWarning.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkWarning.AutoSize = true;
            this.chkWarning.Location = new System.Drawing.Point(99, 5);
            this.chkWarning.Name = "chkWarning";
            this.chkWarning.Size = new System.Drawing.Size(57, 23);
            this.chkWarning.TabIndex = 44;
            this.chkWarning.Text = "Warning";
            this.chkWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkWarning.UseVisualStyleBackColor = true;
            this.chkWarning.CheckedChanged += new System.EventHandler(this.chkWarning_CheckedChanged);
            // 
            // chkInfo
            // 
            this.chkInfo.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkInfo.AutoSize = true;
            this.chkInfo.Location = new System.Drawing.Point(58, 5);
            this.chkInfo.Name = "chkInfo";
            this.chkInfo.Size = new System.Drawing.Size(35, 23);
            this.chkInfo.TabIndex = 43;
            this.chkInfo.Text = "Info";
            this.chkInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkInfo.UseVisualStyleBackColor = true;
            this.chkInfo.CheckedChanged += new System.EventHandler(this.chkInfo_CheckedChanged);
            // 
            // chkDebug
            // 
            this.chkDebug.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkDebug.AutoSize = true;
            this.chkDebug.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkDebug.Location = new System.Drawing.Point(3, 5);
            this.chkDebug.Name = "chkDebug";
            this.chkDebug.Size = new System.Drawing.Size(49, 23);
            this.chkDebug.TabIndex = 42;
            this.chkDebug.Text = "Debug";
            this.chkDebug.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkDebug.UseVisualStyleBackColor = true;
            this.chkDebug.CheckedChanged += new System.EventHandler(this.chkDebug_CheckedChanged);
            // 
            // chkError
            // 
            this.chkError.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkError.AutoSize = true;
            this.chkError.Location = new System.Drawing.Point(162, 5);
            this.chkError.Name = "chkError";
            this.chkError.Size = new System.Drawing.Size(39, 23);
            this.chkError.TabIndex = 45;
            this.chkError.Text = "Error";
            this.chkError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkError.UseVisualStyleBackColor = true;
            this.chkError.CheckedChanged += new System.EventHandler(this.chkError_CheckedChanged);
            // 
            // chkProfiling
            // 
            this.chkProfiling.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkProfiling.AutoSize = true;
            this.chkProfiling.Location = new System.Drawing.Point(207, 5);
            this.chkProfiling.Name = "chkProfiling";
            this.chkProfiling.Size = new System.Drawing.Size(54, 23);
            this.chkProfiling.TabIndex = 46;
            this.chkProfiling.Text = "Profiling";
            this.chkProfiling.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkProfiling.UseVisualStyleBackColor = true;
            this.chkProfiling.CheckedChanged += new System.EventHandler(this.chkProfiling_CheckedChanged);
            // 
            // chkFollowLogTrail
            // 
            this.chkFollowLogTrail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkFollowLogTrail.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkFollowLogTrail.AutoSize = true;
            this.chkFollowLogTrail.Checked = true;
            this.chkFollowLogTrail.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFollowLogTrail.Location = new System.Drawing.Point(449, 5);
            this.chkFollowLogTrail.Name = "chkFollowLogTrail";
            this.chkFollowLogTrail.Size = new System.Drawing.Size(66, 23);
            this.chkFollowLogTrail.TabIndex = 47;
            this.chkFollowLogTrail.Text = "Follow trail";
            this.chkFollowLogTrail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkFollowLogTrail.UseVisualStyleBackColor = true;
            this.chkFollowLogTrail.CheckedChanged += new System.EventHandler(this.chkFollowLogTrail_CheckedChanged);
            // 
            // rteEventLog
            // 
            this.rteEventLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rteEventLog.BackColor = System.Drawing.Color.White;
            this.rteEventLog.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.rteEventLog.Location = new System.Drawing.Point(0, 31);
            this.rteEventLog.Name = "rteEventLog";
            this.rteEventLog.ReadOnly = true;
            this.rteEventLog.Size = new System.Drawing.Size(600, 181);
            this.rteEventLog.TabIndex = 49;
            this.rteEventLog.TabStop = false;
            this.rteEventLog.Text = "";
            this.rteEventLog.WordWrap = false;
            // 
            // Logger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.chkWarning);
            this.Controls.Add(this.chkInfo);
            this.Controls.Add(this.chkDebug);
            this.Controls.Add(this.chkError);
            this.Controls.Add(this.chkProfiling);
            this.Controls.Add(this.chkFollowLogTrail);
            this.Controls.Add(this.rteEventLog);
            this.Name = "Logger";
            this.Size = new System.Drawing.Size(600, 220);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.CheckBox chkWarning;
        private System.Windows.Forms.CheckBox chkInfo;
        private System.Windows.Forms.CheckBox chkDebug;
        private System.Windows.Forms.CheckBox chkError;
        private System.Windows.Forms.CheckBox chkProfiling;
        private System.Windows.Forms.CheckBox chkFollowLogTrail;
        private System.Windows.Forms.RichTextBox rteEventLog;


    }
}
