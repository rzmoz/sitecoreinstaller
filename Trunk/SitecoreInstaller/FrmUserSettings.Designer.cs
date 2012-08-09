namespace SitecoreInstaller
{
    partial class FrmUserSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUserSettings));
            this.pipelineProgress1 = new SitecoreInstaller.UI.PipelineProgress();
            this.SuspendLayout();
            // 
            // pipelineProgress1
            // 
            this.pipelineProgress1.Location = new System.Drawing.Point(0, 0);
            this.pipelineProgress1.Name = "pipelineProgress1";
            this.pipelineProgress1.Size = new System.Drawing.Size(400, 170);
            this.pipelineProgress1.TabIndex = 1;
            // 
            // FrmUserSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(401, 300);
            this.Controls.Add(this.pipelineProgress1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUserSettings";
            this.Text = "User Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private UI.PipelineProgress pipelineProgress1;



    }
}