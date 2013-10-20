using System.Linq;
using System.Net;
using SitecoreInstaller.Framework.Diagnostics;

namespace SitecoreInstaller.App.Pipelines.Steps.Nothing
{
  public class DoNothing : Step<DoNothingEventArgs>
  {
    protected override void InnerInvoke(object sender, DoNothingEventArgs args)
    {
      Log.This.Info("Starting doing nothing...");
    }
  }
}
