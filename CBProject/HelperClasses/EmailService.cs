using CBProject.Models;
using CBProject.Models.EntityModels;
using CBProject.Models.ViewModels;
using CBProject.Repositories.IdentityRepos;
using CBProject.Repositories.IdentityRepos.Interfaces;
using FluentEmail.Core;
using FluentEmail.Smtp;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CBProject.HelperClasses
{
    public class EmailService : IEmailService
    {
        private SmtpSender _sender;
        private readonly RolesRepo _rolesRepo;
        private readonly UsersRepo _usersRepo;

        public EmailService(IRolesRepo rolesRepo, IUsersRepo usersRepo)
        {
            this._rolesRepo = (RolesRepo)rolesRepo;
            this._usersRepo = (UsersRepo)usersRepo;
            _sender = new SmtpSender(() => new SmtpClient("smtp.gmail.com")
            {
                UseDefaultCredentials = false,
                Port = 587,
                Credentials = new NetworkCredential("codeme.email@gmail.com", "codeme123"),
                EnableSsl = true
            });
        }

        public async Task EmployeeRequestSendEmail(ApplicationUser user)
        {
            Email.DefaultSender = _sender;
            var roles = await this._rolesRepo
                                .GetAllQuerable()
                                .Where(r => r.Name.Equals("Admin") || r.Name.Equals("Manager"))
                                .ToListAsync();

            List<string> usersEmails = new List<string>();
            foreach (var role in roles)
            {
                var myRole = await this._rolesRepo.GetAllQuerable().FirstOrDefaultAsync(r => r.Id.Equals(role.Id));
                var myUsers = await this._usersRepo.GetUsersFromRoleAsync(myRole.Name);
                foreach (var u in myUsers)
                {
                    var email = Email
                        .From("codeme.email@gmail.com", "CodeMe")
                        .To(u.Email)
                        .Subject(EmployeeRequestSubject(user.FullName))
                        .Body(EmployeeRequestEmailBody(user.FullName));
                    await email.SendAsync();
                }
            }
        }

        private string EmployeeRequestSubject(string name)
        {
            return "New Employee Registration Request.";
        }
        
        private string EmployeeRequestEmailBody(string name)
        {
            StringBuilder body = new StringBuilder();
            body.Append($"Employee Name: {name},\n\n");
            return body.ToString();
        }

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

        public Task SendEmailContact(ContactViewModel contact)
        {

            StringBuilder message = new StringBuilder();
            message.Append($"From:{contact.LastName} {contact.FirstName} \n")
                   .Append($"Email: {contact.Email} \n")
                   .Append($"Phone: {contact.Phone} \n")
                   .Append($"Subject: {contact.Subject} \n")
                   .Append($"Message: {contact.Message} \n");

            StringBuilder messageToUser = new StringBuilder();
            messageToUser.Append($"Dear {contact.LastName} {contact.FirstName}, \n")
                   .Append($"We received your message and we will contact you shortly! \n")
                   .Append($"Kind Regards, \n")
                   .Append($"--CodeMe Team");

            Email.DefaultSender = _sender;

            var emailToUser = Email
                .From("codeme.email@gmail.com", "CodeMe Support")
                .To(contact.Email)
                .Subject("Contact CodeMe")
                .Body(messageToUser.ToString());

            var email = Email
                .From("codeme.email@gmail.com", "Contact Form")
                .To("codeme.email@gmail.com")
                .Subject("Contact Form")
                .Body(message.ToString());

            emailToUser.SendAsync();
            return email.SendAsync();
        }

        public Task SendEmailChangedPassword(ApplicationUser user)
        {

            Email.DefaultSender = _sender;

            StringBuilder body = new StringBuilder();
            body.Append($"Dear {user.Email},\n\n")
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

        public Task SendEmailReceipt(ApplicationUser user)
        {
            Email.DefaultSender = _sender;

            StringBuilder body = new StringBuilder();
            body.Append($"Dear {user.FullName},\n\n")
                .Append($"We have received your payment.\n\n")
                .Append($"Kind Regards, \n")
                .Append($"--CodeMe Team");


            var email = Email
                .From("codeme.email@gmail.com", "CodeMe")
                .To(user.Email)
                .Subject("Payment Received")
                .Body(body.ToString());

            return email.SendAsync();
        }
    }
}