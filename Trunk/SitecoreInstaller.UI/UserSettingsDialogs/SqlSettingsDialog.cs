using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SitecoreInstaller.UI.UserSettingsDialogs
{
    using SitecoreInstaller.App;
    using SitecoreInstaller.App.Properties;
    using SitecoreInstaller.Domain.Database;

    public partial class SqlSettingsDialog : UserSettingsDialog
    {
        public SqlSettingsDialog()
        {
            InitializeComponent();
        }

        public override void Init()
        {
            base.Init();
            tbxSqlInstanceName.Focus();
        }

        private void SqlSettingsDialog_Load(object sender, EventArgs e)
        {
            tbxSqlInstanceName.Text = UserSettings.Default.SqlInstanceName;
            tbxSqlUserId.Text = UserSettings.Default.SqlLogin;
            tbxSqlPassword.Text = UserSettings.Default.SqlPassword;
        }

        public override void BtnSaveClick()
        {
            base.BtnSaveClick();
            UserSettings.Default.SqlInstanceName = tbxSqlInstanceName.Text;
            UserSettings.Default.SqlLogin = tbxSqlUserId.Text;
            UserSettings.Default.SqlPassword = tbxSqlPassword.Text;
            UserSettings.Default.Save();
        }

        public void btnTestSql_Click(object sender, EventArgs e)
        {
            var sqlSettings = new SqlSettings
            {
                InstanceName = tbxSqlInstanceName.Text,
                Login = tbxSqlUserId.Text,
                Password = tbxSqlPassword.Text
            };
            Services.PipelineWorker.RunPipeline(Services.Pipelines.GetSqlSettingsTest(sqlSettings));
        }
    }
}
