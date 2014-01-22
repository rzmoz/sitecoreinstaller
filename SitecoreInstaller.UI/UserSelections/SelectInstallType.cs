using System;
using System.Windows.Forms;
using CSharp.Basics.Sys;
using SitecoreInstaller.Domain;

namespace SitecoreInstaller.UI.UserSelections
{
    public partial class SelectInstallType : UserControl
    {
        public SelectInstallType()
        {
            InitializeComponent();
        }

        public void Init()
        {
            UiServices.ProjectSettings.Updated += ProjectSettings_Updated;
            Clear();
        }

        void ProjectSettings_Updated(object sender, GenericEventArgs<string> e)
        {
            switch (UiServices.ProjectSettings.InstallType)
            {
                case InstallType.Full:
                    radInstallTypeFull.Checked = true;
                    break;
                case InstallType.Client:
                    radInstallTypeClient.Checked = true;
                    break;
            }
        }

        public InstallType SelectedInstallType
        {
            get { return radInstallTypeClient.Checked ? InstallType.Client : InstallType.Full; }
        }

        public void Clear()
        {
            radInstallTypeFull.Checked = true;
        }

        private void radInstallTypeFull_CheckedChanged(object sender, EventArgs e)
        {
            UiServices.ProjectSettings.InstallType = SelectedInstallType;
        }

        private void radInstallTypeClient_CheckedChanged(object sender, EventArgs e)
        {
            UiServices.ProjectSettings.InstallType = SelectedInstallType;
        }
    }
}
