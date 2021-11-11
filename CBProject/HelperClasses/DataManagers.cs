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

        public readonly ApplicationDbContext Context;
        public readonly RoleStore<IdentityRole> RoleStore;
        public readonly RoleManager<IdentityRole> RoleManager;
        public readonly UserStore<ApplicationUser> UserStore;
        public readonly UserManager<ApplicationUser> UserManager;
        

        public DataManagers(IContext context)
        {
            this.Context = (ApplicationDbContext)context;
            this.RoleStore = new RoleStore<IdentityRole>(this.Context);
            this.UserStore = new UserStore<ApplicationUser>(this.Context);
            this.RoleManager = new RoleManager<IdentityRole>(this.RoleStore);
            this.UserManager = new UserManager<ApplicationUser>(this.UserStore);
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