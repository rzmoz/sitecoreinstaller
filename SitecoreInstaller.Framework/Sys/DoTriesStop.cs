using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitecoreInstaller.Framework.Diagnostics;

namespace SitecoreInstaller.Framework.Sys
{
    public class DoTriesStop : IUntil
    {
        private int _tryCount;
        public DoTriesStop(int maxTries)
        {
            MaxTries = maxTries;
            Reset();
        }

        public int MaxTries { get; private set; }

        public void Reset()
        {
            _tryCount = 1;
        }

        public Func<bool> WhilePredicate()
        {
            return () => _tryCount < MaxTries;
        }

        public Action LoopBackAction()
        {
            return () =>
            {
                _tryCount++;
                Log.ToApp.Debug("Looping try {0}", _tryCount);
            };

        }
    }
}
