namespace SitecoreInstaller.UI
{
    partial class PipelineLists
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
            this.tabPipelineLists = new System.Windows.Forms.TabControl();
            this.pipelineStepListAll = new System.Windows.Forms.TabPage();
            this.btnUninstall = new System.Windows.Forms.Button();
            this.btnInstall = new System.Windows.Forms.Button();
            this.tabInstall = new System.Windows.Forms.TabPage();
            this.pipelineStepListInstall = new SitecoreInstaller.UI.PipelineStepList();
            this.tabUninstall = new System.Windows.Forms.TabPage();
            this.pipelineStepListUninstall = new SitecoreInstaller.UI.PipelineStepList();
            this.tabReAttach = new System.Windows.Forms.TabPage();
            this.pipelineStepListReAttach = new SitecoreInstaller.UI.PipelineStepList();
            this.btnReAttach = new System.Windows.Forms.Button();
            this.tabPipelineLists.SuspendLayout();
            this.pipelineStepListAll.SuspendLayout();
            this.tabInstall.SuspendLayout();
            this.tabUninstall.SuspendLayout();
            this.tabReAttach.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPipelineLists
            // 
            this.tabPipelineLists.Controls.Add(this.pipelineStepListAll);
            this.tabPipelineLists.Controls.Add(this.tabInstall);
            this.tabPipelineLists.Controls.Add(this.tabUninstall);
            this.tabPipelineLists.Controls.Add(this.tabReAttach);
            this.tabPipelineLists.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPipelineLists.Location = new System.Drawing.Point(0, 0);
            this.tabPipelineLists.Name = "tabPipelineLists";
            this.tabPipelineLists.SelectedIndex = 0;
            this.tabPipelineLists.Size = new System.Drawing.Size(300, 370);
            this.tabPipelineLists.TabIndex = 0;
            // 
            // pipelineStepListAll
            // 
            this.pipelineStepListAll.Controls.Add(this.btnReAttach);
            this.pipelineStepListAll.Controls.Add(this.btnUninstall);
            this.pipelineStepListAll.Controls.Add(this.btnInstall);
            this.pipelineStepListAll.Location = new System.Drawing.Point(4, 22);
            this.pipelineStepListAll.Name = "pipelineStepListAll";
            this.pipelineStepListAll.Padding = new System.Windows.Forms.Padding(3);
            this.pipelineStepListAll.Size = new System.Drawing.Size(292, 344);
            this.pipelineStepListAll.TabIndex = 2;
            this.pipelineStepListAll.Text = "All";
            this.pipelineStepListAll.UseVisualStyleBackColor = true;
            // 
            // btnUninstall
            // 
            this.btnUninstall.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUninstall.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUninstall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(27)))), ((int)(((byte)(82)))));
            this.btnUninstall.Location = new System.Drawing.Point(6, 42);
            this.btnUninstall.Name = "btnUninstall";
            this.btnUninstall.Size = new System.Drawing.Size(280, 30);
            this.btnUninstall.TabIndex = 1;
            this.btnUninstall.Text = "Uninstall";
            this.btnUninstall.UseVisualStyleBackColor = false;
            this.btnUninstall.Click += new System.EventHandler(this.btnUninstall_Click);
            // 
            // btnInstall
            // 
            this.btnInstall.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInstall.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInstall.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(27)))), ((int)(((byte)(82)))));
            this.btnInstall.Location = new System.Drawing.Point(6, 6);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(280, 30);
            this.btnInstall.TabIndex = 0;
            this.btnInstall.Text = "Install";
            this.btnInstall.UseVisualStyleBackColor = false;
            this.btnInstall.Click += new System.EventHandler(this.btnInstall_Click);
            // 
            // tabInstall
            // 
            this.tabInstall.Controls.Add(this.pipelineStepListInstall);
            this.tabInstall.Location = new System.Drawing.Point(4, 22);
            this.tabInstall.Name = "tabInstall";
            this.tabInstall.Size = new System.Drawing.Size(292, 344);
            this.tabInstall.TabIndex = 0;
            this.tabInstall.Text = "Install";
            this.tabInstall.UseVisualStyleBackColor = true;
            // 
            // pipelineStepListInstall
            // 
            this.pipelineStepListInstall.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pipelineStepListInstall.Location = new System.Drawing.Point(0, 0);
            this.pipelineStepListInstall.Name = "pipelineStepListInstall";
            this.pipelineStepListInstall.Size = new System.Drawing.Size(292, 344);
            this.pipelineStepListInstall.TabIndex = 0;
            // 
            // tabUninstall
            // 
            this.tabUninstall.Controls.Add(this.pipelineStepListUninstall);
            this.tabUninstall.Location = new System.Drawing.Point(4, 22);
            this.tabUninstall.Name = "tabUninstall";
            this.tabUninstall.Size = new System.Drawing.Size(292, 344);
            this.tabUninstall.TabIndex = 1;
            this.tabUninstall.Text = "Uninstall";
            this.tabUninstall.UseVisualStyleBackColor = true;
            // 
            // pipelineStepListUninstall
            // 
            this.pipelineStepListUninstall.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pipelineStepListUninstall.Location = new System.Drawing.Point(0, 0);
            this.pipelineStepListUninstall.Name = "pipelineStepListUninstall";
            this.pipelineStepListUninstall.Size = new System.Drawing.Size(292, 344);
            this.pipelineStepListUninstall.TabIndex = 0;
            // 
            // tabReAttach
            // 
            this.tabReAttach.Controls.Add(this.pipelineStepListReAttach);
            this.tabReAttach.Location = new System.Drawing.Point(4, 22);
            this.tabReAttach.Name = "tabReAttach";
            this.tabReAttach.Size = new System.Drawing.Size(292, 344);
            this.tabReAttach.TabIndex = 3;
            this.tabReAttach.Text = "Re-Attach";
            this.tabReAttach.UseVisualStyleBackColor = true;
            // 
            // pipelineStepListReAttach
            // 
            this.pipelineStepListReAttach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pipelineStepListReAttach.Location = new System.Drawing.Point(0, 0);
            this.pipelineStepListReAttach.Name = "pipelineStepListReAttach";
            this.pipelineStepListReAttach.Size = new System.Drawing.Size(292, 344);
            this.pipelineStepListReAttach.TabIndex = 0;
            // 
            // btnReAttach
            // 
            this.btnReAttach.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReAttach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReAttach.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(27)))), ((int)(((byte)(82)))));
            this.btnReAttach.Location = new System.Drawing.Point(6, 78);
            this.btnReAttach.Name = "btnReAttach";
            this.btnReAttach.Size = new System.Drawing.Size(280, 30);
            this.btnReAttach.TabIndex = 2;
            this.btnReAttach.Text = "Re-Attach";
            this.btnReAttach.UseVisualStyleBackColor = false;
            this.btnReAttach.Click += new System.EventHandler(this.btnReAttach_Click);
            // 
            // PipelineLists
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabPipelineLists);
            this.Name = "PipelineLists";
            this.Size = new System.Drawing.Size(300, 370);
            this.tabPipelineLists.ResumeLayout(false);
            this.pipelineStepListAll.ResumeLayout(false);
            this.tabInstall.ResumeLayout(false);
            this.tabUninstall.ResumeLayout(false);
            this.tabReAttach.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabPipelineLists;
        private System.Windows.Forms.TabPage tabInstall;
        private PipelineStepList pipelineStepListInstall;
        private System.Windows.Forms.TabPage tabUninstall;
        private PipelineStepList pipelineStepListUninstall;
        private System.Windows.Forms.TabPage pipelineStepListAll;
        private System.Windows.Forms.Button btnUninstall;
        private System.Windows.Forms.Button btnInstall;
        private System.Windows.Forms.TabPage tabReAttach;
        private PipelineStepList pipelineStepListReAttach;
        private System.Windows.Forms.Button btnReAttach;


    }
}
