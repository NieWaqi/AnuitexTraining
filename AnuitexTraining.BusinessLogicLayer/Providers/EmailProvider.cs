﻿using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using static AnuitexTraining.Shared.Constants.Constants;

namespace AnuitexTraining.BusinessLogicLayer.Providers
{
    public class EmailProvider
    {
        private readonly MailAddress _mailAddress;
        private readonly SmtpClient _smtpClient;

        public EmailProvider()
        {
            _mailAddress = new MailAddress(EmailProviderOptions.Email);
            _smtpClient = new SmtpClient(EmailProviderOptions.SmtpUrl)
            {
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential(EmailProviderOptions.Email, EmailProviderOptions.Password),
                EnableSsl = true
            };
        }

        public async Task SendEmailConfirmationMessageAsync(long id, string code, string email)
        {
            var message = new MailMessage(_mailAddress, new MailAddress(email))
            {
                Subject = EmailProviderOptions.EmailConfirmationSubject,
                Body = string.Format(EmailProviderOptions.EmailConfirmationMessage,
                    EmailProviderOptions.EmailConfirmationUrl, id, HttpUtility.UrlEncode(code))
            };
            await _smtpClient.SendMailAsync(message);
        }

        public async Task SendPasswordResetMessageAsync(string password, string email)
        {
            var message = new MailMessage(_mailAddress, new MailAddress(email))
            {
                Subject = EmailProviderOptions.PasswordResetSubject,
                Body = string.Format(EmailProviderOptions.PasswordResetMessage, password)
            };
            await _smtpClient.SendMailAsync(message);
        }

        public async Task SendEmailChangeMessageAsync(long id, string email, string code)
        {
            var message = new MailMessage(_mailAddress, new MailAddress(email))
            {
                Subject = EmailProviderOptions.EmailChangeSubject,
                Body = string.Format(EmailProviderOptions.EmailChangeMessage, EmailProviderOptions.EmailChangeUrl, id, email, HttpUtility.UrlEncode(code))
            };
            await _smtpClient.SendMailAsync(message);
        }
    }
}