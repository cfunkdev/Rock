// <copyright>
// Copyright by the Spark Development Network
//
// Licensed under the Rock Community License (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.rockrms.com/license
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

using Rock.Observability;

using Serilog.Formatting.Compact;
using Serilog;
using Serilog.Events;
using System.Collections.Generic;
using System;
using Serilog.Core;
using Microsoft.Extensions.Logging.Abstractions;

namespace Rock.Logging
{
    /// <summary>
    /// This is the static class that is used to log data in Rock.
    /// </summary>
    public static class RockLogger
    {
        private static IRockLogger _log;

        private static readonly ServiceProvider _serviceProvider;

        private static readonly DynamicConfigurationProvider _dynamicConfigurationProvider;

        /// <summary>
        /// Gets the logger with logging methods.
        /// </summary>
        /// <value>
        /// The log.
        /// </value>
        public static IRockLogger Log
        {
            get
            {
                if ( _log == null )
                {
                    // In the future the RockLogConfiguration could be gotten via dependency injection, but not today.
                    _log = new RockLoggerSerilog( new RockLogConfiguration() );
                }
                return _log;
            }
        }

        /// <summary>
        /// Gets the logger factory currently associated with this application
        /// instance.
        /// </summary>
        /// <value>The logger factory.</value>
        public static ILoggerFactory LoggerFactory { get; private set; } = new NullLoggerFactory();

        /// <summary>
        /// Gets the log reader.
        /// </summary>
        /// <value>
        /// The log reader.
        /// </value>
        public static IRockLogReader LogReader => new RockSerilogReader( Log );

        //internal static SeriLoggerWrapper SerilogWrapper { get; } = new SeriLoggerWrapper();

        internal static SeriSinkWrapper SinkWrapper { get; } = new SeriSinkWrapper();

        static RockLogger()
        {
            var serviceCollection = new ServiceCollection();

            _dynamicConfigurationProvider = new DynamicConfigurationProvider();
            _dynamicConfigurationProvider.Set( "LogLevel:Default", "None" );

            var configuration = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                .Add( _dynamicConfigurationProvider )
                .Build();

            serviceCollection.AddLogging( cfg =>
            {
                cfg.AddConfiguration( configuration );

                ObservabilityHelper.ConfigureLoggingBuilder( cfg );
                cfg.AddProvider( new DebugLoggerProvider() );

                var seriLogger = new LoggerConfiguration()
                     .MinimumLevel
                     .Verbose()
                     .WriteTo
                     .Sink( SinkWrapper )
                     .CreateLogger();

                cfg.AddProvider( new Serilog.Extensions.Logging.SerilogLoggerProvider( seriLogger ) );
            } );

            _serviceProvider = serviceCollection.BuildServiceProvider();
            LoggerFactory = _serviceProvider.GetRequiredService<ILoggerFactory>();
        }

        internal class SeriSinkWrapper : ILogEventSink
        {
            public Serilog.ILogger Logger { get; set; }

            public void Emit( LogEvent logEvent )
            {
                Logger?.Write( logEvent );
            }
        }

        internal static void LoadConfiguration()
        {
            var configurationJson = @"{
  ""LogLevel"": {
    ""Default"": ""Information""
  }
}";
            _dynamicConfigurationProvider.LoadFromJson( configurationJson, true );
        }
    }
}
