using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SitecoreInstaller.UI
{
    using System.Globalization;
    using System.Web.UI.WebControls;

    using SitecoreInstaller.App;
    using SitecoreInstaller.Domain.Database;
    using SitecoreInstaller.Framework.System;

    public partial class SelectDatabases : Form
    {
        public SelectDatabases()
        {
            InitializeComponent();
        }

        private void SelectDatabases_Load(object sender, EventArgs e)
        {
            var databases = Services.Sql.GetExistingDatabaseNames(Services.ProjectSettings.Sql).ToList();
            databases.Sort();
            clbDatabases.DataSource = databases;

            for (int i = 0; i < clbDatabases.Items.Count; i++)
            {
                var entry = clbDatabases.Items[i].ToString();
                if (entry.StartsWith(Services.ProjectSettings.ProjectName.Value + "_"))
                {
                    clbDatabases.SetItemChecked(i, true);
                    clbDatabases.SelectedIndex = i;
                }
            }
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            const string _SelectFormat = @"You have selected:

{0}
Do you want to continue?";

            var databases = string.Empty;
            foreach (var database in clbDatabases.CheckedItems)
            {
                databases += database + Consts.Newline;
            }

            if (!Services.Dialogs.UserAccept(string.Format(_SelectFormat, databases)))
                return;

            Services.ProjectSettings.DatabaseNames = clbDatabases.CheckedItems.Cast<string>().Select(name => new ConnectionStringName(name));
            Close();
        }
    }
}
