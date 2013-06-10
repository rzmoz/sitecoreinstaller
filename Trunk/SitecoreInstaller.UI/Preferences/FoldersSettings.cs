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

  public partial class FoldersSettings : UserPreferenceCtrl
  {
    public FoldersSettings()
    {
      InitializeComponent();
    }

    public override void Init()
    {
      this.Label = "Folders settings";
      Services.UserPreferences.Updated += UserPreferences_Updated;
    }

    private void UserPreferences_Updated(object sender, GenericEventArgs<UserPreferencesConfig> e)
    {
      this.tbxBuildLibraryFolder.Text = e.Arg.LocalBuildLibrary;
      tbxProjectFolder.Text = e.Arg.ProjectsFolder;
    }
    protected override void btnSave_Click(object sender, EventArgs e)
    {
      Services.UserPreferences.Properties.LocalBuildLibrary= this.tbxBuildLibraryFolder.Text;
      Services.UserPreferences.Properties.ProjectsFolder= tbxProjectFolder.Text;
      Services.UserPreferences.Save();
    }
  }
}
