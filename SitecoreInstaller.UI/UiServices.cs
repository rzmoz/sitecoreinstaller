using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitecoreInstaller.App;
using SitecoreInstaller.Domain.Pipelines;
using SitecoreInstaller.UI.Viewport;

namespace SitecoreInstaller.UI
{
  public static class UiServices
  {
    static UiServices()
    {
      ProjectSettings = new ProjectSettings();
      Dialogs = new UserDialogs();
    }

    public static ProjectSettings ProjectSettings { get; private set; }
    public static UserDialogs Dialogs { get; private set; }
  }
}
