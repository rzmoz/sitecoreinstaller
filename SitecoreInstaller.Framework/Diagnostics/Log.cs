using System;
using System.Collections.Generic;

namespace SitecoreInstaller.Framework.Diagnostics
{
    public static class Log
    {
        static Log()
        {
            This = new InMemoryBufferedLog();
        }
        public static ILog This { get; private set; }
    }
}
