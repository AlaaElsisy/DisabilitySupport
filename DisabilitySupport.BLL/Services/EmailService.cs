using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using DisabilitySupport.BLL.Interfaces;
using DisabilitySupport.DAL.Models.Authentication;
using MimeKit;
using MailKit.Net.Smtp;

namespace DisabilitySupport.BLL.Services
{
    public class EmailService : IEmailService
    {
       
        private readonly EmailConfiguration emailConfiguration;

        public EmailService(EmailConfiguration emailConfiguration) => this.emailConfiguration = emailConfiguration;
        public void sendEmail(Message message)
        {
            var emailMessage = createEmailMessage(message);
            send(emailMessage);
        }

        private MimeMessage createEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("email", emailConfiguration.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };
            return emailMessage;
        }

        private void send(MimeMessage message)
        {
            using var client = new SmtpClient();
            try
            {
                client.Connect(emailConfiguration.SmtpServer, emailConfiguration.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(emailConfiguration.Username, emailConfiguration.Password);
                client.Send(message);

            }
            catch
            {
                throw;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
}
