using CBProject.Models;
using FluentEmail.Core;
using FluentEmail.Smtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CBProject.HelperClasses
{
    public class EmailService
    {
        private SmtpSender _sender;
        public EmailService()
        {
            _sender = new SmtpSender(() => new SmtpClient("smtp.gmail.com")
            {
                UseDefaultCredentials = false,
                Port = 587,
                Credentials = new NetworkCredential("codeme.email@gmail.com", "codeme123"),
                EnableSsl = true
            });
        }
        public Task SendEmail(ApplicationUser user)
        {           

            Email.DefaultSender = _sender;

            var email = Email
                .From("codeme.email@gmail.com", "CodeMe")
                .To(user.Email)
                .Subject(WelcomeEmailSubject())
                .Body(WelcomeEmailBody(user.FullName));

            return email.SendAsync();
        }

        private string WelcomeEmailSubject()
        {
            return "Welcome to CodeMe";
        }

        private string WelcomeEmailBody(string name)
        {
            StringBuilder body = new StringBuilder();
            body.Append($"Dear {name},\n\n")
                .Append("Your registration is completed.\n\n")
                .Append($"Kind Regards, \n")
                .Append($"--CodeMe Team");

            return body.ToString();
        }
    }
}