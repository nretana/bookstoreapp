using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService
{
    public class EmailSender : IEmailSender
    {
        private readonly IOptions<EmailConfiguration> _emailConfiguration;

        public EmailSender(IOptions<EmailConfiguration> emailConfiguration)
        {
            _emailConfiguration = emailConfiguration ?? throw new ArgumentNullException(nameof(emailConfiguration));
        }

        public void SendEmail(Message message) { 
        
            var mailMessage = CreateEmailMessage(message);
            Send(mailMessage);
        }

        public async Task SendEmailAsync(Message message)
        {

            var mailMessage = CreateEmailMessage(message);
            await SendAsync(mailMessage);
        }


        /// <summary>
        /// Create the email message to be sent
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private MimeMessage CreateEmailMessage(Message message)
        {
            MimeMessage mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress("email", _emailConfiguration.Value.From));
            mimeMessage.To.AddRange(message.To);
            mimeMessage.Subject = message.Subject;

            // use MimeKit.Text.TextFormat.Html if message body is html
            mimeMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Body };
            
            return mimeMessage;
        }

        /// <summary>
        /// send sync mail
        /// </summary>
        /// <param name="mailMessage"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private void Send(MimeMessage mailMessage)
        {
            //smtpClient => from using MailKit.Net.Smtp library
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_emailConfiguration.Value.SmtpServer, _emailConfiguration.Value.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfiguration.Value.Username, _emailConfiguration.Value.Password);

                    client.Send(mailMessage);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

        /// <summary>
        /// send async mail
        /// </summary>
        /// <param name="mailMessage"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private async Task SendAsync(MimeMessage mailMessage)
        {
            //smtpClient => from using MailKit.Net.Smtp library
            using (var client = new SmtpClient())
            {
                try
                {
                    client.CheckCertificateRevocation = false;

                    //connect with smtp server (outlook)
                    await client.ConnectAsync(_emailConfiguration.Value.SmtpServer, _emailConfiguration.Value.Port, SecureSocketOptions.StartTls);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");

                    //client authentication (outlook authentication)
                    await client.AuthenticateAsync(_emailConfiguration.Value.Username, _emailConfiguration.Value.Password);
                    
                    //send message
                    await client.SendAsync(mailMessage);
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }
    }
}
