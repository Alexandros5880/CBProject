using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using CBProject.HelperClasses;
using CBProject.HelperClasses.Interfaces;
using CBProject.Models;
using CBProject.Models.Interfaces;
using CBProject.Repositories.IdentityRepos;
using CBProject.Repositories.IdentityRepos.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Http;
using System.Web.Mvc;

namespace CBProject.App_Start
{
    public class ContainerConfig
    {
        public static void RegisterContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<RolesRepo>().As<IRolesRepo>();
            builder.RegisterType<UsersRepo>().As<IUsersRepo>();
            builder.RegisterType<DataManagers>().As<IDataManagers>();
            builder.RegisterType<UserStore<ApplicationUser>>().As<IUserStore<ApplicationUser>>();
            builder.RegisterType<RoleStore<IdentityRole>>().As<IRoleStore<IdentityRole, string>>();
            builder.RegisterType<ApplicationDbContext>().As<IContext>();

            var container = builder.Build(); // Container with all my Objects for dependency Injection
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
        public static void RegisterContainerControllers()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<RolesRepo>().As<IRolesRepo>();
            builder.RegisterType<UsersRepo>().As<IUsersRepo>();
            builder.RegisterType<DataManagers>().As<IDataManagers>();
            builder.RegisterType<UserStore<ApplicationUser>>().As<IUserStore<ApplicationUser>>();
            builder.RegisterType<RoleStore<IdentityRole>>().As<IRoleStore<IdentityRole, string>>();
            builder.RegisterType<ApplicationDbContext>().As<IContext>();


            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
        public static void RegisterContainerControllersApi()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<RolesRepo>().As<IRolesRepo>();
            builder.RegisterType<UsersRepo>().As<IUsersRepo>();
            builder.RegisterType<DataManagers>().As<IDataManagers>();
            builder.RegisterType<UserStore<ApplicationUser>>().As<IUserStore<ApplicationUser>>();
            builder.RegisterType<RoleStore<IdentityRole>>().As<IRoleStore<IdentityRole, string>>();
            builder.RegisterType<ApplicationDbContext>().As<IContext>();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}