﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Framework.Diagnostics
{
  using SitecoreInstaller.Framework.Sys;

  using global::System.Threading;

  public class InMemoryBufferedLog : ILog
  {
    private readonly IList<LogEntry> _entries;
    private readonly Queue<LogEntry> _notifyBuffer;

    private const int _FlushInterval = 250;

    public event EventHandler<GenericEventArgs<LogEntry>> EntryLogged;
    public event EventHandler LogCleared;

    private Timer _flushTimer;

    public InMemoryBufferedLog()
    {
      _entries = new List<LogEntry>(50000);
      _notifyBuffer = new Queue<LogEntry>(_FlushInterval * 10);//initial size of log should be proportional to how often it is flushed
      _logStatus = new Observable<LogStatus>();
      _logStatus.Updated += _logStatus_Updated;
      _logStatus.Value = LogStatus.NoProblems;
      SetStatus = this.SetStatusWhenHasNoProblems;
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

    public void Clear()
    {
      _entries.Clear();
      lock (_notifyBuffer)
      {
        _notifyBuffer.Clear();
        _logStatus.Value = LogStatus.NoProblems;
      }
      _flushTimer = new Timer(FlushLogBuffer, null, 0, _FlushInterval);

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
      if (parameters != null)
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