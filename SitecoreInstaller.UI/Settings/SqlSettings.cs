using System;
using CSharp.Basics.Forms;
using CSharp.Basics.Sys;

namespace SitecoreInstaller.UI.Settings
{
    using App;
    using App.Pipelines;
    using Framework.Sys;

    public partial class SqlSettings : UserSettingsCtrl
    {
        public SqlSettings()
        {
            InitializeComponent();
        }

        public override void Init()
        {
            Services.UserPreferences.Updated += UserPreferences_Updated;
            Label = "Sql Settings";
        }

        private void UserPreferences_Updated(object sender, GenericEventArgs<UserPreferencesConfig> e)
        {
            this.CrossThreadSafe(() =>
            {
                tbxInstanceName.Text = e.Arg.SqlInstanceName;
                tbxLogin.Text = e.Arg.SqlLogin;
                tbxPassword.Text = e.Arg.SqlPassword;
            });
        }

        protected override void btnSave_Click(object sender, EventArgs e)
        {
            Services.UserPreferences.Properties.SqlInstanceName = tbxInstanceName.Text;
            Services.UserPreferences.Properties.SqlLogin = tbxLogin.Text;
            Services.UserPreferences.Properties.SqlPassword = tbxPassword.Text;

            Services.UserPreferences.Save();
        }

        private async void btnTestSqlSettings_Click(object sender, EventArgs e)
        {
            btnSave_Click(sender, e);
            await Services.Pipelines.RunAsync<TestSqlSettingsPipeline, PipelineApplicationEventArgs>(UiServices.ProjectSettings);
        }
    }
}
