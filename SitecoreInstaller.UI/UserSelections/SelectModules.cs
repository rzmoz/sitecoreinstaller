﻿namespace SitecoreInstaller.UI.UserSelections
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Windows.Forms;
  using SitecoreInstaller.App;
  using SitecoreInstaller.Domain.BuildLibrary;
  using SitecoreInstaller.Framework.Sys;
  using SitecoreInstaller.UI.ListBoxes;

  public partial class SelectModules : SourceEntryCheckedListBox
  {
    public SelectModules()
    {
      this.InitializeComponent();
    }

    public void BuildLibrarySelectionsUpdated(object sender, GenericEventArgs<BuildLibrarySelections> e)
    {
      this.CrossThreadSafe(() =>
      {
        for (var i = 0; i < chkModules.Items.Count; i++)
        {
          var isChecked = e.Arg.SelectedModules.Select(module => module.Key).ContainsCaseInsensitive(((SourceEntry)chkModules.Items[i]).Key);
          chkModules.SetItemChecked(i, isChecked);
        }  
      });
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
