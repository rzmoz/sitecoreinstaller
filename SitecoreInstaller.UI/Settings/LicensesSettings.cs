﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SitecoreInstaller.App;
using SitecoreInstaller.Domain.BuildLibrary;

namespace SitecoreInstaller.UI.Settings
{
    public partial class LicensesSettings : UserSettingsCtrl
    {
        public LicensesSettings()
        {
            InitializeComponent();
        }

        public override void Init()
        {
            base.Init();
            selectLicense1.Init();
            SaveButton.Visible = false;
            Label = "Licenses";
            addLicenseDnDControl1.UpdateTextWithFileNamesAfterDrop = false;
            addLicenseDnDControl1.FilesAdded += addLicenseDnDControl1_FilesAdded;
            addLicenseDnDControl1.ColorHasFile = Styles.Navigation.Level1.BackColor;
        }

        void addLicenseDnDControl1_FilesAdded(object sender, CSharp.Basics.Sys.GenericEventArgs<IEnumerable<System.IO.FileInfo>> e)
        {
            addLicenseDnDControl1.Label = string.Empty;
            foreach (var licenseFile in e.Arg)
            {
                try
                {
                    Services.BuildLibrary.Add(licenseFile.FullName, SourceType.License);
                    addLicenseDnDControl1.Label += string.Format("{0} added{1}", licenseFile.FullName, Environment.NewLine + Environment.NewLine);
                }
                catch (LicenseFileException ex)
                {
                    Framework.Diagnostics.Log.ToApp.Error("Couldn't add license file: " + ex);
                    addLicenseDnDControl1.Label += string.Format("{0} seems to be invalid. See log for details{1}", licenseFile.FullName, Environment.NewLine + Environment.NewLine);
                }
            }
        }
    }
}
