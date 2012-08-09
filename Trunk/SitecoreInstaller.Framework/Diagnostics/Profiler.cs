namespace SitecoreInstaller.Framework.Diagnostics
{
    using global::System;
    using global::System.Diagnostics;

    public class Profiler
    {
        private readonly Stopwatch _stopwatch;
        private readonly Action<object, EventArgs> _innerAction;

        public event EventHandler<ProfilerEventArgs> ActionProfiled;

        public Profiler(string taskName, Action<object, EventArgs> action)
        {
            _innerAction = action;
            TaskName = taskName;
            _stopwatch = new Stopwatch();
        }

        public void Run(object sender, EventArgs e)
        {
            _stopwatch.Reset();
            _stopwatch.Start();

            _innerAction.Invoke(sender, e);

            _stopwatch.Stop();
            if (ActionProfiled != null)
                ActionProfiled(this, new ProfilerEventArgs(TaskName, _stopwatch.Elapsed));
        }

        public string TaskName { get; private set; }
    }
}
