using System;
using System.Collections.Generic;

namespace SitecoreInstaller.Framework.Diagnostics
{
    public static class Log
    {
        static Log()
        {
            It = new InMemoryBufferedLog();
        }
        public static ILog It { get; private set; }
    }
}
