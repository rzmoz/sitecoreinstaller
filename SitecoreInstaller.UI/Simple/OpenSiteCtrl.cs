using System;
using System.Windows.Forms;
using SitecoreInstaller.App;
using SitecoreInstaller.UI.Viewport;

namespace SitecoreInstaller.UI.Simple
{
    public partial class OpenSiteCtrl : SIUserControl
    {
        public OpenSiteCtrl()
        {
            InitializeComponent();
        }

        public void Init()
        {
            selectProjectName1.DropDownStyle = ComboBoxStyle.DropDownList;
            selectProjectName1.Init();
        }

        public override void OnShow()
        {
            base.OnShow();
            selectProjectName1.UpdateList();
            selectProjectName1.Focus();
        }


        public override bool ProcessKeyPress(Keys keyData)
        {
            //we only activate key board shortcuts, if we're visible
            if (ViewportStack.IsVisible(this) == false)
                return false;

            switch (keyData)
            {
                case Keys.Escape:
                    this.btnBack_Click(this, new EventArgs());
                    return true;
                case Keys.O | Keys.Control:
                    this.btnOpenSite_Click(this, new EventArgs());
                    return true;
            }
            return false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ViewportStack.Hide(this);
        }

        private void btnOpenSite_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectProjectName1.ProjectName))
            {
                UiServices.Dialogs.Information("Please select a project");
                return;
            }

            Services.Website.OpenFrontend(UiServices.ProjectSettings.Iis.Url);
        }
    }
}
