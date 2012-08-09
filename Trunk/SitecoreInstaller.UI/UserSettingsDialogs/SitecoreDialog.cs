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
    using SitecoreInstaller.Domain.BuildLibrary;

    public partial class SitecoreDialog : UserSettingsDialog
    {
        public SitecoreDialog()
        {
            InitializeComponent();
        }

        public override void Init()
        {
            base.Init();
            selectSitecore1.Init();
        }
        private void LicensesDialog_Load(object sender, EventArgs e)
        {
            Services.BuildLibrary.Update();
        }

        private void lnkAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string selectedFile;
            if (Services.Dialogs.AddSitecore(out selectedFile) == false)
                return;
            var buildLibraryFile = Services.BuildLibrary.Add(selectedFile, SourceType.Sitecore);
            Services.Dialogs.Information("'{0}' was added", buildLibraryFile.ToString());
        }

        private void lnkRemoveSelected_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var selectedSitecore = selectSitecore1.SelectedItem;
            if (Services.Dialogs.RemoveBuildLibraryResource(selectedSitecore) == false)
                return;
            Services.BuildLibrary.Delete(selectedSitecore, SourceType.Sitecore);
            Services.Dialogs.Information("'{0}' was removed", selectedSitecore.Key);
        }
    }
}
