using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Framework.Diagnostics
{
    public class LogEntry
    {
        public LogEntry(LogType logType, DateTime timestamp, string message, params object[] parameters)
        {
            LogType = logType;
            Message = message == null ? string.Empty : parameters.Length == 0 ? message : string.Format(message, parameters);
            Timestamp = timestamp;
        }

        public LogType LogType { get; private set; }

        public DateTime Timestamp { get; private set; }
        public string Message { get; private set; }

        public override string ToString()
        {
            return string.Format(_LogFormat, Timestamp.ToString("yyyy-MM-dd HH:mm:ss"), LogType, Message);
        }

        private const string _LogFormat = "{0} <{1}> {2}";
    }
}
