using CBProject.Models;
using CBProject.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CBProject.HelperClasses.Interfaces
{
    public interface IUnitOfWork
    {
        ApplicationDbContext Context { get; }
        RoleStore<IdentityRole> RoleStore { get; }
        RoleManager<IdentityRole> RoleManager { get; }
        UserStore<ApplicationUser> UserStore { get; }
        UserManager<ApplicationUser> UserManager { get; }
        VideosRepository Videos { get; }
        RatingsRepository Ratings { get; }
        TagsRepository Tags { get; }
        ReviewsRepository Reviews { get; }
        EbooksRepository Ebooks { get; }
    }
}
