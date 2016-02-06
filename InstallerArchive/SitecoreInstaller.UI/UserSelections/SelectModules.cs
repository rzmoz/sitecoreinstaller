using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CSharp.Basics.Sys;
using SitecoreInstaller.App;
using SitecoreInstaller.Domain.BuildLibrary;
using SitecoreInstaller.Domain.Projects;
using SitecoreInstaller.Framework.Sys;
using SitecoreInstaller.UI.ListBoxes;

namespace SitecoreInstaller.UI.UserSelections
{
    public partial class SelectModules : SourceEntryCheckedListBox
    {
        public SelectModules()
        {
            InitializeComponent();
        }

        public void BuildLibrarySelectionsUpdated(object sender, GenericEventArgs<ProjectSettings> e)
        {
            for (var i = 0; i < chkModules.Items.Count; i++)
            {
                var isChecked = e.Arg.BuildLibrarySelections.SelectedModules.Select(module => module.Key).ContainsCaseInsensitive(((SourceEntry)chkModules.Items[i]).Key);
                chkModules.SetItemChecked(i, isChecked);
            }
        }

        protected override CheckedListBox ListBox
        {
            get { return chkModules; }
        }

        protected override IEnumerable<SourceEntry> ListDataSource
        {
            get
            {
                var modules = Services.BuildLibrary.List(SourceType.Module).OrderBy(module => module).ToList();

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
