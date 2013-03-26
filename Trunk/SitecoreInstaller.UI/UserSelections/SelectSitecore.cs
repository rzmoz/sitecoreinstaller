namespace SitecoreInstaller.UI.UserSelections
{
  using System;
  using System.Collections.Generic;
  using System.Drawing;
  using System.Linq;
  using System.Windows.Forms;
  using SitecoreInstaller.App;
  using SitecoreInstaller.Domain.BuildLibrary;
  using SitecoreInstaller.UI.ListBoxes;

  public partial class SelectSitecore : SourceEntryComboBox
  {
    public SelectSitecore()
    {
      this.InitializeComponent();
    }

    private void SelectSitecore_Load(object sender, EventArgs e)
    {
      this.cbxSitecore_SelectedIndexChanged(this, EventArgs.Empty);
    }

    protected override ComboBox ListBox
    {
      get { return this.cbxSitecore; }
    }
    protected override IEnumerable<SourceEntry> ListDataSource
    {
      get
      {
        var sitecores = Services.BuildLibrary.List(SourceType.Sitecore).ToList();
        sitecores.Sort();
        return sitecores;
      }
    }
    private void cbxSitecore_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.ListBox.Items.Count == 0)
      {
        this.lblSitecore.ForeColor = Color.Red;
        this.lblSitecore.Text = "You have no Sitecore versions";
        return;
      }
      this.lblSitecore.ForeColor = Styles.Fonts.Colors.Text;
      this.lblSitecore.Text = string.Format("Sitecore:");
    }

    protected override SourceEntry GetRelevantSourceEntry(BuildLibrarySelections buildLibrarySelections)
    {
      return buildLibrarySelections.SelectedSitecore;
    }
  }
}
