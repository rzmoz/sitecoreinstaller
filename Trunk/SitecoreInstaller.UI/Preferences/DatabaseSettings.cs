using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SitecoreInstaller.UI.Preferences
{
  using SitecoreInstaller.App;
  using SitecoreInstaller.Framework.System;

  public partial class DatabaseSettings : UserControl
  {
    public DatabaseSettings()
    {
      InitializeComponent();
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

    private void btnSave_Click(object sender, EventArgs e)
    {
      Services.UserPreferences.Properties.SqlInstanceName = tbxInstanceName.Text;
      Services.UserPreferences.Properties.SqlLogin = tbxLogin.Text;
      Services.UserPreferences.Properties.SqlPassword = tbxPassword.Text;
      Services.UserPreferences.Save();
    }
  }
}
