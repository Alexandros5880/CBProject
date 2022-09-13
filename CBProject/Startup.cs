using CBProject.Areas.Forum;
using CBProject.Areas.Messenger;
using CBProject.HelperClasses;
using CBProject.HelperClasses.Interfaces;
using CBProject.Models;
using CBProject.Repositories.IdentityRepos;
using CBProject.Repositories.IdentityRepos.Interfaces;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CBProject.Startup))]
namespace CBProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Dependency On My SignalR Hub Classes
            GlobalHost.DependencyResolver.Register(
                typeof(ForumHub), () => new ForumHub(
                    (IUnitOfWork) new UnitOfWork(new ApplicationDbContext()),
                    (IUsersRepo) new UsersRepo(new ApplicationDbContext(), new UnitOfWork(new ApplicationDbContext()))
                )
            );
            GlobalHost.DependencyResolver.Register(
                typeof(MessengerHub), () => new MessengerHub((IUnitOfWork) new UnitOfWork(new ApplicationDbContext()))
            );
            app.MapSignalR();

            ConfigureAuth(app);
        }



        private void createRolesandUsers()
        {

            //ApplicationDbContext context = new ApplicationDbContext();
            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            //var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            //// In Startup iam creating first Admin Role and creating a default Admin User     
            //if (!roleManager.RoleExists("Admin"))
            //{

            //    // First we create Admin rool    
            //    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
            //    role.Name = "Admin";
            //    roleManager.Create(role);

            //    //Here we create a Admin super user who will maintain the website                   

            //    var user = new ApplicationUser();
            //    user.UserName = "shanu";
            //    user.Email = "syedshanumcain@gmail.com";

            //    string userPWD = "A@Z200711";

            //    var chkUser = UserManager.Create(user, userPWD);

            //    //Add default User to Role Admin    
            //    if (chkUser.Succeeded)
            //    {
            //        var result1 = UserManager.AddToRole(user.Id, "Admin");

            //    }
            //}

            //// creating Creating Manager role     
            //if (!roleManager.RoleExists("Manager"))
            //{
            //    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
            //    role.Name = "Manager";
            //    roleManager.Create(role);

            //}

            //// creating Creating Employee role     
            //if (!roleManager.RoleExists("Employee"))
            //{
            //    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
            //    role.Name = "Employee";
            //    roleManager.Create(role);

            //}
        }

    }
}
