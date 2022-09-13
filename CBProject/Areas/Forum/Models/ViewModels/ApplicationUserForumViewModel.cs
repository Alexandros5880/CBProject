using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CBProject.Areas.Forum.Models.ViewModels
{
    public class ApplicationUserForumViewModel
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
        public string FullName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Ener your First Name.", MinimumLength = 3)]
        public string UserName { get; set; }

        public ICollection<IdentityUserRole> Roles { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

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

        public string ImagePath { get; set; }

        public bool IsInactive { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "You need to agree first!")]
        public bool IsAgreeWithTerms { get; set; }
    }
}