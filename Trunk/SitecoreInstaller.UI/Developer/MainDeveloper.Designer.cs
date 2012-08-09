namespace SitecoreInstaller.UI.Developer
{
    partial class MainDeveloper
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
            this.pnlAdvanced = new System.Windows.Forms.Panel();
            this._pipelineLists1 = new SitecoreInstaller.UI.PipelineLists();
            this._selectAppPoolSettings1 = new SitecoreInstaller.UI.Developer.SelectAppPoolSettings();
            this._selectionsDeveloper1 = new SitecoreInstaller.UI.Developer.SelectionsDeveloper();
            this.pnlAdvanced.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlAdvanced
            // 
            this.pnlAdvanced.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pnlAdvanced.Controls.Add(this._pipelineLists1);
            this.pnlAdvanced.Controls.Add(this._selectAppPoolSettings1);
            this.pnlAdvanced.Location = new System.Drawing.Point(295, 0);
            this.pnlAdvanced.Margin = new System.Windows.Forms.Padding(0);
            this.pnlAdvanced.Name = "pnlAdvanced";
            this.pnlAdvanced.Size = new System.Drawing.Size(305, 375);
            this.pnlAdvanced.TabIndex = 1;
            // 
            // _pipelineLists1
            // 
            this._pipelineLists1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._pipelineLists1.Location = new System.Drawing.Point(105, 0);
            this._pipelineLists1.Margin = new System.Windows.Forms.Padding(0);
            this._pipelineLists1.Name = "_pipelineLists1";
            this._pipelineLists1.Size = new System.Drawing.Size(200, 375);
            this._pipelineLists1.TabIndex = 4;
            // 
            // _selectAppPoolSettings1
            // 
            this._selectAppPoolSettings1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._selectAppPoolSettings1.Location = new System.Drawing.Point(3, 4);
            this._selectAppPoolSettings1.Margin = new System.Windows.Forms.Padding(0);
            this._selectAppPoolSettings1.Name = "_selectAppPoolSettings1";
            this._selectAppPoolSettings1.Size = new System.Drawing.Size(100, 235);
            this._selectAppPoolSettings1.TabIndex = 3;
            // 
            // _selectionsDeveloper1
            // 
            this._selectionsDeveloper1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this._selectionsDeveloper1.Location = new System.Drawing.Point(0, 0);
            this._selectionsDeveloper1.Margin = new System.Windows.Forms.Padding(0);
            this._selectionsDeveloper1.Name = "_selectionsDeveloper1";
            this._selectionsDeveloper1.Size = new System.Drawing.Size(295, 376);
            this._selectionsDeveloper1.TabIndex = 0;
            // 
            // MainDeveloper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._selectionsDeveloper1);
            this.Controls.Add(this.pnlAdvanced);
            this.Name = "MainDeveloper";
            this.Size = new System.Drawing.Size(605, 376);
            this.pnlAdvanced.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SelectionsDeveloper _selectionsDeveloper1;
        private System.Windows.Forms.Panel pnlAdvanced;
        private PipelineLists _pipelineLists1;
        private SelectAppPoolSettings _selectAppPoolSettings1;





    }
}
