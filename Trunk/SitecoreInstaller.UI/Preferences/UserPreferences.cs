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
    private NavigationCtrlList _navList;

    public UserPreferences()
    {
      InitializeComponent();
      _navList = new NavigationCtrlList(this);
      //_navList.Add(new H1NavigationButton());
    }

    public void Init()
    {
      databaseSettings1.Init();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      ViewportStack.Hide(this);
    }
  }
}
