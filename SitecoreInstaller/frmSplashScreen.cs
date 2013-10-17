using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SitecoreInstaller.App;
using SitecoreInstaller.Framework.Diagnostics;
using SitecoreInstaller.Framework.Sys;
using SitecoreInstaller.UI;

namespace SitecoreInstaller
{
  public partial class FrmSplashScreen : Form
  {
    public FrmSplashScreen()
    {
      InitializeComponent();
    }

    protected async override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      BackColor = Styles.Controls.BackColor;
      CenterToScreen();
      timer1.Start();//start timer as one of the first tasks to start animation!
      Log.As.EntryLogged += This_EntryLogged;

      await Services.LoadUserPreferencesAsync();

      Task wizardFinishedTask = null;
      /* if (Services.UserPreferences.Properties.PromptForUserSettings)
       {
           wizardFinishedTask = stepWizard1.StartWizard();
           Services.UserPreferences.Properties.PromptForUserSettings = false;
           Services.UserPreferences.Save();
       }*/

      await Services.InitAsync();

      if (wizardFinishedTask != null)
        await wizardFinishedTask;

      Log.As.EntryLogged -= This_EntryLogged;

      var frmMain = new FrmMain();
      frmMain.Init();
      frmMain.Closed += (sender, args) => Close();
      Hide();
      frmMain.Show();
    }

    void This_EntryLogged(object sender, GenericEventArgs<LogEntry> e)
    {
      this.CrossThreadSafe(() =>
      {
        lblLog.Text = e.Arg.Message;
      });
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      //if we reached right side, then we go back
      var rightProximity = this.Width - picLogo.Right;
      var leftProximity = picLogo.Left;

      if (rightProximity < 50 || leftProximity < 50)
        movePicOffSet = movePicOffSet * -1;

      picLogo.Left += movePicOffSet;
    }

    private int movePicOffSet = 3;
  }
}
