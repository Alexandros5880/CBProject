﻿using CBProject.Models.EntityModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace CBProject.Models.ViewModels
{
    public class ApplicationUserViewModel
    {
        public string Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
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

        public ICollection<IdentityUserRole> Roles { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

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

        public int? SubscriptionPackageId { get; set; }
        public SubscriptionPackage SubscriptionPackage { get; set; }
        public bool Subscribed
        {
            get
            {
                return this.SubscriptionPackage != null;
            }
        }

        public string CVPath { get; set; }
        public HttpPostedFileBase CVFile { get; set; }

        public string ImagePath { get; set; }
        [Required]
        public HttpPostedFileBase ImageFile { get; set; }

        public bool NewsletterAcception { get; set; }

        public bool IsInactive { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "You need to agree first!")]
        public bool IsAgreeWithTerms { get; set; }

        public ICollection<ApplicationRole> OtherRoles { get; set; }
        public ICollection<ApplicationRole> MyRoles { get; set; }
        public ICollection<string> AddRoles { get; set; }
        public ICollection<string> RemoveRoles { get; set; }
    }
}