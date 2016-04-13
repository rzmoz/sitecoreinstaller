using System.Windows.Forms;

namespace SitecoreInstaller.UI.AutoSetup
{
    public abstract class StepWizardStep : UserControl
    {
        public abstract void Save();
    }
}
