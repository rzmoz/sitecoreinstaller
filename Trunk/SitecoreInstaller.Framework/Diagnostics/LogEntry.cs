using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Framework.Diagnostics
{
    public class LogEntry
    {
        public LogEntry(LogType logType, DateTime timeStamp, string message, params object[] parameters)
        {
            LogType = logType;
            Message = message == null ? string.Empty : string.Format(message, parameters);
            TimeStamp = timeStamp;
        }

        public LogType LogType { get; private set; }

        public DateTime TimeStamp { get; private set; }
        public string Message { get; private set; }

        public override string ToString()
        {
            return string.Format(_LogFormat, TimeStamp.ToString("yyyy-MM-dd HH:mm:ss"), LogType, Message);
        }

        private const string _LogFormat = "{0} <{1}> {2}";
    }
}
