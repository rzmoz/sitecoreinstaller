using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SitecoreInstaller.UI.Processing
{
  public partial class ProgressCtrl : UserControl
  {
    public ProgressCtrl()
    {
      InitializeComponent();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
      this.SendToBack();
      this.Hide();
    }

    private void ProgressCtrl_Load(object sender, EventArgs e)
    {

    }
  }
}
