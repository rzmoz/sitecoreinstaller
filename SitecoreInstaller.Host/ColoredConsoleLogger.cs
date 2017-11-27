using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions.Internal;

namespace SitecoreInstaller.Host
{
    public class ColoredConsoleLogger : ILogger
    {
        private LogLevel LogLevel { get; }

        public ColoredConsoleLogger(LogLevel logLevel = LogLevel.Trace)
        {
            LogLevel = logLevel;
        }


        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }
            switch (logLevel)
            {
                case LogLevel.Critical:
                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case LogLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case LogLevel.Information:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case LogLevel.Debug:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case LogLevel.Trace:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                default:
                    return;
            }

            var message = formatter(state, exception);
            Console.WriteLine(message);
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return LogLevel <= logLevel;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return NullScope.Instance;
        }
    }
}
