using CBProject.Models.EntityModel;
using CBProject.Models.EntityModels;
using System.Data.Entity;

namespace CBProject.Models
{
    public interface IApplicationDbContext
    {
        DbSet<Category> Categories { get; set; }
        DbSet<SubscriptionPackage> SubcriptionPackages { get; set; }
        DbSet<ContentType> ContentTypes { get; set; }
        DbSet<Ebook> Ebooks { get; set; }
        DbSet<Video> Videos { get; set; }
        DbSet<Rating> Ratings { get; set; }
        DbSet<Review> Reviews { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<Payment> Payments { get; set; }

    }
}