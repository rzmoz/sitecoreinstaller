using System;

namespace SitecoreInstaller.UI.Settings
{
  using App;
  using App.Pipelines;
  using Framework.Sys;

  public partial class DatabaseSettings : UserSettingsCtrl
  {
    public DatabaseSettings()
    {
      InitializeComponent();
    }

    public override void Init()
    {
      Services.UserPreferences.Updated += UserPreferences_Updated;
      Label = "Database Settings";
    }

    private void UserPreferences_Updated(object sender, GenericEventArgs<UserPreferencesConfig> e)
    {
      tbxInstanceName.Text = e.Arg.SqlInstanceName;
      tbxLogin.Text = e.Arg.SqlLogin;
      tbxPassword.Text = e.Arg.SqlPassword;

      tbxMongoEndpoint.Text = e.Arg.MongoEndpoint;
      tbxMongoPort.Text = e.Arg.MongoPort.ToString();
      tbxMongoUsername.Text = e.Arg.MongoUsername;
      tbxMongoPassword.Text = e.Arg.MongoPassword;
    }

    protected override void btnSave_Click(object sender, EventArgs e)
    {
      Services.UserPreferences.Properties.SqlInstanceName = tbxInstanceName.Text;
      Services.UserPreferences.Properties.SqlLogin = tbxLogin.Text;
      Services.UserPreferences.Properties.SqlPassword = tbxPassword.Text;

      Services.UserPreferences.Properties.MongoEndpoint = tbxMongoEndpoint.Text;
      Services.UserPreferences.Properties.MongoPort = Int32.Parse(tbxMongoPort.Text);
      Services.UserPreferences.Properties.MongoUsername = tbxMongoUsername.Text;
      Services.UserPreferences.Properties.MongoPassword = tbxMongoPassword.Text;

      Services.UserPreferences.Save();
    }

    private void btnTestSqlSettings_Click(object sender, EventArgs e)
    {
      btnSave_Click(sender, e);
      Services.Pipelines.Run<TestSqlSettingsPipeline, PipelineEventArgs>(UiServices.ProjectSettings);
    }

    private void btnTestMongoSettings_Click(object sender, EventArgs e)
    {
      btnSave_Click(sender, e);
      Services.Pipelines.Run<TestMongoSettingsPipeline, PipelineEventArgs>(UiServices.ProjectSettings);
    }
  }
}
