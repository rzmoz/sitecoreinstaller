using System;
using System.Collections.Generic;

namespace SitecoreInstaller.Framework.Diagnostics
{
    public static class Log
    {
        static Log()
        {
            ToApp = new InMemoryBufferedLog();
            ToDebugFile = new SimpleBufferedFileLog();
        }
        public static ILog ToApp { get; private set; }
        public static ILog ToDebugFile { get; private set; }
    }
}
