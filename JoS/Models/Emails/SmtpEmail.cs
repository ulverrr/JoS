using NLog;
using System;
using System.Net.Mail;

namespace JoS.Models.Emails
{
    public class SmtpEmail : ISendEmail
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        private readonly SmtpClient _client;

        public SmtpEmail()
        {
            _client = new SmtpClient();
        }

        public void Send(string toAddress, string subject, string body, bool isBodyHtml = true)
        {
            var mailMessage = new MailMessage
            {
                To = { toAddress },
                Subject = subject,
                Body = body,
                IsBodyHtml = isBodyHtml
            };
            try
            {
                _client.Send(mailMessage);
            }
            catch (Exception e)
            {
                Logger.Error(e.Message, "Send email error.");
            }
        }
    }
}
