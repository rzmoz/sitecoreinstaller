namespace SitecoreInstaller.UI
{
  using System;
  using System.Collections.Generic;
  using System.Drawing;
  using System.IO;
  using System.Linq;
  using System.Windows.Forms;

  using SitecoreInstaller.App;
  using SitecoreInstaller.Domain.BuildLibrary;
  using SitecoreInstaller.UI.ListBoxes;
  using SitecoreInstaller.UI.Properties;

  public partial class SelectSitecore : SourceEntryComboBox
  {
    public SelectSitecore()
    {
      InitializeComponent();
    }


    private void SelectSitecore_Load(object sender, EventArgs e)
    {
      cbxSitecore_SelectedIndexChanged(this, EventArgs.Empty);
    }

    protected override ComboBox ListBox
    {
      get { return cbxSitecore; }
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
      if (ListBox.Items.Count == 0)
      {
        lblSitecore.ForeColor = Color.Red;
        lblSitecore.Text = "You have no Sitecore versions";
        return;
      }
      lblSitecore.ForeColor = Styles.Fonts.Colors.Text; 
      lblSitecore.Text = string.Format("Sitecore:");
    }
  }
}
