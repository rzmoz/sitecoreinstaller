using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using CSharp.Basics.Forms;
using SitecoreInstaller.App;
using SitecoreInstaller.Domain.BuildLibrary;
using SitecoreInstaller.UI.ListBoxes;
using SitecoreInstaller.Framework.Sys;

namespace SitecoreInstaller.UI.UserSelections
{
    public partial class SelectLicense : SourceEntryComboBox
    {
        public SelectLicense()
        {
            InitializeComponent();
        }

        private void SelectLicense_Load(object sender, EventArgs e)
        {
            cbxLicenses_SelectedIndexChanged(this, EventArgs.Empty);
        }

        public string LicenseText
        {
            get { return lblLicenses.Text; }
        }

        protected override ComboBox ListBox
        {
            get { return cbxLicenses; }
        }
        protected override IEnumerable<SourceEntry> ListDataSource
        {
            get
            {
                var licenses = Services.BuildLibrary.List(SourceType.License).OrderBy(license => license).ToList();
                return licenses;
            }
        }

        private void cbxLicenses_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.CrossThreadSafe(() =>
            {
                if (ListBox.Items.Count == 0)
                {
                    lblLicenses.ForeColor = Color.Red;
                    lblLicenses.Text = "You have no licenses";
                    return;
                }

                if (ListBox.SelectedItem is LicenseFileSourceEntry == false)
                    return;

                var licenseFile = (ListBox.SelectedItem as LicenseFileSourceEntry).LicenseFile;
                if (licenseFile.IsExpired)
                {
                    lblLicenses.ForeColor = Color.Red;
                    lblLicenses.Text = string.Format("License has expired:");
                    return;
                }

                if (licenseFile.ExpiresIn <= Services.UserPreferences.Properties.LicenseExpirationPeriodInDays)
                {
                    lblLicenses.ForeColor = Color.Blue;
                    lblLicenses.Text = string.Format("License: (expires in {0} days)", licenseFile.ExpiresIn);
                    return;
                }
                lblLicenses.ForeColor = Styles.Fonts.DarkBg.Colors.Text;
                lblLicenses.Text = string.Format("License:");
            });
        }

        protected override SourceEntry GetRelevantSourceEntry(BuildLibrarySelections buildLibrarySelections)
        {
            return buildLibrarySelections.SelectedLicense;
        }
    }
}
