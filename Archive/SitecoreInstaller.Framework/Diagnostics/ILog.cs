using System;
using System.Collections.Generic;
using CSharp.Basics.Sys;

namespace SitecoreInstaller.Framework.Diagnostics
{
    public interface ILog
    {
        event EventHandler<GenericEventArgs<LogEntry>> EntryLogged;
        event EventHandler LogCleared;
        void Flush();
        void Reset();

        IEnumerable<LogEntry> Entries { get; }
        LogStatus Status { get; }

        void As(LogType logType, string message, params object[] parameters);
        void Debug(string message, params object[] parameters);
        void Info(string message, params object[] parameters);
        void Warning(string message, params object[] parameters);
        void Error(string message, params object[] parameters);
        void Profile(string taskName, TimeSpan timeElapsed);
    }
}
