namespace SitecoreInstaller.UI.UserSelections
{
  using System;
  using System.Drawing;
  using System.Linq;
  using System.Windows.Forms;
  using System.Collections.Generic;
  using SitecoreInstaller.App;
  using SitecoreInstaller.Domain.BuildLibrary;
  using SitecoreInstaller.UI.ListBoxes;

  public partial class SelectLicense : SourceEntryComboBox
  {
    public SelectLicense()
    {
      this.InitializeComponent();
    }

    private void SelectLicense_Load(object sender, EventArgs e)
    {
      this.cbxLicenses_SelectedIndexChanged(this, EventArgs.Empty);
    }

    public string LicenseText
    {
      get { return this.lblLicenses.Text; }
    }

    protected override ComboBox ListBox
    {
      get { return this.cbxLicenses; }
    }
    protected override IEnumerable<SourceEntry> ListDataSource
    {
      get
      {
        var licenses = Services.BuildLibrary.List(SourceType.License).ToList();
        licenses.Sort();
        return licenses;
      }
    }

    private void cbxLicenses_SelectedIndexChanged(object sender, System.EventArgs e)
    {
      if (this.ListBox.Items.Count == 0)
      {
        this.lblLicenses.ForeColor = Color.Red;
        this.lblLicenses.Text = "You have no licenses";
        return;
      }

      if (this.ListBox.SelectedItem is LicenseFileSourceEntry == false)
        return;

      var licenseFile = (this.ListBox.SelectedItem as LicenseFileSourceEntry).LicenseFile;
      if (licenseFile.IsExpired)
      {
        this.lblLicenses.ForeColor = Color.Red;
        this.lblLicenses.Text = string.Format("License has expired:");
        return;
      }

      if (licenseFile.ExpiresIn <= Services.UserPreferences.Properties.LicenseExpirationPeriodInDays)
      {
        this.lblLicenses.ForeColor = Color.Blue;
        this.lblLicenses.Text = string.Format("License: (expires in {0} days)", licenseFile.ExpiresIn);
        return;
      }
      this.lblLicenses.ForeColor = Styles.Fonts.Colors.Text;
      this.lblLicenses.Text = string.Format("License:");
    }

    protected override SourceEntry GetRelevantSourceEntry(BuildLibrarySelections buildLibrarySelections)
    {
      return buildLibrarySelections.SelectedLicense;
    }
  }
}
