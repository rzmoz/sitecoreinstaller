namespace SitecoreInstaller.UI.UserSettingsDialogs
{
    partial class BuildLibraryFolderDialog
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
            this.tbxDescription = new System.Windows.Forms.TextBox();
            this.lnkCreateProjectFolder = new System.Windows.Forms.LinkLabel();
            this.tbxMoreOptions = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnLocalBuildLibrary = new System.Windows.Forms.Button();
            this.tbxBuildLibraryFolder = new System.Windows.Forms.TextBox();
            this.lblLocalBuildLibrary = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.tbxDescription.Size = new System.Drawing.Size(270, 40);
            this.tbxDescription.TabIndex = 35;
            this.tbxDescription.TabStop = false;
            this.tbxDescription.Text = "This folder is used as local cache for faster re-installation.";
            // 
            // lnkCreateProjectFolder
            // 
            this.lnkCreateProjectFolder.AutoSize = true;
            this.lnkCreateProjectFolder.Location = new System.Drawing.Point(126, 185);
            this.lnkCreateProjectFolder.Name = "lnkCreateProjectFolder";
            this.lnkCreateProjectFolder.Size = new System.Drawing.Size(122, 13);
            this.lnkCreateProjectFolder.TabIndex = 33;
            this.lnkCreateProjectFolder.TabStop = true;
            this.lnkCreateProjectFolder.Text = "Create build library folder";
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
            this.tbxMoreOptions.TabIndex = 32;
            this.tbxMoreOptions.TabStop = false;
            this.tbxMoreOptions.Text = "Build library folder does not exist:\r\n»";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(217)))));
            this.lblTitle.Location = new System.Drawing.Point(115, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(159, 24);
            this.lblTitle.TabIndex = 31;
            this.lblTitle.Text = "Build library folder";
            // 
            // btnLocalBuildLibrary
            // 
            this.btnLocalBuildLibrary.Location = new System.Drawing.Point(315, 137);
            this.btnLocalBuildLibrary.Name = "btnLocalBuildLibrary";
            this.btnLocalBuildLibrary.Size = new System.Drawing.Size(70, 22);
            this.btnLocalBuildLibrary.TabIndex = 37;
            this.btnLocalBuildLibrary.Text = "Browse...";
            this.btnLocalBuildLibrary.UseVisualStyleBackColor = false;
            this.btnLocalBuildLibrary.Click += new System.EventHandler(this.btnLocalBuildLibrary_Click);
            // 
            // tbxBuildLibraryFolder
            // 
            this.tbxBuildLibraryFolder.Location = new System.Drawing.Point(115, 139);
            this.tbxBuildLibraryFolder.Name = "tbxBuildLibraryFolder";
            this.tbxBuildLibraryFolder.Size = new System.Drawing.Size(194, 20);
            this.tbxBuildLibraryFolder.TabIndex = 36;
            this.tbxBuildLibraryFolder.TextChanged += new System.EventHandler(this.tbxBuildLibraryFolder_TextChanged);
            // 
            // lblLocalBuildLibrary
            // 
            this.lblLocalBuildLibrary.AutoSize = true;
            this.lblLocalBuildLibrary.Location = new System.Drawing.Point(112, 124);
            this.lblLocalBuildLibrary.Name = "lblLocalBuildLibrary";
            this.lblLocalBuildLibrary.Size = new System.Drawing.Size(120, 13);
            this.lblLocalBuildLibrary.TabIndex = 38;
            this.lblLocalBuildLibrary.Text = "Local build library folder:";
            // 
            // BuildLibraryFolderDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnLocalBuildLibrary);
            this.Controls.Add(this.tbxBuildLibraryFolder);
            this.Controls.Add(this.lblLocalBuildLibrary);
            this.Controls.Add(this.tbxDescription);
            this.Controls.Add(this.lnkCreateProjectFolder);
            this.Controls.Add(this.tbxMoreOptions);
            this.Controls.Add(this.lblTitle);
            this.Name = "BuildLibraryFolderDialog";
            this.Load += new System.EventHandler(this.BuildLibraryFolderDialog_Load);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.tbxMoreOptions, 0);
            this.Controls.SetChildIndex(this.lnkCreateProjectFolder, 0);
            this.Controls.SetChildIndex(this.tbxDescription, 0);
            this.Controls.SetChildIndex(this.lblLocalBuildLibrary, 0);
            this.Controls.SetChildIndex(this.tbxBuildLibraryFolder, 0);
            this.Controls.SetChildIndex(this.btnLocalBuildLibrary, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxDescription;
        private System.Windows.Forms.LinkLabel lnkCreateProjectFolder;
        private System.Windows.Forms.TextBox tbxMoreOptions;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnLocalBuildLibrary;
        private System.Windows.Forms.TextBox tbxBuildLibraryFolder;
        private System.Windows.Forms.Label lblLocalBuildLibrary;
    }
}
