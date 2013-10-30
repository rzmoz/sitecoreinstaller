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
      toolTip1.SetToolTip(btnInstall, "CTRL + SHIFT + B");
      toolTip1.SetToolTip(btnUninstall, "CTRL + SHIFT + U");
      toolTip1.SetToolTip(btnReinstall, "CTRL + SHIFT + R");
      toolTip1.SetToolTip(btnArchive, "CTRL + SHIFT + A");
      btnArchive.DrawBottomDivider = true;
      
      toolTip1.SetToolTip(btnOpenSitecore, "CTRL + SHIFT + O");
      toolTip1.SetToolTip(btnOpenWebsite, "CTRL + O");
      toolTip1.SetToolTip(btnOpenProjectFolder, "CTRL + ALT + O");
      btnOpenProjectFolder.DrawBottomDivider = true;
      toolTip1.SetToolTip(btnPublishSite, "CTRL + SHIFT + P");
      btnPublishSite.DrawBottomDivider = true;
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

    private void btnOpenProjectFolder_Click(object sender, EventArgs e)
    {
      TriggerKeyboardShortcut(Keys.O | Keys.Control | Keys.Alt);
    }

    private void btnPublishSite_Click(object sender, EventArgs e)
    {
      TriggerKeyboardShortcut(Keys.P | Keys.Control | Keys.Shift);
    }
  }
}
