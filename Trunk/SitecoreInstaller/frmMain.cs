using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SitecoreInstaller
{
  using SitecoreInstaller.App;
  using SitecoreInstaller.App.Pipelines;

  public partial class FrmMain : Form
  {
    public FrmMain()
    {
      InitializeComponent();
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (mainCtrl1.ProcessKeyPress(keyData))
        return true;
      return base.ProcessCmdKey(ref msg, keyData);
    }
  }
}
