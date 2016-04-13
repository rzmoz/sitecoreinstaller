using System;
using SitecoreInstaller.Framework.Diagnostics;
using SitecoreInstaller.Framework.Web;

namespace SitecoreInstaller.App.Pipelines.Steps
{
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
                Log.As.Debug(e.ToString());
            }
        }
    }
}
