namespace SitecoreInstaller
{
    partial class FrmPipelineResult
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPipelineResult));
            this.pipelineResult1 = new SitecoreInstaller.UI.PipelineResult();
            this.SuspendLayout();
            // 
            // pipelineResult1
            // 
            this.pipelineResult1.Location = new System.Drawing.Point(0, 0);
            this.pipelineResult1.Name = "pipelineResult1";
            this.pipelineResult1.Size = new System.Drawing.Size(400, 120);
            this.pipelineResult1.TabIndex = 0;
            // 
            // FrmPipelineResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(401, 122);
            this.ControlBox = false;
            this.Controls.Add(this.pipelineResult1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPipelineResult";
            this.Text = "Finished";
            this.Load += new System.EventHandler(this.FrmPipelineResultLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private UI.PipelineResult pipelineResult1;






    }
}