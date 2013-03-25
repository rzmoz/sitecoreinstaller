namespace SitecoreInstaller.UI
{
  using System;
  using System.Collections.Generic;
  using System.IO;
  using System.Linq;
  using System.Windows.Forms;

  using SitecoreInstaller.App;
  using SitecoreInstaller.Domain.BuildLibrary;
  using SitecoreInstaller.Framework.System;
  using SitecoreInstaller.UI.ListBoxes;
  using SitecoreInstaller.UI.Properties;

  public partial class SelectModules : SourceEntryCheckedListBox
  {
    public SelectModules()
    {
      InitializeComponent();
    }

    public void BuildLibrarySelectionsUpdated(object sender, GenericEventArgs<BuildLibrarySelections> e)
    {
      for (var i = 0; i < chkModules.Items.Count; i++)
      {
        var isChecked = e.Arg.SelectedModules.Select(module => module.Key).ContainsCaseInsensitive(((SourceEntry)chkModules.Items[i]).Key);
        chkModules.SetItemChecked(i, isChecked);
      }
    }

    private void SelectModules_Load(object sender, EventArgs e)
    {
      if (chkModules.Items.Count > 0)
        chkModules.SetItemChecked(0, true);//default check first module
    }

    protected override CheckedListBox ListBox
    {
      get { return chkModules; }
    }

    protected override IEnumerable<SourceEntry> ListDataSource
    {
      get
      {
        var modules = Services.BuildLibrary.List(SourceType.Module).ToList();
        modules.Sort();
        return modules;
      }
    }

    public IEnumerable<SourceEntry> SelectedModules
    {
      get
      {
        return (from object item in chkModules.CheckedItems select item).Cast<SourceEntry>();
      }
    }
  }
}
