using CBProject.Areas.Forum.Models.EntityModels;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace CBProject.Models.EntityModels
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.MessengerGroups = new HashSet<MessengerGroup>();
        }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [NotMapped]
        public string FullName { get { return this.FirstName + " " + this.LastName; } }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string StreetNumber { get; set; }
        public string CreditCardNum { get; set; }
        public string ContentAccess { get; set; }
        public string CVPath { get; set; }
        public string ImagePath { get; set; }
        public bool NewsletterAcception { get; set; }
        public bool TermsAndConditionsAcception { get; set; }
        public bool IsInactive { get; set; }
        public ICollection<Video> Videos { get; set; }
        public ICollection<Ebook> Ebooks { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public virtual ICollection<MessengerGroup> MessengerGroups { get; set; }
        public ICollection<MessengerMessage> MessengerMessages { get; set; }
        public ICollection<ForumQuestion> ForumQuestions { get; set; }
        public ICollection<ForumAnswer> ForumAnswers { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, string> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            ApplicationUser applicationUser = this;
            //userIdentity.AddClaim(new Claim("FullName", applicationUser.FullName));
            // Add custom user claims here
            return userIdentity;
        }
    }
}