namespace Logging.Core
{
    public class LogDetail
    {
        public LogDetail()
        {
            
        }

        public DateTime TimeStamp { get; private set; }
        public string Message { get; set; } 
    }
}