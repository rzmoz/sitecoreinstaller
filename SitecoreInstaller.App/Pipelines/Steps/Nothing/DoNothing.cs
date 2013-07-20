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

  public class DoNothing : Step
  {
    protected override void InnerInvoke(object sender, PipelineEventArgs args)
    {
      Log.This.Info("Starting doing nothing...");

      foreach (var index in Enumerable.Range(0,1))
      {
        Log.This.Info("Doing nothing: {0}", index);
        Thread.Sleep(100);
      }
    }
  }
}
