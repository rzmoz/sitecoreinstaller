namespace SitecoreInstaller.UI.UserSettingsDialogs
{
    partial class StepWizardDialog
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
            this.lblMarker = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMarker
            // 
            this.lblMarker.AutoSize = true;
            this.lblMarker.Location = new System.Drawing.Point(24, 23);
            this.lblMarker.Name = "lblMarker";
            this.lblMarker.Size = new System.Drawing.Size(127, 13);
            this.lblMarker.TabIndex = 0;
            this.lblMarker.Text = "StepWizardDialog marker";
            // 
            // StepWizardDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblMarker);
            this.Name = "StepWizardDialog";
            this.Size = new System.Drawing.Size(400, 300);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMarker;
    }
}
