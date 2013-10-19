using System.Linq;
using System.Net;
using System.Windows.Controls;
using mshtml;

namespace SitecoreInstaller.App.Pipelines.Steps.Nothing
{
  using SitecoreInstaller.Framework.Diagnostics;

  public class DoNothing : Step<DoNothingEventArgs>
  {
    
    protected override void InnerInvoke(object sender, DoNothingEventArgs args)
    {
      Log.This.Info("Starting doing nothing...");
    }

  }
}
