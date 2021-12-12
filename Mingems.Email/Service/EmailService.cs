﻿using Mingems.Shared.Core.Helpers;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace Mingems.Email.Service
{
    public class EmailService : IEmailService
    {
        private readonly EmailSenderOptions configuration;

        public EmailService(EmailSenderOptions configuration)
        {
            this.configuration = configuration;
        }

        #region Email Initializer
        private async Task Send(string subject, string senderMail, string htmlContent, string finalContent)
        {
            var client = new SendGridClient(configuration.ApiKey);
            var from = new EmailAddress(configuration.SenderEmail, configuration.SenderName);
            var to = new EmailAddress(senderMail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, finalContent, htmlContent);
            await client.SendEmailAsync(msg);
        }
        #endregion

        public async Task SendVerification(string email, string token)
        {
            var content = $"Hi, <br/> <br/> Please <a href='https://mingems-portal.herokuapp.com/verify/{token}'>verify</a> your account. <br/> Thank you";
            var subject = "Mingems | Account Verification";
            var finalContent = "Thank you for using our service";
            await Send(subject, email, content, finalContent);
        }

        public async Task SendForgotPasswordLink(string email, string token)
        {
            var content = $"Hi, <br/> <br/> This is your reset password link <a href='https://mingems-portal.herokuapp.com/forgot-password/{token}'>Click here</a> your account. <br/><br/> Thank you";
            var subject = "Mingems | Password Reset";
            var finalContent = "Thank you for using our service";
            await Send(subject, email, content, finalContent);
        }
    }
}