namespace SitecoreInstaller.UI.UserSelections
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Windows.Forms;
  using SitecoreInstaller.App;
  using SitecoreInstaller.Domain.BuildLibrary;
  using SitecoreInstaller.Framework.System;
  using SitecoreInstaller.UI.ListBoxes;

  public partial class SelectModules : SourceEntryCheckedListBox
  {
    public SelectModules()
    {
      this.InitializeComponent();
    }

    public void BuildLibrarySelectionsUpdated(object sender, GenericEventArgs<BuildLibrarySelections> e)
    {
      for (var i = 0; i < this.chkModules.Items.Count; i++)
      {
        var isChecked = e.Arg.SelectedModules.Select(module => module.Key).ContainsCaseInsensitive(((SourceEntry)this.chkModules.Items[i]).Key);
        this.chkModules.SetItemChecked(i, isChecked);
      }
    }

    private void SelectModules_Load(object sender, EventArgs e)
    {
      if (this.chkModules.Items.Count > 0)
        this.chkModules.SetItemChecked(0, true);//default check first module
    }

    protected override CheckedListBox ListBox
    {
      get { return this.chkModules; }
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
        return (from object item in this.chkModules.CheckedItems select item).Cast<SourceEntry>();
      }
    }
  }
}
