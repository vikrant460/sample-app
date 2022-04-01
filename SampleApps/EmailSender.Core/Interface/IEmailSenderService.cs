using EmailSender.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Core.Interface
{
    public interface IEmailSenderService
    {
        public void SendEmail(EmailMessage emailMessage);
    }
}
