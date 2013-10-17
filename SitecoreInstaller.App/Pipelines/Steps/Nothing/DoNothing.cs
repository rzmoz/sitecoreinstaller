using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Nothing
{
  using System.Threading;
  using System.Threading.Tasks;
  using SitecoreInstaller.Domain.Pipelines;
  using SitecoreInstaller.Framework.Diagnostics;

  public class DoNothing : Step<DoNothingEventArgs>
  {
    protected override void InnerInvoke(object sender, DoNothingEventArgs args)
    {
      Log.As.Info("Starting doing nothing...");
      

      const string loginUrl = "http://sdn.sitecore.net/sdn5/misc/loginpage.aspx";



      /*
      foreach (var index in Enumerable.Range(0, 1))
      {
        Log.As.Info("Doing nothing: {0}", index);
        Task.WaitAll(Task.Delay(100));
      }*/
    }
  }
}
