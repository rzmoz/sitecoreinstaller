using System;
using System.IO;
using System.Linq;
using System.Net;
using SitecoreInstaller.Framework.Diagnostics;
using SitecoreInstaller.Framework.Web;

namespace SitecoreInstaller.App.Pipelines.Steps.Nothing
{
  public class DoNothingStep1 : Step<DoNothingEventArgs>
  {
    protected override void InnerInvoke(object sender, DoNothingEventArgs args)
    {
    }
  }
}
