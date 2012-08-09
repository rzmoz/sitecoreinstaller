using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SitecoreInstaller.UI.UserSettingsDialogs
{
    using System.IO;

    using SitecoreInstaller.App;
    using SitecoreInstaller.App.Properties;
    using SitecoreInstaller.Domain.BuildLibrary;
    using SitecoreInstaller.Framework.IO;

    public partial class ProjectFolderDialog : UserSettingsDialog
    {
        public ProjectFolderDialog()
        {
            InitializeComponent();
        }

        public override void Init()
        {
            base.Init();
            tbxProjectsFolder.Focus();

        }
        private void FilesAndFoldersDialog_Load(object sender, EventArgs e)
        {
            tbxProjectsFolder.Text = UserSettings.Default.ProjectsFolder;
        }

        public override void BtnSaveClick()
        {
            base.BtnSaveClick();
            UserSettings.Default.ProjectsFolder = tbxProjectsFolder.Text;
            UserSettings.Default.Save();
            Services.Init();
            Services.BuildLibrary.Update();
        }

        private void btnProjectsFolder_Click(object sender, EventArgs e)
        {
            string selectedFolder;
            if (Services.Dialogs.ChooseFolder(out selectedFolder, tbxProjectsFolder.Text))
                tbxProjectsFolder.Text = selectedFolder;
        }

        private void tbxProjectsFolder_TextChanged(object sender, EventArgs e)
        {
            lnkCreateProjectFolder.Visible = !Directory.Exists(tbxProjectsFolder.Text);
            tbxMoreOptions.Visible = !Directory.Exists(tbxProjectsFolder.Text);
        }

        private void lnkCreateProjectFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Directory.Exists(tbxProjectsFolder.Text))
                return;
            Directory.CreateDirectory(tbxProjectsFolder.Text);
            tbxProjectsFolder_TextChanged(this, EventArgs.Empty);
            Services.Dialogs.Information("'{0}' was created.", tbxProjectsFolder.Text);
        }
    }
}
