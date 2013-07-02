using System;

namespace SitecoreInstaller.App.Pipelines.Steps.Nothing
{
  using System.Threading;
  using SitecoreInstaller.Domain.BuildLibrary;
  using SitecoreInstaller.Framework.Diagnostics;

  public class DoNothingForAWhile : Step
  {
    protected override void InnerInvoke(object sender, StepEventArgs args)
    {
      Log.This.Info(typeof(SourceManifest).Name);
      for (var i = 0; i < 10; i++)
        Log.This.Info("Logging...");
      Log.This.Info("Pinging the world!...");
      Thread.Sleep(1000);
      Log.This.Debug("Debugging the world!...");
      Thread.Sleep(1000);
      Log.This.Warning("Warning the world!...");
      Thread.Sleep(1000);
      Log.This.Error("Erroring the world! {0}", Environment.StackTrace);
      Thread.Sleep(1000);
    }
  }
}
