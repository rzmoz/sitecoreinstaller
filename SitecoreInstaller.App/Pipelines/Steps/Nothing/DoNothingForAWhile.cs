using System;

namespace SitecoreInstaller.App.Pipelines.Steps.Nothing
{
  using System.Threading;
  using System.Threading.Tasks;
  using SitecoreInstaller.Domain.BuildLibrary;
  using SitecoreInstaller.Framework.Diagnostics;

  public class DoNothingForAWhile : Step<DoNothingEventArgs>
  {
    protected override void InnerInvoke(object sender, DoNothingEventArgs args)
    {
     /*
      Log.As.Info(typeof(SourceManifest).Name);
      for (var i = 0; i < 10; i++)
        Log.As.Info("Logging...");
      Log.As.Info("Pinging the world and wait for {0} ms!...", args.Wait);
      Task.WaitAll(Task.Delay(args.Wait));
      Log.As.Debug("Debugging the world and wait for {0} ms!...", args.Wait);
      Task.WaitAll(Task.Delay(args.Wait));
      Log.As.Warning("Warning the world and wait for {0} ms!...", args.Wait);
      Task.WaitAll(Task.Delay(args.Wait));
      Log.As.Error("Erroring the world and wait for {0} ms! {1}", args.Wait, Environment.StackTrace);
      Task.WaitAll(Task.Delay(args.Wait));
      * */
    }
  }
}
