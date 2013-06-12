using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SitecoreInstaller.UI.Settings
{
  public partial class UserSettingsCtrl : UserControl
  {
    public UserSettingsCtrl()
    {
      InitializeComponent();
    }

    public string Label
    {
      get { return this.lblHeader.Text; }
      set { this.lblHeader.Text = value; }
    }

    public virtual void Init(){}

    protected virtual void btnSave_Click(object sender, EventArgs e)
    {
    }
  }
}
