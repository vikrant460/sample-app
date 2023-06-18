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
                AutoCreateSqlTable = false,
                TableName = tableName
            };

            var logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.MSSqlServer(connectionString,
                    mssqlSinkOptions,
                    columnOptions: columnOptions,
                    restrictedToMinimumLevel: LogEventLevel.Error
                ).CreateLogger();
            _errorLogger = logger; 
        }

        public static void LogError(LogDetail details)
        {
            _errorLogger.Error("{Time}{ProcessName}{MachineName}{Error}", details.TimeStamp,details.ProcessName, details.MachineName, details.Error);
        }

        private static ColumnOptions BuildColumnOptions()
        {
            var columnOptions = new ColumnOptions
            {

                AdditionalColumns = new Collection<SqlColumn>
                {
                    new SqlColumn { DataType = SqlDbType.NVarChar, ColumnName = "MachineName" },
                    new SqlColumn { DataType = SqlDbType.NVarChar, ColumnName = "ProcessName" },
                    new SqlColumn { DataType = SqlDbType.NVarChar, ColumnName = "Error" },
                    new SqlColumn { DataType = SqlDbType.DateTime, ColumnName = "Time"}

                }
            };

            columnOptions.Store.Remove(StandardColumn.Properties);
            columnOptions.Store.Remove(StandardColumn.MessageTemplate);
            columnOptions.Store.Remove(StandardColumn.Message);
            columnOptions.Store.Remove(StandardColumn.Id);
            columnOptions.Store.Remove(StandardColumn.Level);
            columnOptions.Store.Remove(StandardColumn.Exception);
            columnOptions.Store.Remove(StandardColumn.LogEvent);
            columnOptions.Store.Remove(StandardColumn.TimeStamp);

            return columnOptions;
        }
    }
}
