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
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging.Debug;

using Rock.Attribute;
using Rock.Observability;
using Rock.SystemKey;

using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace Rock.Logging
{
    /// <summary>
    /// This is the static class that is used to log data in Rock.
    /// </summary>
    public static class RockLogger
    {
        private static IRockLogger _log;

        private static readonly ServiceProvider _serviceProvider;

        private static readonly DynamicConfigurationProvider _standardConfigurationProvider;

        private static readonly DynamicConfigurationProvider _advancedConfigurationProvider;

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

            _standardConfigurationProvider = new DynamicConfigurationProvider();
            _standardConfigurationProvider.Set( "LogLevel:Default", "None" );

            _advancedConfigurationProvider = new DynamicConfigurationProvider();

            var configuration = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                .Add( _standardConfigurationProvider )
                .Add( _advancedConfigurationProvider )
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

        /// <summary>
        /// Gets the standard categories that have been defined in Rock.
        /// </summary>
        /// <returns>A list of category names.</returns>
        [RockInternal( "1.17", true )]
        public static List<string> GetStandardCategories()
        {
            return Reflection.FindTypes( typeof( object ) )
                .Select( p => p.Value )
                .Where( t => t.GetCustomAttribute<RockLoggingCategoryAttribute>() != null )
                .Select( t => t.FullName )
                .ToList();
        }

        /// <summary>
        /// Reloads the configuration defined in the database and reconfigures
        /// the loggers to match the new settings.
        /// </summary>
        [RockInternal( "1.17", true )]
        public static void ReloadConfiguration()
        {
            var configuration = Rock.Web.SystemSettings.GetValue( SystemSetting.ROCK_LOGGING_SETTINGS ).FromJsonOrNull<RockLogSystemSettings>();
            LoadConfiguration( configuration );
        }

        /// <summary>
        /// Loads the configuration specified by the system settings.
        /// </summary>
        /// <param name="configuration">The configuration object.</param>
        private static void LoadConfiguration( RockLogSystemSettings configuration )
        {
            var root = new Dictionary<string, object>();
            var logLevel = new Dictionary<string, string>();

            root.Add( "LogLevel", logLevel );

            logLevel.Add( "Default", "None" );

            if ( configuration.StandardCategories != null )
            {
                foreach ( var category in configuration.StandardCategories )
                {
                    logLevel.AddOrReplace( category, configuration.StandardLogLevel.ToString() );
                }
            }

            _standardConfigurationProvider.LoadFromJson( root.ToJson(), true );
            _advancedConfigurationProvider.LoadFromJson( configuration.AdvancedSettings, true );
        }
    }
}
