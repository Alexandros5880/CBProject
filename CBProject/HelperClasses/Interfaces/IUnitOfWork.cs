using CBProject.Models;
using CBProject.Repositories;
using CBProject.Repositories.IdentityRepos;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CBProject.HelperClasses.Interfaces
{
    public interface IUnitOfWork
    {
        ApplicationDbContext Context { get; }
        RoleStore<ApplicationRole> RoleStore { get; }
        RoleManager<ApplicationRole> RoleManager { get; }
        UserStore<ApplicationUser, ApplicationRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim> UserStore { get; }
        ApplicationUserManager UserManager { get; }
        CategoriesRepository Categories { get; }
        CategoryToCategoryRepository CategoryToCategory { get; }
        VideosRepository Videos { get; }
        RatingsRepository Ratings { get; }
        TagsRepository Tags { get; }
        ReviewsRepository Reviews { get; }
        EbooksRepository Ebooks { get; }
        SubscriptionPackageRepository SubscriptionPackages { get; }
        PaymentsRepository Payments { get; }
        OrdersRepository Orders { get; }
        RequirementsRepository Requirements { get; }
        RatingsToEbooksRepository RatingsToEbooks { get; }
        RatingsToVideosRepository RatingsToVideos { get; }
        RequirementsToEbooksRepository RequirementsToEbooks { get; }
        RequirementsToVideosRepository RequirementsToVideos { get; }
        ReviewsToEbooksRepository ReviewsToEbooks { get; }
        ReviewsToVideosRepository ReviewsToVideos { get; }
        TagsToEbooksRepository TagsToEbooks { get; }
        TagsToVideosRepository TagsToVideos { get; }
        MessagesRepository Messages { get; }
        UsersSubscriptionPackagesRepo UserSubscriptionPackages { get; }
    }
}
