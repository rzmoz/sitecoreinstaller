using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Framework.Diagnostics
{
    public class LogEntry
    {
        public LogEntry(MessageType messageType, DateTime timeStamp, string message, params object[] parameters)
        {
            MessageType = messageType;
            Message = message == null ? string.Empty : string.Format(message, parameters);
            TimeStamp = timeStamp;
        }

        public MessageType MessageType { get; private set; }

        public DateTime TimeStamp { get; private set; }
        public string Message { get; private set; }

        public override string ToString()
        {
            return string.Format(_LogFormat, TimeStamp.ToString("yyyy-MM-dd HH:mm:ss"), MessageType, Message);
        }

        private const string _LogFormat = "{0} <{1}> {2}";
    }
}
