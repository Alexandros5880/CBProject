using CBProject.Models.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CBProject.Models
{


    public class ApplicationUser : IdentityUser
    {
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

        public int SubscriptionId { get; set; }
        
        public string ContentAccess { get; set; }
        
        public string CVPath { get; set; }

        //public HttpPostedFileBase CVFile { get; set; }

        public int ContentCategoryId { get; set; }
        
        public int ContentId { get; set; }

        public bool NewsletterAcception { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }





    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder
            //    .Entity<ApplicationUser>()
            //    .Property(u => u.City)
            //    .IsRequired();
        }
    }

}