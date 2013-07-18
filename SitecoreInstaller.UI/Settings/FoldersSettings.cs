using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SitecoreInstaller.UI.Settings
{
  using SitecoreInstaller.App;
  using SitecoreInstaller.Framework.Sys;

  public partial class FoldersSettings : UserSettingsCtrl
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
      fldBuildLibraryFolder.Text = e.Arg.LocalBuildLibrary;
      fldProjectfolder.Text = e.Arg.ProjectsFolder;
    }
    protected override void btnSave_Click(object sender, EventArgs e)
    {
      Services.UserPreferences.Properties.LocalBuildLibrary = fldBuildLibraryFolder.Text;
      Services.UserPreferences.Properties.ProjectsFolder = fldProjectfolder.Text;
      Services.UserPreferences.Save();
    }
  }
}
