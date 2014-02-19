using System;
using System.Collections.Generic;
using System.Linq;
using CSharp.Basics.Sys;
using System.Threading;

namespace SitecoreInstaller.Framework.Diagnostics
{
    public class InMemoryBufferedLog : ILog
    {
        private readonly IList<LogEntry> _entries;
        private readonly Queue<LogEntry> _notifyBuffer;

        private const int _flushInterval = 250;

        public event EventHandler<GenericEventArgs<LogEntry>> EntryLogged;
        public event EventHandler LogCleared;

        private Timer _flushTimer;

        public InMemoryBufferedLog()
        {
            _entries = new List<LogEntry>(50000);
            _notifyBuffer = new Queue<LogEntry>(_flushInterval * 10);//initial size of log should be proportional to how often it is flushed
            _logStatus = new Observable<LogStatus>();
            _logStatus.Updated += _logStatus_Updated;
            _logStatus.Value = LogStatus.NoProblems;
            SetStatus = this.SetStatusWhenHasNoProblems;
            Reset();
        }

        private void _logStatus_Updated(object sender, GenericEventArgs<LogStatus> e)
        {
            switch (e.Arg)
            {
                case LogStatus.NoProblems:
                    SetStatus = this.SetStatusWhenHasNoProblems;
                    break;
                case LogStatus.Warnings:
                    SetStatus = this.SetStatusWhenHasWarnings;
                    break;
                case LogStatus.Errors:
                    SetStatus = this.SetStatusWhenHasErrors;
                    break;
            }
        }

        public void Flush()
        {
            FlushLogBuffer(null);
        }

        public void Reset()
        {
            Flush();
            _entries.Clear();
            lock (_notifyBuffer)
            {
                _notifyBuffer.Clear();
                _logStatus.Value = LogStatus.NoProblems;
            }
            _flushTimer = new Timer(FlushLogBuffer, null, 0, _flushInterval);

            if (LogCleared != null)
                LogCleared(this, EventArgs.Empty);
        }

        public IEnumerable<LogEntry> Entries
        {
            get { return _entries; }
        }

        public LogStatus Status
        {
            get { return _logStatus.Value; }
        }

        private readonly Observable<LogStatus> _logStatus;

        public void StopFlushTimer()
        {
            _flushTimer.Dispose();
        }

        public void As(LogType logType, string message, params object[] parameters)
        {
            Action<string, object[]> logAs;
            switch (logType)
            {
                case LogType.Debug:
                    logAs = Debug;
                    break;
                case LogType.Info:
                    logAs = Info;
                    break;
                case LogType.Warning:
                    logAs = Warning;
                    break;
                case LogType.Error:
                    logAs = Error;
                    break;
                case LogType.Null:
                    logAs = Null;
                    break;
                default:
                    throw new NotSupportedException(logType + " not supported");
            }
            logAs(message, parameters);
        }
        public void Null(string message, params object[] parameters)
        {
            //we throw the message into the void
        }

        public void Debug(string message, params object[] parameters)
        {
            LogMessage(LogType.Debug, message, parameters);
        }

        public void Info(string message, params object[] parameters)
        {
            LogMessage(LogType.Info, message, parameters);
        }

        public void Warning(string message, params object[] parameters)
        {
            LogMessage(LogType.Warning, message, parameters);
        }

        public void Error(string message, params object[] parameters)
        {
            LogMessage(LogType.Error, message, parameters);
        }

        public void Profile(object sender, ProfilerEventArgs args)
        {
            Profile(args.TaskName, args.Elapsed);
        }

        public void Profile(string taskName, TimeSpan timeElapsed)
        {
            var timeElapsedFormatted = string.Format("{0:0.00}", timeElapsed.TotalSeconds);
            LogMessage(LogType.Profiling, "{0} finished in {1} seconds", taskName, timeElapsedFormatted);
        }

        public void LogMessage(LogType logType, string message, params object[] parameters)
        {
            LogMessage(logType, DateTime.Now, message, parameters);
        }
        public void LogMessage(LogType logType, DateTime timeStamp, string message, params object[] parameters)
        {
            if (message == null)
                return;

            var loggedMessage = message;
            if (parameters.Length > 0)
                loggedMessage = string.Format(message, parameters);

            var newEntry = new LogEntry(logType, timeStamp, loggedMessage);
            _entries.Add(newEntry);
            lock (_notifyBuffer)
            {
                _notifyBuffer.Enqueue(newEntry);
            }
        }

        private void FlushLogBuffer(object sender)
        {
            if (EntryLogged == null)
                return;
            lock (_notifyBuffer)
            {
                //we set status based on entries in buffer before dequeuing
                SetStatus();
                while (_notifyBuffer.Count > 0)
                {
                    var logMessage = _notifyBuffer.Dequeue();
                    EntryLogged(this, new GenericEventArgs<LogEntry>(logMessage));
                }
            }
        }

        private Action SetStatus { get; set; }

        private void SetStatusWhenHasErrors()
        { }
        private void SetStatusWhenHasWarnings()
        {
            if (_notifyBuffer.Any(entry => entry.LogType == LogType.Error))
                _logStatus.Value = LogStatus.Errors;
        }
        private void SetStatusWhenHasNoProblems()
        {
            //see if we have any errors
            this.SetStatusWhenHasWarnings();

            //if Errors are found, we don't bother checking for warnings
            if (_logStatus.Value == LogStatus.Errors)
                return;
            if (_notifyBuffer.Any(entry => entry.LogType == LogType.Warning))
                _logStatus.Value = LogStatus.Warnings;
        }
    }
}
