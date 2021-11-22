using CBProject.HelperClasses.Interfaces;
using CBProject.Models;
using CBProject.Models.Interfaces;
using CBProject.Repositories;
using CBProject.Repositories.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace CBProject.HelperClasses
{
    public class DataManagers : IDataManagers, IDisposable
    {
        private bool disposedValue;

        public ApplicationDbContext Context { get; protected set; }
        public RoleStore<IdentityRole> RoleStore { get; protected set; }
        public RoleManager<IdentityRole> RoleManager { get; protected set; }
        public UserStore<ApplicationUser> UserStore { get; protected set; }
        public UserManager<ApplicationUser> UserManager { get; protected set; }
        public IRepository<Video> Videos { get; protected set; }
        public IRepository<Rating> Ratings { get; protected set; }


        public DataManagers(IContext context)
        {
            this.Context = (ApplicationDbContext)context;
            this.RoleStore = new RoleStore<IdentityRole>(this.Context);
            this.UserStore = new UserStore<ApplicationUser>(this.Context);
            this.RoleManager = new RoleManager<IdentityRole>(this.RoleStore);
            this.UserManager = new UserManager<ApplicationUser>(this.UserStore);
            this.Videos = new VideosRepository(this.Context);
            this.Ratings = new RatingsRepository(this.Context);
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