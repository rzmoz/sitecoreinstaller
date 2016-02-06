using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharp.Basics.Sys;
using SitecoreInstaller.App;
using SitecoreInstaller.App.Pipelines;
using SitecoreInstaller.Framework.Sys;

namespace SitecoreInstaller.UI.Settings
{
    public partial class MongoSettings : UserSettingsCtrl
    {
        public MongoSettings()
        {
            InitializeComponent();
        }
        public override void Init()
        {
            Services.UserPreferences.Updated += UserPreferences_Updated;
            Label = "Mongo Settings";
        }
        private void UserPreferences_Updated(object sender, GenericEventArgs<UserPreferencesConfig> e)
        {
            tbxMongoEndpoint.Text = e.Arg.MongoEndpoint;
            tbxMongoPort.Text = e.Arg.MongoPort.ToString();
            tbxMongoUsername.Text = e.Arg.MongoUsername;
            tbxMongoPassword.Text = e.Arg.MongoPassword;
        }
        protected override void btnSave_Click(object sender, EventArgs e)
        {
            Services.UserPreferences.Properties.MongoEndpoint = tbxMongoEndpoint.Text;
            Services.UserPreferences.Properties.MongoPort = Int32.Parse(tbxMongoPort.Text.Replace(" ", ""));
            Services.UserPreferences.Properties.MongoUsername = tbxMongoUsername.Text;
            Services.UserPreferences.Properties.MongoPassword = tbxMongoPassword.Text;

            Services.UserPreferences.Save();
        }

        private async void btnTestMongoSettings_Click(object sender, EventArgs e)
        {
            btnSave_Click(sender, e);
            await Services.Pipelines.RunAsync<TestMongoSettingsPipeline, PipelineApplicationEventArgs>(UiServices.ProjectSettings);
        }
    }
}
