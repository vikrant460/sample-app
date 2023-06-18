using Serilog;
using Serilog.Sinks.MSSqlServer;
using Microsoft.Extensions.Configuration;
using Serilog.Events;
using System.Collections.ObjectModel;
using System.Data;

namespace Logging.Core
{
    public static class Logger
    {
        private static readonly ILogger _errorLogger;
        
        static Logger()
        {
            var appSettings = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
           
            var connectionString = appSettings.GetConnectionString("dbserver");
            var tableName = appSettings.GetConnectionString("logtable");

            var columnOptions = BuildColumnOptions();

            var mssqlSinkOptions = new MSSqlServerSinkOptions
            {
                AutoCreateSqlTable = true,
                TableName = tableName
            };

            var logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.MSSqlServer(connectionString,
                    mssqlSinkOptions,
                    columnOptions: BuildColumnOptions(),
                    restrictedToMinimumLevel: LogEventLevel.Error
                ).CreateLogger();
            _errorLogger = logger; 
        }

        public static void LogError(LogDetail details)
        {
            _errorLogger.Error("{ProcessName}{MachineName}{Error}", details.ProcessName, details.MachineName, details.Error);
        }

        private static ColumnOptions BuildColumnOptions()
        {
            var columnOptions = new ColumnOptions
            {
                TimeStamp =
                {
                    ColumnName = "TimeStampUTC",
                    ConvertToUtc = true,
                },

                AdditionalColumns = new Collection<SqlColumn>
                {
                    new SqlColumn { DataType = SqlDbType.NVarChar, ColumnName = "MachineName" },
                    new SqlColumn { DataType = SqlDbType.NVarChar, ColumnName = "ProcessName" },
                    new SqlColumn { DataType = SqlDbType.NVarChar, ColumnName = "Error" },

                }
            };

            columnOptions.Store.Remove(StandardColumn.Properties);
            columnOptions.Store.Remove(StandardColumn.MessageTemplate);
            columnOptions.Store.Remove(StandardColumn.Message);
            columnOptions.Store.Remove(StandardColumn.Id);
            columnOptions.Store.Remove(StandardColumn.Level);
            columnOptions.Store.Remove(StandardColumn.Exception);
            columnOptions.Store.Remove(StandardColumn.LogEvent);

            return columnOptions;
        }
    }
}
