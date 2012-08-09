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
    using SitecoreInstaller.App;
    using SitecoreInstaller.Domain.BuildLibrary;
    using SitecoreInstaller.UI.Properties;

    public partial class LicenseFileDialog : UserSettingsDialog
    {
        public LicenseFileDialog()
        {
            InitializeComponent();
        }


        public override void Init()
        {
            base.Init();
            selectLicense1.Init();
        }

        private void LicenseFileDialog_Load(object sender, EventArgs e)
        {
            Services.BuildLibrary.Update();
        }

        private void lnkAddLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string selectedFile;
            if (Services.Dialogs.AddLicense(out selectedFile) == false)
                return;
            var buildLibraryFile = Services.BuildLibrary.Add(selectedFile, SourceType.License);
            Services.Dialogs.Information("'{0}' was added", buildLibraryFile.ToString());
        }

        private void lnkRemoveSelected_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var selectedLicense = selectLicense1.SelectedItem;
            if (Services.Dialogs.RemoveBuildLibraryResource(selectedLicense) == false)
                return;
            Services.BuildLibrary.Delete(selectedLicense, SourceType.License);
            Services.Dialogs.Information("'{0}' was removed", selectedLicense.Key);
        }
    }
}
