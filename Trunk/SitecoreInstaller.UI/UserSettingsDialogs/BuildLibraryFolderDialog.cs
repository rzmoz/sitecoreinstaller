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
    using SitecoreInstaller.Framework.IO;

    public partial class BuildLibraryFolderDialog : UserSettingsDialog
    {
        public BuildLibraryFolderDialog()
        {
            InitializeComponent();
        }
        public override void Init()
        {
            base.Init();
            tbxBuildLibraryFolder.Focus();

        }

        private void BuildLibraryFolderDialog_Load(object sender, EventArgs e)
        {
            tbxBuildLibraryFolder.Text = UserSettings.Default.LocalBuildLibrary;
        }
        public override void BtnSaveClick()
        {
            base.BtnSaveClick();
            UserSettings.Default.LocalBuildLibrary = tbxBuildLibraryFolder.Text;
            UserSettings.Default.Save();
            Services.Init();
            Services.BuildLibrary.Update();
        }

        private void btnLocalBuildLibrary_Click(object sender, EventArgs e)
        {
            string selectedFolder;
            if (Services.Dialogs.ChooseFolder(out selectedFolder, tbxBuildLibraryFolder.Text))
                tbxBuildLibraryFolder.Text = selectedFolder;
        }

        private void lnkCreateProjectFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Directory.Exists(tbxBuildLibraryFolder.Text))
                return;
            Directory.CreateDirectory(tbxBuildLibraryFolder.Text);
            tbxBuildLibraryFolder_TextChanged(this, EventArgs.Empty);
            Services.Dialogs.Information("'{0}' was created.", tbxBuildLibraryFolder.Text);
        }

        private void tbxBuildLibraryFolder_TextChanged(object sender, EventArgs e)
        {
            lnkCreateProjectFolder.Visible = !Directory.Exists(tbxBuildLibraryFolder.Text);
            tbxMoreOptions.Visible = !Directory.Exists(tbxBuildLibraryFolder.Text);
        }
    }
}
