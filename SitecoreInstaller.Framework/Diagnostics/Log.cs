using System;
using System.Collections.Generic;

namespace SitecoreInstaller.Framework.Diagnostics
{
    public static class Log
    {
        static Log()
        {
            As = new InMemoryBufferedLog();
        }

        public static ILog As { get; private set; }
    }
}
