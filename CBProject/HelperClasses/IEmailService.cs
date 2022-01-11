using CBProject.Models;
using CBProject.Models.ViewModels;
using System.Threading.Tasks;

namespace CBProject.HelperClasses
{
    public interface IEmailService
    {
        Task EmployeeRequestSendEmail(ApplicationUser user);
        Task SendEmailChangedPassword(ApplicationUser user);
        Task SendEmailContact(ContactViewModel contact);
        Task SendEmailReceipt(ApplicationUser user);
        Task SendEmailRegister(ApplicationUser user);
    }
}