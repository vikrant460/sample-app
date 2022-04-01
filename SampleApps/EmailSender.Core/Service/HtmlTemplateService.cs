using EmailSender.Core.Interface;
using EmailSender.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Core.Service
{
    public class HtmlTemplateService : IHtmlTemplateService
    {
        public string GetBodyFromTemplate(string templateName, EmailMessage emailMessage)
        {
            string body = string.Empty;
            var path = GetTemplatePath(templateName);
            using (StreamReader SourceReader = File.OpenText(path))
            {
               body = SourceReader.ReadToEnd();
            }
            body = body.Replace("{UserName}", emailMessage.UserName);
            body = body.Replace("{Title}", emailMessage.Title);
            body = body.Replace("{Url}", emailMessage.Body);
            body = body.Replace("{Description}", emailMessage.Description);

            return body;
        }

        private string GetTemplatePath(string templateName)
        {
            var file = $"{ templateName}.html";
            return Path.Combine(EmailSenderConstants.TemplateBasePath, file);
        }
    }
}
