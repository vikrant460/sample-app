using Serilog;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog.Events;

namespace Logging.Core
{
    public static class Logger
    {
        private static readonly ILogger _errorLogger;
        private const string _connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=MyAppDB;Integrated Security=SSPI;Encrypt=False;";
        private const string _schemaName = "dbo";
        private const string _tableName = "LogEvents";

        static Logger()
        {
            var appSettings = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
           
            var connectionString = appSettings.GetConnectionString("dbserver");
            var tableName = appSettings.GetConnectionString("logtable");
            Log.Logger = new LoggerConfiguration().WriteTo
                .MSSqlServer(
                    connectionString: connectionString,
                    sinkOptions: new MSSqlServerSinkOptions
                    {
                        TableName = tableName,
                        AutoCreateSqlTable = true
                    },
                    restrictedToMinimumLevel: LogEventLevel.Debug,
                    formatProvider: null,
                    columnOptions: null,
                    logEventFormatter: null)
                .CreateLogger();
            //BELOW WORKS
            //Log.Logger = new LoggerConfiguration().WriteTo
            //    .MSSqlServer(
            //        connectionString: _connectionString,
            //        sinkOptions: new MSSqlServerSinkOptions
            //        {
            //            TableName = _tableName,
            //            SchemaName = _schemaName,
            //            AutoCreateSqlTable = true
            //        },
            //        restrictedToMinimumLevel: LogEventLevel.Debug,
            //        formatProvider: null,
            //        columnOptions: null,
            //        logEventFormatter: null)
            //    .CreateLogger();

            _errorLogger = Log.Logger; 
        }

        public static void LogError(string message)
        {
            _errorLogger.Error(message);
        }
    }
}
