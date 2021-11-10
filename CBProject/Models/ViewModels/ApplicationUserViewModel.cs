using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace CBProject.Models.ViewModels
{
    public class ApplicationUserViewModel
    {
        public string Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Ener your First Name.", MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Ener your First Name.", MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Ener your First Name.", MinimumLength = 3)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Telephone Number Required")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Ener your Country.", MinimumLength = 6)]
        public string Country { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Ener your State.", MinimumLength = 6)]
        public string State { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Ener your City.", MinimumLength = 6)]
        public string City { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Ener your PostalCode.", MinimumLength = 5)]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Ener your Street.", MinimumLength = 5)]
        public string Street { get; set; }

        [DisplayName("Street Number")]
        [Required]
        [StringLength(100, ErrorMessage = "Ener your StreetNumber", MinimumLength = 1)]
        public string StreetNumber { get; set; }

        public string CVPath { get; set; }

        public HttpPostedFileBase CVFile { get; set; }

        public bool NewsletterAcception { get; set; }
    }
}