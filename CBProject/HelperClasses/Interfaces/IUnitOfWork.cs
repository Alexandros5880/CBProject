using CBProject.Models;
<<<<<<< HEAD
using CBProject.Models.EntityModels;
using CBProject.Repositories.Interfaces;
=======
using CBProject.Repositories;
>>>>>>> 24bfad01bd476523b662bbd8f380dd607b7c08ea
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
<<<<<<< HEAD
        IRepository<Video> Videos { get; }
        IRepository<Rating> Ratings { get; }
        IRepository<Tag> Tags { get; }
        IRepository<Review> Reviews { get; }
        IRepository<Ebook> Ebooks { get; }
        IRepository<Category> Categories { get; }


=======
        CategoriesRepository Categories { get; }
        ContentTypeRepository ContentTypes { get; }
        VideosRepository Videos { get; }
        RatingsRepository Ratings { get; }
        TagsRepository Tags { get; }
        ReviewsRepository Reviews { get; }
        EbooksRepository Ebooks { get; }
>>>>>>> 24bfad01bd476523b662bbd8f380dd607b7c08ea
    }
}
