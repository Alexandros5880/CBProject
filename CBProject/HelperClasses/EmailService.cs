﻿using CBProject.Models;
using CBProject.Models.ViewModels;
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
using System.Xml.Linq;

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

        //SendEmailRegister
        //SendEmailContact
        //SendEmailChangedPassword
        

        public Task SendEmailRegister(ApplicationUser user)
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

        public Task SendEmailContact(ContactViewModel contact )
        {

            StringBuilder message = new StringBuilder();
            message.Append($"From:{contact.LastName} {contact.FirstName} \n")
                   .Append($"Email: {contact.Email} \n")
                   .Append($"Phone: {contact.Phone} \n")
                   .Append($"Subject: {contact.Subject} \n")
                   .Append($"Message: {contact.Message} \n");

            Email.DefaultSender = _sender;

            var email = Email
                .From("codeme.email@gmail.com", "Contact Form")
                .To("codeme.email@gmail.com")
                .Subject("Contact Form")
                .Body(message.ToString());

            return email.SendAsync();
        }

        public Task SendEmailChangedPassword(ApplicationUser user)
        {

            Email.DefaultSender = _sender;

            StringBuilder body = new StringBuilder();
            body.Append($"Dear {user.FullName},\n\n")
                .Append("Your Password has been changed.\n\n")
                .Append($"Kind Regards, \n")
                .Append($"--CodeMe Team");


            var email = Email
                .From("codeme.email@gmail.com", "CodeMe")
                .To(user.Email)
                .Subject("Change Password")
                .Body(body.ToString());

            return email.SendAsync();
        }
    }
}