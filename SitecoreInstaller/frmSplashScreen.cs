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
  using SitecoreInstaller.UI.Viewport;

  public partial class FrmSplashScreen : Form
  {
    public FrmSplashScreen()
    {
      InitializeComponent();
    }

    protected async override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      this.BackColor = Styles.Controls.BackColor;
      this.CenterToScreen();
      timer1.Start();//start timer as one of the first tasks to start animation!
      
      await Services.InitAsync();
      var frmMain = new FrmMain();
      frmMain.Closed += (sender, args) => this.Close();
      this.Hide();
      frmMain.Show();
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      //if we reached right side, then we go back
      var rightProximity = this.Width - picLogo.Right;
      var leftProximity = picLogo.Left;

      if (rightProximity < 50 || leftProximity < 50)
        this.movePicOffSet = movePicOffSet * -1;
      
      picLogo.Left += movePicOffSet;
    }

    private int movePicOffSet = 3;
  }
}
