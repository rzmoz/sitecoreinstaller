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
      this.ResizeButton(btnInstall, btnUninstall, btnOpenSite);
    }

    private void ResizeButton(params Button[] buttons)
    {
      if (buttons == null || buttons.Length == 0)
        return;

      const int padding = 40;
      const int buttonMinWidth = 120;
      var buttonWidth = (this.Width - padding) / buttons.Length - padding;
      if (buttonWidth < buttonMinWidth)
        buttonWidth = buttonMinWidth;

      var i = 1;
      foreach (var button in buttons)
      {
        button.Width = buttonWidth;
        button.Height = buttonWidth;
        button.Top = this.Height / 2 - button.Height / 2;
        button.Left = (padding * i) + button.Width * (i - 1);
        i++;
      }
    }
  }
}
