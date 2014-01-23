using CSharp.Basics.Forms.Viewport;
using SitecoreInstaller.UI.Navigation;
using SitecoreInstaller.UI.Viewport;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SitecoreInstaller.UI.Settings
{


    public partial class UserSettings : BasicsUserControl
    {
        private NavigationCtrlList _navList;

        public UserSettings()
        {
            InitializeComponent();
        }

        public override bool ProcessKeyPress(Keys keyData)
        {
            //we only activate key board shortcuts, if we're visible
            if (UiServices.ViewportStack.IsVisible(this) == false)
                return false;

            switch (keyData)
            {
                case Keys.Escape:
                    btnBack_Click(this, new EventArgs());
                    return true;
            }
            return false;
        }

        public void Init()
        {
            pnlButtons.BackColor = Styles.Navigation.Level1.BackColor;
            btnBack.Image = SettingsResources.back;
            btnBack.FlatAppearance.BorderSize = 0;

            _navList = new NavigationCtrlList(pnlButtons, btnBack.Height, toolTip1);
            _navList.Add(new Level1NavigationButton(_sqlSettings1) { Text = "Sql", Image = SettingsResources.Database, ImageActive = SettingsResources.Database_Active });
            _navList.Add(new Level1NavigationButton(mongoSettings1) { Text = "Mongo", Image = SettingsResources.Database, ImageActive = SettingsResources.Database_Active });
            _navList.Add(new Level1NavigationButton(foldersSettings1) { Text = "Folders", Image = SettingsResources.Folders, ImageActive = SettingsResources.Folders_Active });
            _navList.Add(new Level1NavigationButton(autoSetupSettings1) { Text = "Auto Setup", Image = SettingsResources.SetupWizard, ImageActive = SettingsResources.SetupWizard_Active });
            _navList.Init();
            _navList.First().Activate();

            foreach (var ctrl in _navList.Select(x => x.TargetControl).OfType<UserSettingsCtrl>())
            {
                ctrl.Init();
            }

            toolTip1.SetToolTip(btnBack, "Back");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            UiServices.ViewportStack.Hide(this);
        }
    }
}

