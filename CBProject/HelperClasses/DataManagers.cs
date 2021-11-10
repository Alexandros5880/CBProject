using CBProject.HelperClasses.Interfaces;
using CBProject.Models;
using CBProject.Models.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace CBProject.HelperClasses
{
    public class DataManagers : IDataManagers, IDisposable
    {
        private bool disposedValue;

        public readonly UserManager<ApplicationUser> UserManager;
        public readonly RoleManager<IdentityRole> RoleManager;
        public readonly ApplicationDbContext Context;

        public DataManagers(IUserStore<ApplicationUser> userManager, 
            IRoleStore<IdentityRole, string> roleManager, IContext context)
        {
            this.Context = (ApplicationDbContext)context;
            //this.UserManager = new UserManager<ApplicationUser>(userManager);
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.Context));
            this.RoleManager = new RoleManager<IdentityRole>(roleManager);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.UserManager.Dispose();
                    this.RoleManager.Dispose();
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}