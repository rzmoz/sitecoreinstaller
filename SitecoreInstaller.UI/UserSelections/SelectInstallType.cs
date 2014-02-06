using System;
using System.Windows.Forms;
using CSharp.Basics.Sys;
using SitecoreInstaller.Domain;

namespace SitecoreInstaller.UI.UserSelections
{
    public partial class SelectInstallType : UserControl
    {
        public SelectInstallType()
        {
            InitializeComponent();
        }

        public void Init()
        {
            UiServices.ProjectSettings.Updated += ProjectSettings_Updated;
            Clear();
        }

        void ProjectSettings_Updated(object sender, GenericEventArgs<string> e)
        {
            switch (UiServices.ProjectSettings.Sql.InstallType)
            {
                case DbInstallType.Local:
                    radSqlLocal.Checked = true;
                    break;
                case DbInstallType.Client:
                    radSqlClient.Checked = true;
                    break;
            }
            switch (UiServices.ProjectSettings.Mongo.InstallType)
            {
                case DbInstallType.Local:
                    radMongoLocal.Checked = true;
                    break;
                case DbInstallType.Client:
                    radMongoClient.Checked = true;
                    break;
            }
        }

        public DbInstallType SqlInstallType
        {
            get { return radSqlClient.Checked ? DbInstallType.Client : DbInstallType.Local; }
        }

        public DbInstallType MongoInstallType
        {
            get { return radMongoClient.Checked ? DbInstallType.Client : DbInstallType.Local; }
        }

        public void Clear()
        {
            radSqlLocal.Checked = true;
            radMongoLocal.Checked = true;
        }

        private void radMongoClient_CheckedChanged(object sender, EventArgs e)
        {
            UiServices.ProjectSettings.Mongo.InstallType = MongoInstallType;
        }

        private void radMongoLocal_CheckedChanged(object sender, EventArgs e)
        {
            UiServices.ProjectSettings.Mongo.InstallType = MongoInstallType;
        }

        private void radSqlClient_CheckedChanged(object sender, EventArgs e)
        {
            UiServices.ProjectSettings.Sql.InstallType = SqlInstallType;
        }

        private void radSqlLocal_CheckedChanged(object sender, EventArgs e)
        {
            UiServices.ProjectSettings.Sql.InstallType = SqlInstallType;
        }
    }
}
