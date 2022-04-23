using Notification.Core.Interfaces;
using Notification.Core.Model;

namespace Notification.Core
{
    public class EmailNotificationService : INotificationService
    {

        public void Send(BaseNotification notification)
        {
            Console.WriteLine($"Email Reminder {notification.Id} sent at {DateTime.Now}");
        }
    }
}