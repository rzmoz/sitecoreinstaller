using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SitecoreInstaller.UI.Forms
{
  using SitecoreInstaller.App;

  public partial class SISelectFolder : UserControl
  {
    public SISelectFolder()
    {
      InitializeComponent();
    }

    public string Title
    {
      get { return lblTitle.Text; }
      set { lblTitle.Text = value; }
    }

    public new string Text
    {
      get { return tbxFolder.Text; }
      set { tbxFolder.Text = value; }
    }

    private void btnBrowse_Click(object sender, EventArgs e)
    {
      string selectedFolder;
      if (UiServices.Dialogs.ChooseFolder(out selectedFolder, this.tbxFolder.Text))
        this.tbxFolder.Text = selectedFolder;
    }
  }
}
