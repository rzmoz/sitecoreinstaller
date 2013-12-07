namespace SitecoreInstaller.App.Pipelines.Steps
{
  using System;
  using SitecoreInstaller.Framework.Diagnostics;
  using SitecoreInstaller.Framework.Web;

  public class WarmUpSite : Step<PipelineApplicationEventArgs>
  {
    protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
    {
      try
      {
        TheWww.CallUrlOnceNoWait(args.ProjectSettings.Iis.Url.ToUri());
      }
      catch (UriFormatException e)
      {
        Log.ToApp.Debug(e.ToString());
      }
    }
  }
}
