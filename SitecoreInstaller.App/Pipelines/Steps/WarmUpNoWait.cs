using SitecoreInstaller.Domain.Website;

namespace SitecoreInstaller.App.Pipelines.Steps
{
  using System;
  using SitecoreInstaller.Framework.Diagnostics;
  using SitecoreInstaller.Framework.Web;

  public class WarmUpNoWait : Step
  {
    protected override void InnerInvoke(object sender, StepEventArgs args)
    {
      try
      {
        TheWww.CallUrlOnceNoWait(args.ProjectSettings.Iis.Url.ToUri());
      }
      catch (UriFormatException e)
      {
        Log.This.Debug(e.ToString());
      }
      
    }
  }
}
