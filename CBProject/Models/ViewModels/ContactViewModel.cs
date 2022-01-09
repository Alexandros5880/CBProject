using System.ComponentModel.DataAnnotations;

namespace CBProject.Models.ViewModels
{
    public class ContactViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Subject { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Message { get; set; }
    }
}