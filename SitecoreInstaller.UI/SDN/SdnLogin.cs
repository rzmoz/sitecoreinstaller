using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SitecoreInstaller.UI.SDN
{
  using SitecoreInstaller.UI.Viewport;

  public partial class SdnLogin : SIUserControl
  {
    public SdnLogin()
    {
      InitializeComponent();
    }

    public void Init()
    {
      
    }

    private void btnVerify_Click(object sender, EventArgs e)
    {
      UiServices.Dialogs.Information("Hello World!");
    }
  }
}
