using System.Linq;
using System.Net;
using SitecoreInstaller.Framework.Diagnostics;

namespace SitecoreInstaller.App.Pipelines.Steps.Nothing
{
  public class DoNothingStep1 : Step<DoNothingEventArgs>
  {
    protected override void InnerInvoke(object sender, DoNothingEventArgs args)
    {
      Log.This.Info("Set abort pipeline to true");
      args.AbortPipeline = true;
      args.AbortReason = "To test if abort works";
    }
  }
}
