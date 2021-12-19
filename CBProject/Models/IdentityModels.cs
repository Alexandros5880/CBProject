using CBProject.Models.EntityModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CBProject.Models
{


    public enum RoleLevel
    {
        SUPERLOW,
        LOW,
        MIDDLE,
        PLUSSFULL,
        FULL
    }

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
        public string ImagePath { get; set; }
        public bool NewsletterAcception { get; set; }
        public bool IsInactive { get; set; }
        public ICollection<Video> Videos { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Ebook> Ebooks { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, string> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            ApplicationUser applicationUser = this;
            userIdentity.AddClaim(new Claim("FullName", applicationUser.FullName));
            userIdentity.AddClaim(new Claim("ImagePath", applicationUser.ImagePath));
        // Add custom user claims here
        return userIdentity;
        }
    }

    public class ApplicationRole : IdentityRole
    {
        public RoleLevel Level { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,
                                                            ApplicationRole,
                                                            string,
                                                            IdentityUserLogin,
                                                            IdentityUserRole,
                                                            IdentityUserClaim>,
                                            IApplicationDbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryToCategory> CategoriesToCategories { get; set; }
        public DbSet<SubscriptionPackage> SubcriptionPackages { get; set; }
        public DbSet<ContentType> ContentTypes { get; set; }
        public DbSet<Ebook> Ebooks { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<TagToVideo> TagsToVideos { get; set; }
        public DbSet<TagToEbook> TagsToEbooks { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // modelBuilder.Configurations.Add(new CategoryConfig());
            //modelBuilder.Configurations.Add(new RatingConfig());
            //modelBuilder.Configurations.Add(new ReviewConfig());
            //modelBuilder.Configurations.Add(new TagConfig());
            //modelBuilder.Configurations.Add(new VideoConfig());
            base.OnModelCreating(modelBuilder);

        }
    }

}