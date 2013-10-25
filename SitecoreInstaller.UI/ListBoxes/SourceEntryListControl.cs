using SitecoreInstaller.Framework.Sys;

namespace SitecoreInstaller.UI.ListBoxes
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Windows.Forms;

  using SitecoreInstaller.App;
  using SitecoreInstaller.Domain.BuildLibrary;

  public class SourceEntryListControl<T> : UserControl where T : ListControl
  {
    private List<SourceEntry> _items;
    public virtual void Init()
    {
      if (ListBox == null)
        return;

      UpdateListItems(this, EventArgs.Empty);
      Services.BuildLibrary.Updated += UpdateListItems;
    }

    protected virtual T ListBox { get; set; }
    protected virtual IEnumerable<SourceEntry> ListDataSource { get; set; }

    public int Count()
    {
      return ((IEnumerable<SourceEntry>)ListBox.DataSource).Count();
    }

    public void DirectoryInfo_Format(object sender, ListControlConvertEventArgs e)
    {
      string itemName = ((SourceEntry)e.ListItem).Key;
      string itemSource = ((SourceEntry)e.ListItem).SourceName;

      e.Value = itemName;
      if (itemSource.Length > 0)
        e.Value += " [" + itemSource + "]";
    }

    void UpdateListItems(object sender, EventArgs e)
    {
      if (ListBox == null)
        return;
      this.CrossThreadSafe(() =>
      {
        SourceEntry selectedItem = null;
        if (ListBox.DataSource != null && ListBox.SelectedIndex > -1)
        {
          _items = ((IEnumerable<SourceEntry>)ListBox.DataSource).ToList();
          selectedItem = _items[ListBox.SelectedIndex];
          _items = ListDataSource.ToList();
        }

        ListBox.DataSource = ListDataSource;
        ListBox.Format += DirectoryInfo_Format;
        ListBox.DisplayMember = "key";
        ListBox.ValueMember = "sourcename";

        if (selectedItem != null)
        {
          var selectedIndex = _items.IndexOf(selectedItem);
          if (selectedIndex < 0)
            selectedIndex = ((IEnumerable<SourceEntry>)ListBox.DataSource).Count() - 1;
          ListBox.SelectedIndex = selectedIndex;
        }  
      });
    }
  }
}