using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SitecoreInstaller.UI
{
  using SitecoreInstaller.App;
  using SitecoreInstaller.UI.Navigation;

  public partial class MainCtrl : UserControl
  {
    public MainCtrl()
    {
      InitializeComponent(); 
    }

    private void MainCtrl_Load(object sender, EventArgs e)
    {
      
      Services.Init();

      selectProjectName1.Init();
      selectSitecore1.Init();
      selectLicense1.Init();
      selectModules1.Init();
    }
  }
}
