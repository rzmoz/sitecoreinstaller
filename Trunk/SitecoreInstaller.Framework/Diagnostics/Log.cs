using System;
using System.Collections.Generic;

namespace SitecoreInstaller.Framework.Diagnostics
{
    public static class Log
    {
        static Log()
        {
            ItAs = new InMemoryBufferedLog();
        }
        public static ILog ItAs { get; private set; }
    }
}
