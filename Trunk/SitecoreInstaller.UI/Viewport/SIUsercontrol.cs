namespace SitecoreInstaller.UI.Viewport
{
  using System.Windows.Forms;

  public abstract class SIUserControl : UserControl
  {
    public abstract bool BlocksView { get; }
  }
}
