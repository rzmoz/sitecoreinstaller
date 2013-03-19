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
    protected override void InnerInvoke(object sender, StepEventArgs args)
    {
      Log.This.Info("Starting doing nothing...");

      //Parallel.For(0, 10, async i => Log.This.Info("Async finished with {0}", await this.GetWait(i)));

      foreach (var index in Enumerable.Range(0,1))
      {
        Log.This.Info("Doing nothing: {0}", index);
        Thread.Sleep(1000);
      }
    }

    public Task<int> GetWait(int number)
    {
      Log.This.Info("Starting async task {0}", number);

      var tcs = new TaskCompletionSource<int>();

      Task.Delay(1000);

      tcs.SetResult(number);

      Log.This.Info("Finishing async task {0}", number);
      return tcs.Task;
    }
  }
}
