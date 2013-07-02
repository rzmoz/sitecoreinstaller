namespace SitecoreInstaller.Framework.Diagnostics
{
    using global::System;
    using global::System.Diagnostics;

    public static class Profiler
    {
        public static TimeSpan This(Action<object, EventArgs> action, object sender, EventArgs args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Reset();
            stopwatch.Start();

            action.Invoke(sender, args);

            stopwatch.Stop();
            return stopwatch.Elapsed;
        }
    }
}
