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

    public void Init() { }

    public override bool ProcessKeyPress(Keys keyData)
    {
      //we only activate key board shortcuts, if we're visible
      if (ViewportStack.IsVisible(this) == false)
        return false;

      switch (keyData)
      {
        case Keys.D | Keys.Control | Keys.Shift:
          ViewportStack.Show("SitecoreInstaller.UI.MainDeveloper");
          return true;
        case Keys.B | Keys.Control | Keys.Shift:
          MessageBox.Show("We're in simple", "Hello World!", MessageBoxButtons.OK, MessageBoxIcon.None);
          return true;
      }
      return false;
    }

    private void MainSimple_Resize(object sender, EventArgs e)
    {
      const int padding = 3;

      var buttonWidth = (this.Width - 2 * padding) / 3;
      var buttonHeight = (this.Height - 2 * padding) / 2;

      btnInstall.Top = padding;
      btnInstall.Left = padding;
      btnInstall.Width = buttonWidth;
      btnInstall.Height = buttonHeight;

      btnUninstall.Top = padding;
      btnUninstall.Left = padding + buttonWidth;
      btnUninstall.Width = buttonWidth;
      btnUninstall.Height = buttonHeight;
    }
  }
}
