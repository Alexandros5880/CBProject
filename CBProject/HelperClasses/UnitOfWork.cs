using CBProject.HelperClasses.Interfaces;
using CBProject.Models;
using CBProject.Repositories;
using CBProject.Repositories.IdentityRepos;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace CBProject.HelperClasses
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool disposedValue;
        public ApplicationDbContext Context { get; protected set; }
        public RoleStore<ApplicationRole> RoleStore { get; protected set; }
        public RoleManager<ApplicationRole> RoleManager { get; protected set; }
        public UserStore<ApplicationUser> UserStore { get; protected set; }
        public UserManager<ApplicationUser> UserManager { get; protected set; }
        public CategoriesRepository Categories { get; protected set; }
        public CategoryToCategoryRepository CategoryToCategory { get; protected set; }
        public ContentTypeRepository ContentTypes { get; protected set; }
        public VideosRepository Videos { get; protected set; }
        public RatingsRepository Ratings { get; protected set; }
        public ReviewsRepository Reviews { get; protected set; }
        public TagsRepository Tags { get; protected set; }
        public EbooksRepository Ebooks { get; protected set; }
        public SubscriptionPackageRepository SubscriptionPackages { get; protected set; }
        public PaymentsRepository Payments { get; protected set; }
        public OrdersRepository Orders { get; protected set; }
        public UnitOfWork(IApplicationDbContext context)
        {
            this.Context = (ApplicationDbContext)context;
            this.RoleStore = new RoleStore<ApplicationRole>(this.Context);
            this.UserStore = new UserStore<ApplicationUser>(this.Context);
            this.RoleManager = new RoleManager<ApplicationRole>(this.RoleStore);
            this.UserManager = new UserManager<ApplicationUser>(this.UserStore);
            this.CategoryToCategory = new CategoryToCategoryRepository(this);
            this.Categories = new CategoriesRepository(this);
            this.ContentTypes = new ContentTypeRepository(this);
            this.Videos = new VideosRepository(this);
            this.Ratings = new RatingsRepository(this);
            this.Reviews = new ReviewsRepository(this);
            this.Tags = new TagsRepository(this);
            this.Ebooks = new EbooksRepository(this);
            this.SubscriptionPackages = new SubscriptionPackageRepository(this);
            this.Payments = new PaymentsRepository(this);
            this.Orders = new OrdersRepository(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.Context.Dispose();
                    this.RoleStore.Dispose();
                    this.RoleManager.Dispose();
                    this.UserStore.Dispose();
                    this.UserManager.Dispose();
                    this.Categories.Dispose();
                    this.CategoryToCategory.Dispose();
                    this.ContentTypes.Dispose();
                    this.Videos.Dispose();
                    this.Ratings.Dispose();
                    this.Reviews.Dispose();
                    this.Tags.Dispose();
                    this.Ebooks.Dispose();
                    this.Payments.Dispose();
                    this.Orders.Dispose();
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