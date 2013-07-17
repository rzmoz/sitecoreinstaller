using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SitecoreInstaller
{
  using SitecoreInstaller.App;
  using SitecoreInstaller.UI;

  public partial class frmSplashScreen : Form
  {
    public frmSplashScreen()
    {
      InitializeComponent();
      
    }

    protected async override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      this.BackColor = Styles.Controls.BackColor;
      this.CenterToScreen();
      await Services.InitAsync();
      //Task.WaitAll(Task.Delay(5000));
      var frmMain = new FrmMain();
      frmMain.Closed += (sender, args) => this.Close();
      this.Hide();
      frmMain.Show();
    }
  }
}
