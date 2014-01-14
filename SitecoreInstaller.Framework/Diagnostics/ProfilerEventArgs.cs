using System;

namespace SitecoreInstaller.Framework.Diagnostics
{
    public class ProfilerEventArgs : EventArgs
    {
        public ProfilerEventArgs(string taskName, TimeSpan elapsed)
        {
            TaskName = taskName;
            Elapsed = elapsed;
        }

        public string TaskName { get; private set; }
        public TimeSpan Elapsed { get; private set; }
    }
}
