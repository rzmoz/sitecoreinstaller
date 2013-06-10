using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SitecoreInstaller.UI
{
  using SitecoreInstaller.App;
  using SitecoreInstaller.UI.Viewport;

  public partial class MainSimple : MainSIUserControl
  {
    public MainSimple()
    {
      InitializeComponent();
    }

    public void Init(){}

    public override bool ProcessKeyPress(Keys keyData)
    {
      //we only activate key board shortcuts, if we're visible
      if (ViewportStack.IsVisible(this) == false)
        return false;

      switch (keyData)
      {
        case Keys.B | Keys.Control | Keys.Shift:
          MessageBox.Show("We're in simple", "Hello World!", MessageBoxButtons.OK, MessageBoxIcon.None);
          return true;
      }
      return false;
    }
  }
}
