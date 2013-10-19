using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SitecoreInstaller.UI.Viewport;

namespace SitecoreInstaller.UI
{
  public partial class MainDeveloperButtons : UserControl
  {
    public MainDeveloperButtons()
    {
      InitializeComponent();
    }

    public void Init()
    {
      BackColor = Styles.Navigation.Level1.BackColor;
    }

    private void TriggerKeyboardShortcut(Keys keys)
    {
      var parentSiCtrl = Parent;
      while (parentSiCtrl is SIUserControl == false)
      {
        parentSiCtrl = parentSiCtrl.Parent;
      }
      (parentSiCtrl as SIUserControl).ProcessKeyPress(keys);
    }

    private void btnInstall_Click(object sender, EventArgs e)
    {
      TriggerKeyboardShortcut(Keys.B | Keys.Control | Keys.Shift);
    }

    private void btnUninstall_Click(object sender, EventArgs e)
    {
      TriggerKeyboardShortcut(Keys.U | Keys.Control | Keys.Shift);
    }

    private void btnReinstall_Click(object sender, EventArgs e)
    {
      TriggerKeyboardShortcut(Keys.R | Keys.Control | Keys.Shift);
    }

    private void btnArchive_Click(object sender, EventArgs e)
    {
      TriggerKeyboardShortcut(Keys.A | Keys.Control | Keys.Shift);
    }

    private void btnOpenSitecore_Click(object sender, EventArgs e)
    {
      TriggerKeyboardShortcut(Keys.O | Keys.Control | Keys.Shift);
    }

    private void btnOpenWebsite_Click(object sender, EventArgs e)
    {
      TriggerKeyboardShortcut(Keys.O | Keys.Control);
    }

    private void siMainDevActionButton1_Click(object sender, EventArgs e)
    {
      TriggerKeyboardShortcut(Keys.O | Keys.Control | Keys.Alt);
    }
  }
}
