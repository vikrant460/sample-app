using System.Diagnostics;

namespace Logging.Core
{
    public class LogDetail
    {
        public LogDetail()
        {
            
        }

        public DateTime TimeStamp { get; private set; }
        public string Error { get; set; } 
        public string MachineName => Environment.MachineName;
        public string ProcessName => Process.GetCurrentProcess().ProcessName;
    }
}