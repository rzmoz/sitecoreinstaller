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
    using SitecoreInstaller.App.Properties;

    public partial class UrlPostfixDialog : UserSettingsDialog
    {
        public UrlPostfixDialog()
        {
            InitializeComponent();
        }

        private void UrlPostfixDialog_Load(object sender, EventArgs e)
        {
            tbxUrlPostfix.Text = UserSettings.Default.IisSitePostfix;
     
        }
        public override void BtnSaveClick()
        {
            base.BtnSaveClick();
            UserSettings.Default.IisSitePostfix = tbxUrlPostfix.Text;
            UserSettings.Default.Save();
        }
    }
}
