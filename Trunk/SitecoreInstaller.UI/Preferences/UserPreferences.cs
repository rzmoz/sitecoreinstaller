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
  using SitecoreInstaller.UI.Navigation;
  using SitecoreInstaller.UI.Viewport;

  public partial class UserPreferences : SIUserControl
  {
    private readonly NavigationCtrlList _navList;

    public UserPreferences()
    {
      InitializeComponent();
      _navList = new NavigationCtrlList(pnlButtons);
      _navList.Add(new Level1NavigationButton(databaseSettings1) { Text = "Sql", Image = PreferencesResources.Sql, ImageSelected = PreferencesResources.Sql_Active });
      _navList.Add(new Level1NavigationButton(sourcesSettings1) { Text = "Sources", Image = PreferencesResources.Sources, ImageSelected = PreferencesResources.Sources_Active });
      _navList.Init();
      _navList.First().Activate();
      pnlButtons.BackColor = Styles.Navigation.Level1.BackColor;
    }

    public void Init()
    {
      databaseSettings1.Init();
    }
  }
}

