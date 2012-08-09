using System;

namespace SitecoreInstaller.Domain.Pipelines
{
    using SitecoreInstaller.Framework.Diagnostics;

    public class ProfiledStep : Step
    {
        public ProfiledStep(string text, int order, Action<object, EventArgs> action)
            : base(text, order, action)
        {
            Profiler = new Profiler(text, action);
            Action = Profiler.Run;
        }
        
        public override string ActionName { get { return Profiler.TaskName; } }
        public Profiler Profiler { get; private set; }
    }
}
