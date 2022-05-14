using Easy.MessageHub;
using Hangfire;
using Notification.Core.Interfaces;
using Notification.Core.Model;
using NotificationScehduler.Core.Interfaces;

namespace NotificationScehduler.Core.Implementations
{
    public class NotificationScehdulingService : INotificationSchedulingService
    {

        private readonly INotificationService _notificationService;
        private readonly IMessageHub _messageHub;

        public NotificationScehdulingService(INotificationService notificationService, IMessageHub messageHub)
        {
            _notificationService = notificationService;
            _messageHub = messageHub;
            var token = _messageHub.Subscribe<EmailNotification>(SendNotification);
        }

        private void SendNotification(EmailNotification obj)
        {
            _notificationService.Send(obj);
        }

        public void ScheduleReminderNotification()
        {
            BackgroundJob.Schedule<INotificationService>(x => x.Send(new EmailNotification { Id = new Random().Next(100) }), new DateTime(2022, 4, 27, 00, 09, 00));
        }
    }
}
