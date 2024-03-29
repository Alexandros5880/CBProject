﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace CBProject.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
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
        [StringLength(100, ErrorMessage = "Ener your Country.", MinimumLength = 3)]
        public string Country { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Ener your State.", MinimumLength = 3)]
        public string State { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Ener your City.", MinimumLength = 3)]
        public string City { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Ener your PostalCode.", MinimumLength = 3)]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Ener your Street.", MinimumLength = 3)]
        public string Street { get; set; }

        [DisplayName("Street Number")]
        [Required]
        [StringLength(100, ErrorMessage = "Ener your StreetNumber", MinimumLength = 1)]
        public string StreetNumber { get; set; }

        public string EmployeeMessage { get; set; }

        public System.Web.Mvc.SelectList Roles { get; set; }
        public string RoleId { get; set; }

        public string CVPath { get; set; }
        public HttpPostedFileBase CVFile { get; set; }

        public string ImagePath { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }

        public bool NewsletterAcception { get; set; }

        public bool TermsAndConditionsAcception { get; set; }

        public bool IsInactive { get; set; }
        [Range(typeof(bool), "true", "true", ErrorMessage = "You need to agree first!")]
        public bool IsAgreeWithTerms { get; set; }

    }

    public class ResetPasswordViewModel
    {
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

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
