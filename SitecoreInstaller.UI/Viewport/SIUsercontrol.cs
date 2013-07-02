namespace SitecoreInstaller.UI.Viewport
{
  using System.Windows.Forms;

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
