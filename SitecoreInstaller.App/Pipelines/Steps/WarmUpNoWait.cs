namespace SitecoreInstaller.App.Pipelines.Steps
{
  using System;
  using SitecoreInstaller.Framework.Diagnostics;
  using SitecoreInstaller.Framework.Web;

  public class WarmUpNoWait : Step<PipelineEventArgs>
  {
    protected override void InnerInvoke(object sender, PipelineEventArgs args)
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
