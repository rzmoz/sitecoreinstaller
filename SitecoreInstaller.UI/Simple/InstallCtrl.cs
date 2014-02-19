using System;
using System.Linq;
using System.Windows.Forms;
using CSharp.Basics.Forms.Viewport;
using CSharp.Basics.Sys;
using SitecoreInstaller.App;
using SitecoreInstaller.App.Pipelines;
using SitecoreInstaller.Domain.BuildLibrary;
using SitecoreInstaller.Domain.Projects;
using SitecoreInstaller.Framework.Sys;

namespace SitecoreInstaller.UI.Simple
{
    public partial class InstallCtrl : BasicsUserControl
    {
        public InstallCtrl()
        {
            InitializeComponent();
        }

        public void Init()
        {
            selectSitecore1.Init();
            selectLicense1.Init();
        }

        public override void OnShow()
        {
            tbxProjectName.Text = string.Empty;
            tbxProjectName.Focus();

            selectSitecore1.BuildLibrarySelectionsUpdated(this, new GenericEventArgs<ProjectSettings>(new ProjectSettings()));
            selectLicense1.BuildLibrarySelectionsUpdated(this, new GenericEventArgs<ProjectSettings>(new ProjectSettings()));
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
                case Keys.B | Keys.Control | Keys.Shift:
                    btnInstall_Click(this, new EventArgs());
                    return true;
            }
            return false;
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            UiServices.ViewportStack.Hide(this);
        }

        private async void btnInstall_Click(object sender, EventArgs e)
        {
            var projectName = tbxProjectName.Text;

            if (string.IsNullOrEmpty(tbxProjectName.Text))
            {
                UiServices.Dialogs.Information("Please enter project name");
                return;
            }

            if (Services.Projects.GetExistingProjects().Any(p => p.Name.ToLower() == projectName.ToLower()))
            {
                UiServices.Dialogs.Information("Project '{0}' already exists.", projectName);
                return;
            }

            UiServices.ProjectSettings.ProjectName = tbxProjectName.Text;
            UiServices.ProjectSettings.BuildLibrarySelections.SelectedSitecore = this.selectSitecore1.SelectedItem;
            UiServices.ProjectSettings.BuildLibrarySelections.SelectedLicense = this.selectLicense1.SelectedItem;
            await Services.Pipelines.RunAsync<InstallPipeline, PipelineApplicationEventArgs>(UiServices.ProjectSettings);
            UiServices.ViewportStack.Hide(this);
        }
    }
}
