using System;
using System.Windows.Forms;
using CSharp.Basics.Forms.Viewport;
using SitecoreInstaller.App;
using SitecoreInstaller.App.Pipelines;

namespace SitecoreInstaller.UI.Simple
{
    public partial class UninstallCtrl : BasicsUserControl
    {
        public UninstallCtrl()
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
            if (UiServices.ViewportStack.IsVisible(this) == false)
                return false;

            switch (keyData)
            {
                case Keys.Escape:
                    this.btnBack_Click(this, new EventArgs());
                    return true;
                case Keys.U | Keys.Control | Keys.Shift:
                    this.btnUninstall_Click(this, new EventArgs());
                    return true;
            }
            return false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            UiServices.ViewportStack.Hide(this);
        }

        private async void btnUninstall_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectProjectName1.ProjectName))
            {
                UiServices.Dialogs.Information("Please select a project");
                return;
            }
            await Services.Pipelines.RunAsync<UninstallPipeline, CleanupEventArgs>(UiServices.ProjectSettings);
            UiServices.ViewportStack.Hide(this);
        }
    }
}
