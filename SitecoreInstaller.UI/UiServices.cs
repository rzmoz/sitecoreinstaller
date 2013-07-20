using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.UI
{
  using SitecoreInstaller.App;

  public static class UiServices
  {
    static UiServices()
    {
      ProjectSettings = new ProjectSettings();
    }

    public static ProjectSettings ProjectSettings { get; private set; }
  }
}
