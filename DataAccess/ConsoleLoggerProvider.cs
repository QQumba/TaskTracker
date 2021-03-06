using System;
using Microsoft.Extensions.Logging;

namespace DataAccess
{
    public class ConsoleLoggerProvider : ILoggerProvider
    {
        public void Dispose() { }

        public ILogger CreateLogger(string categoryName)
        {
            return new ConsoleLogger();
        }

        private class ConsoleLogger : ILogger
        {
            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
                Func<TState, Exception, string> formatter)
            {
                Console.WriteLine(formatter(state, exception));
            }

            public bool IsEnabled(LogLevel logLevel)
            {
                return true;
            }

            public IDisposable BeginScope<TState>(TState state)
            {
                return null;
            }
        }
    }
}