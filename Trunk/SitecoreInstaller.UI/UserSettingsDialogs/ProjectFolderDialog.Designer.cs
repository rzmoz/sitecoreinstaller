namespace SitecoreInstaller.UI.UserSettingsDialogs
{
    partial class ProjectFolderDialog
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnProjectsFolder = new System.Windows.Forms.Button();
            this.tbxProjectsFolder = new System.Windows.Forms.TextBox();
            this.lblProjectsFolder = new System.Windows.Forms.Label();
            this.tbxDescription = new System.Windows.Forms.TextBox();
            this.lnkCreateProjectFolder = new System.Windows.Forms.LinkLabel();
            this.tbxMoreOptions = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(217)))));
            this.lblTitle.Location = new System.Drawing.Point(115, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(120, 24);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Project folder";
            // 
            // btnProjectsFolder
            // 
            this.btnProjectsFolder.Location = new System.Drawing.Point(315, 137);
            this.btnProjectsFolder.Name = "btnProjectsFolder";
            this.btnProjectsFolder.Size = new System.Drawing.Size(70, 22);
            this.btnProjectsFolder.TabIndex = 1;
            this.btnProjectsFolder.Text = "Browse...";
            this.btnProjectsFolder.UseVisualStyleBackColor = false;
            this.btnProjectsFolder.Click += new System.EventHandler(this.btnProjectsFolder_Click);
            // 
            // tbxProjectsFolder
            // 
            this.tbxProjectsFolder.Location = new System.Drawing.Point(115, 139);
            this.tbxProjectsFolder.Name = "tbxProjectsFolder";
            this.tbxProjectsFolder.Size = new System.Drawing.Size(195, 20);
            this.tbxProjectsFolder.TabIndex = 0;
            this.tbxProjectsFolder.TextChanged += new System.EventHandler(this.tbxProjectsFolder_TextChanged);
            // 
            // lblProjectsFolder
            // 
            this.lblProjectsFolder.AutoSize = true;
            this.lblProjectsFolder.Location = new System.Drawing.Point(115, 124);
            this.lblProjectsFolder.Name = "lblProjectsFolder";
            this.lblProjectsFolder.Size = new System.Drawing.Size(77, 13);
            this.lblProjectsFolder.TabIndex = 14;
            this.lblProjectsFolder.Text = "Projects folder:";
            // 
            // tbxDescription
            // 
            this.tbxDescription.BackColor = System.Drawing.Color.White;
            this.tbxDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxDescription.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbxDescription.Location = new System.Drawing.Point(115, 70);
            this.tbxDescription.Multiline = true;
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.ReadOnly = true;
            this.tbxDescription.Size = new System.Drawing.Size(270, 43);
            this.tbxDescription.TabIndex = 36;
            this.tbxDescription.TabStop = false;
            this.tbxDescription.Text = "The project folder contains your installatons.";
            // 
            // lnkCreateProjectFolder
            // 
            this.lnkCreateProjectFolder.AutoSize = true;
            this.lnkCreateProjectFolder.Location = new System.Drawing.Point(126, 185);
            this.lnkCreateProjectFolder.Name = "lnkCreateProjectFolder";
            this.lnkCreateProjectFolder.Size = new System.Drawing.Size(102, 13);
            this.lnkCreateProjectFolder.TabIndex = 38;
            this.lnkCreateProjectFolder.TabStop = true;
            this.lnkCreateProjectFolder.Text = "Create project folder";
            this.lnkCreateProjectFolder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCreateProjectFolder_LinkClicked);
            // 
            // tbxMoreOptions
            // 
            this.tbxMoreOptions.BackColor = System.Drawing.Color.White;
            this.tbxMoreOptions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxMoreOptions.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbxMoreOptions.Location = new System.Drawing.Point(115, 170);
            this.tbxMoreOptions.Multiline = true;
            this.tbxMoreOptions.Name = "tbxMoreOptions";
            this.tbxMoreOptions.ReadOnly = true;
            this.tbxMoreOptions.Size = new System.Drawing.Size(270, 39);
            this.tbxMoreOptions.TabIndex = 37;
            this.tbxMoreOptions.TabStop = false;
            this.tbxMoreOptions.Text = "Project folder does not exist:\r\n»";
            // 
            // ProjectFolderDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lnkCreateProjectFolder);
            this.Controls.Add(this.tbxMoreOptions);
            this.Controls.Add(this.tbxDescription);
            this.Controls.Add(this.btnProjectsFolder);
            this.Controls.Add(this.tbxProjectsFolder);
            this.Controls.Add(this.lblProjectsFolder);
            this.Controls.Add(this.lblTitle);
            this.Name = "ProjectFolderDialog";
            this.Load += new System.EventHandler(this.FilesAndFoldersDialog_Load);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.lblProjectsFolder, 0);
            this.Controls.SetChildIndex(this.tbxProjectsFolder, 0);
            this.Controls.SetChildIndex(this.btnProjectsFolder, 0);
            this.Controls.SetChildIndex(this.tbxDescription, 0);
            this.Controls.SetChildIndex(this.tbxMoreOptions, 0);
            this.Controls.SetChildIndex(this.lnkCreateProjectFolder, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnProjectsFolder;
        private System.Windows.Forms.TextBox tbxProjectsFolder;
        private System.Windows.Forms.Label lblProjectsFolder;
        private System.Windows.Forms.TextBox tbxDescription;
        private System.Windows.Forms.LinkLabel lnkCreateProjectFolder;
        private System.Windows.Forms.TextBox tbxMoreOptions;

    }
}
