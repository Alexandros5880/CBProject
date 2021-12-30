using CBProject.Models.EntityModels;
using System.Data.Entity;

namespace CBProject.Models
{
    public interface IApplicationDbContext
    {
        DbSet<Category> Categories { get; set; }
        DbSet<CategoryToCategory> CategoriesToCategories { get; set; }
        DbSet<SubscriptionPackage> SubcriptionPackages { get; set; }
        DbSet<Ebook> Ebooks { get; set; }
        DbSet<Video> Videos { get; set; }
        DbSet<Rating> Ratings { get; set; }
        DbSet<Review> Reviews { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<Payment> Payments { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Requirement> Requirements { get; set; }
        DbSet<TagToVideo> TagsToVideos { get; set; }
        DbSet<TagToEbook> TagsToEbooks { get; set; }
        DbSet<RatingToEbook> RatingsToEbooks { get; set; }
        DbSet<RatingToVideo> RatingsToVideos { get; set; }
        DbSet<ReviewToVideo> ReviewsToVideos { get; set; }
        DbSet<ReviewToEbook> ReviewsToEbooks { get; set; }
        DbSet<RequirementToEbook> RequirementsToEbooks { get; set; }
        DbSet<RequirementToVideo> RequirementsToVideos { get; set; }
    }
}