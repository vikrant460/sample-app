// See https://aka.ms/new-console-template for more information
using Logging.Core;

Console.WriteLine("Hello, World!");
var errorDetails = new LogDetail { Error = "Some error happened" };
Logger.LogError(errorDetails);
Console.Read();