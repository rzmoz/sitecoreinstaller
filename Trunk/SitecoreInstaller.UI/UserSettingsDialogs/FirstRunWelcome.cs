using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SitecoreInstaller.UI.UserSettingsDialogs
{
    using SitecoreInstaller.App;
    using SitecoreInstaller.App.Properties;

    public partial class FirstRunWelcome : UserSettingsDialog
    {
        public FirstRunWelcome()
        {
            InitializeComponent();
        }
        public override void BtnSaveClick()
        {
            base.BtnSaveClick();
            UserSettings.Default.PromptForUserSettings = false;
            UserSettings.Default.Save();
            
        }
    }
}
