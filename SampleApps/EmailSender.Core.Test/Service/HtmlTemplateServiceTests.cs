using EmailSender.Core.Model;
using EmailSender.Core.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmailSender.Core.Test.Service
{
    public class HtmlTemplateServiceTests
    {
        [Fact]
        public void GetBodyFromTemplate_EmailMessage_ShouldCreate_EmailBody()
        {
            var htmlTemplateService = new HtmlTemplateService();
            var emailMessage = new EmailMessage
            {
                UserName = "Vikrant",
                Title = "Test Email",
                Url = "www.google.com",
                Description = "This is test email"
            };
            var body = htmlTemplateService.GetBodyFromTemplate("TestTemplate", emailMessage);
            string expected = string.Empty;
            using (StreamReader SourceReader = File.OpenText("TestData\\TestTemplate1.html"))
            {
                expected = SourceReader.ReadToEnd();
            }
            Assert.Equal(expected, body);
        }
    }
}
