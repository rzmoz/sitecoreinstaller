namespace SitecoreInstaller.UI
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;

    using SitecoreInstaller.App;
    using SitecoreInstaller.Domain.BuildLibrary;
    using SitecoreInstaller.UI.ListBoxes;
    using SitecoreInstaller.UI.Properties;

    public partial class SelectModules : SourceEntryCheckedListBox
    {
        public SelectModules()
        {
            InitializeComponent();
        }

        private void SelectModules_Load(object sender, System.EventArgs e)
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
