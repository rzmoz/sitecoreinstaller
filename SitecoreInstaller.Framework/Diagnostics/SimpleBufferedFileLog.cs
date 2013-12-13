using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SitecoreInstaller.Framework.Sys;

namespace SitecoreInstaller.Framework.Diagnostics
{
    public class SimpleBufferedFileLog : ILog
    {
        private readonly InMemoryBufferedLog _inMemoryLog;

        public SimpleBufferedFileLog()
        {
            _inMemoryLog = new InMemoryBufferedLog();
            _inMemoryLog.EntryLogged += _inMemoryLog_EntryLogged;
            _inMemoryLog.LogCleared += _inMemoryLog_LogCleared;
        }

        void _inMemoryLog_LogCleared(object sender, EventArgs e)
        {
        }

        void _inMemoryLog_EntryLogged(object sender, GenericEventArgs<LogEntry> e)
        {
        }

        public event EventHandler<GenericEventArgs<LogEntry>> EntryLogged;
        public event EventHandler LogCleared;

        public void Flush()
        {
            _inMemoryLog.Flush();
        }

        public void Reset()
        {
            _inMemoryLog.Reset();
        }

        public IEnumerable<LogEntry> Entries { get { return _inMemoryLog.Entries; } }
        public LogStatus Status { get { return _inMemoryLog.Status; } }

        public void Debug(string message, params object[] parameters)
        {
            _inMemoryLog.Debug(message, parameters);
        }

        public void Info(string message, params object[] parameters)
        {
            _inMemoryLog.Info(message, parameters);
        }

        public void Warning(string message, params object[] parameters)
        {
            _inMemoryLog.Warning(message, parameters);
        }

        public void Error(string message, params object[] parameters)
        {
            _inMemoryLog.Error(message, parameters);
        }

        public void Profile(string taskName, TimeSpan timeElapsed)
        {
            _inMemoryLog.Profile(taskName, timeElapsed);
        }
    }
}
