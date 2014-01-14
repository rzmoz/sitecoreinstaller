using SitecoreInstaller.App;
using SitecoreInstaller.Domain.BuildLibrary;
using SitecoreInstaller.Framework.Sys;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SitecoreInstaller.UI.ListBoxes;

namespace SitecoreInstaller.UI.UserSelections
{


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
                var sitecores = Services.BuildLibrary.List(SourceType.Sitecore).OrderByDescending(sc => sc).ToList();
                return sitecores;
            }
        }
        private void cbxSitecore_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CrossThreadSafe(() =>
            {
                if (ListBox.Items.Count == 0)
                {
                    lblSitecore.ForeColor = Color.Red;
                    lblSitecore.Text = "You have no Sitecore versions";
                    return;
                }
                lblSitecore.ForeColor = Styles.Fonts.DarkBg.Colors.Text;
                lblSitecore.Text = string.Format("Sitecore:");
            });
        }

        protected override SourceEntry GetRelevantSourceEntry(BuildLibrarySelections buildLibrarySelections)
        {
            return buildLibrarySelections.SelectedSitecore;
        }
    }
}
