using CBProject.Models;
using CBProject.Repositories.Interfaces;
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
        IRepository<Video> Videos { get; }
        IRepository<Rating> Ratings { get; }

        IRepository<Tag> Tags { get; }

        IRepository<Review> Reviews { get; }


    }
}
