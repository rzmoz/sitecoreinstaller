using System.Windows.Forms;
namespace SitecoreInstaller.UI.Viewport
{
    public class SIUserControl : UserControl
    {
        public SIUserControl()
        {
            BlocksView = true;
        }

        public bool BlocksView { get; protected set; }

        public virtual bool ProcessKeyPress(Keys keyData)
        {
            return false;
        }

        public virtual void OnShow()
        {
        }
    }
}
