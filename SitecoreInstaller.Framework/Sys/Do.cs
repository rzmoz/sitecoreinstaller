using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using SitecoreInstaller.Framework.Diagnostics;

namespace SitecoreInstaller.Framework.Sys
{
  public class Do
  {
    private Do(Action action, Action ping, Invoke invoke = Invoke.UntilTimeout)
    {
      Action = action ?? Null;
      Ping = ping ?? Null;
      Invoke = invoke;
    }

    public static Do This(Action action)
    {
      action.Invoke();
      return new Do(action, null);
    }

    public static Do ThisOnce(Action action)
    {
      action.Invoke();
      return new Do(action, null, Invoke.Once);
    }

    /// <summary>
    /// Used for adding ping and give message, so we know something is proccessing. Can be used for outputting state we're waiting for for debugging purposes
    /// </summary>
    public Do WithPing(Action pingAction)
    {
      return new Do(Action, pingAction);
    }
    

    public bool Until(Func<bool> predicate)
    {
      return Until(predicate, TimeSpan.FromMinutes(30));
    }

    public bool Until(Func<bool> predicate, int maxTries = 100)
    {
      var tryCount = 1;
      return Until(predicate, () => tryCount <= maxTries, () => tryCount++);
    }

    public bool Until(Func<bool> predicate, TimeSpan timeout)
    {
      var stopWatch = new Stopwatch();
      stopWatch.Start();

      return Until(predicate, () => stopWatch.Elapsed < timeout);
    }

    private bool Until(Func<bool> actionPredicate, Func<bool> whilePredicate, Action loopCallBack = null)
    {
      do
      {
        if (actionPredicate.Invoke())
          return true;

        try
        {
          Ping.Invoke();
        }
        catch (Exception e)
        {
          Log.This.Debug("Ping message failed in retryer:{0}", e);
        }

        if (Invoke != Invoke.Once)
        {
          try
          {
            Action.Invoke();
          }
          catch (Exception e)
          { Log.This.Debug("Exception was thrown during invoking of action but this is ok, as we're waiting for state to change:\r\n{0}", e.ToString()); }
        }

        Task.WaitAll(Task.Delay(250));
        if (loopCallBack != null)
          loopCallBack.Invoke();
      }
      while (whilePredicate.Invoke());
      return false;
    }

    private Action Action { get; set; }
    private Action Ping { get; set; }
    private Invoke Invoke { get; set; }

    private Action Null
    {
      get { return () => { }; }
    }
  }
}
