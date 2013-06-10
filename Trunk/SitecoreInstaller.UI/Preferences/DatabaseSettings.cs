﻿using System;

namespace SitecoreInstaller.UI.Preferences
{
  using SitecoreInstaller.App;
  using SitecoreInstaller.App.Pipelines;
  using SitecoreInstaller.Framework.System;

  public partial class DatabaseSettings : UserPreferenceCtrl
  {
    public DatabaseSettings()
    {
      InitializeComponent();
      this.Label = "Sql Settings";
    }

    public void Init()
    {
      Services.UserPreferences.Updated += UserPreferences_Updated;
      Services.UserPreferences.Load();
    }

    private void UserPreferences_Updated(object sender, GenericEventArgs<UserPreferencesConfig> e)
    {
      tbxInstanceName.Text = e.Arg.SqlInstanceName;
      tbxLogin.Text = e.Arg.SqlLogin;
      tbxPassword.Text = e.Arg.SqlPassword;
    }

    protected override void btnSave_Click(object sender, EventArgs e)
    {
      Services.UserPreferences.Properties.SqlInstanceName = tbxInstanceName.Text;
      Services.UserPreferences.Properties.SqlLogin = tbxLogin.Text;
      Services.UserPreferences.Properties.SqlPassword = tbxPassword.Text;
      Services.UserPreferences.Save();
    }

    private void siButton1_Click(object sender, EventArgs e)
    {
      btnSave_Click(sender, e);
      Services.Pipelines.Run<TestSqlSettingsPipeline>();
    }
  }
}
