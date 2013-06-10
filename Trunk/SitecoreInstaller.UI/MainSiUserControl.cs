using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.UI
{
  using System.Windows.Forms;
  using SitecoreInstaller.App;
  using SitecoreInstaller.Domain.BuildLibrary;
  using SitecoreInstaller.Framework.System;
  using SitecoreInstaller.UI.Viewport;

  public class MainSIUserControl : SIUserControl
  {
    public virtual bool ProcessKeyPress(Keys keyData)
    {
      return false;
    }
  }
}
