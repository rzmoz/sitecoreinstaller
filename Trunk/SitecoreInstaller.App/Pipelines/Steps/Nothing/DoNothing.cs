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
      Log.As.Info("Starting doing nothing...");

      Parallel.For(0, 10, async i => Log.As.Info("Async finished with {0}", await this.GetWait(i)));
    }

    public Task<int> GetWait(int number)
    {
      Log.As.Info("Starting async task {0}", number);

      var tcs = new TaskCompletionSource<int>();
      
      Task.Delay(1000);

      tcs.SetResult(number);

      Log.As.Info("Finishing async task {0}", number);
      return tcs.Task;
    }
  }
}
