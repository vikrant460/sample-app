using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Notification.Core.Model;

namespace Notification.Core.Interfaces
{
    public interface INotificationService
    {
        void Send(BaseNotification notification);
    }
}
