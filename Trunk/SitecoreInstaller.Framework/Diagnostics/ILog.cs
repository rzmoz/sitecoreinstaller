﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Framework.Diagnostics
{
    using SitecoreInstaller.Framework.System;

    public interface ILog
    {
        event EventHandler<GenericEventArgs<LogEntry>> EntryLogged;
        event EventHandler LogCleared;
        void Flush();
        void Clear();

        IEnumerable<LogEntry> Entries { get; }

        void Debug(string message, params object[] parameters);
        void Info(string message, params object[] parameters);
        void Warning(string message, params object[] parameters);
        void Error(string message, params object[] parameters);
        void Profile(string taskName, TimeSpan timeElapsed);
    }
}
