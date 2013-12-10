using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitecoreInstaller.Framework.Diagnostics;

namespace SitecoreInstaller.Framework.Sys
{
    public class DoTimespanStop : IUntil
    {
        private readonly TimeSpan _timeout;
        private readonly Stopwatch _stopWatch;

        public DoTimespanStop(TimeSpan timeout)
        {
            _timeout = timeout;
            _stopWatch = new Stopwatch();
            Reset();
        }

        public void Reset()
        {
            _stopWatch.Restart();
        }

        public Func<bool> WhilePredicate()
        {
            return () => _stopWatch.Elapsed < _timeout;
        }

        public Action LoopBackAction()
        {
            return () => Log.ToApp.Debug("Loop time elapsed: {0}", _stopWatch.Elapsed);
        }
    }
}
