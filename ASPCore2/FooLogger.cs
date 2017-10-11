using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ASPCore2
{
    [ProviderAlias("Foo")]
    public class FooLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new FooLogger(categoryName);
        }

        public void Dispose()
        {
        }
    }

    public class FooLogger : ILogger
    {
        private readonly string _categoryName;

        public FooLogger(string categoryName)
        {
            _categoryName = categoryName;
        }       

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            var message = formatter(state, exception);
            System.Diagnostics.Debug.WriteLine(message, _categoryName);
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }
    }
}
