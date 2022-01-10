using CBProject.HelperClasses.Interfaces;
using CBProject.Models;
using CBProject.Models.EntityModels;
using CBProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CBProject.Repositories
{
    public class UsersSubscriptionPackagesRepo : IRepository<UserSubscriptionPackage>, IDisposable
    {
        private bool disposedValue;
        private readonly ApplicationDbContext _context;
        public UsersSubscriptionPackagesRepo(IUnitOfWork unitOfWork)
        {
            this._context = unitOfWork.Context;
        }
        public void Add(UserSubscriptionPackage obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.UsersSubscriptionPackages.Add(obj);
        }
        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.UsersSubscriptionPackages
                                .FirstOrDefault(u => u.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.UsersSubscriptionPackages.Remove(obj);
        }
        public async Task DeleteAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = await this._context.UsersSubscriptionPackages
                                            .FirstOrDefaultAsync(u => u.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.UsersSubscriptionPackages.Remove(obj);
        }
        public UserSubscriptionPackage Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return this._context.UsersSubscriptionPackages
                                    .Include(u => u.SubscriptionPackage)
                                    .Include(u => u.User)
                                    .FirstOrDefault(u => u.ID == id);
        }
        public ICollection<UserSubscriptionPackage> GetAll()
        {
            return this._context.UsersSubscriptionPackages
                                    .Include(u => u.SubscriptionPackage)
                                    .Include(u => u.User)
                                    .ToList();
        }
        public async Task<ICollection<UserSubscriptionPackage>> GetAllAsync()
        {
            return await this._context.UsersSubscriptionPackages
                                        .Include(u => u.SubscriptionPackage)
                                        .Include(u => u.User)
                                        .ToListAsync();
        }
        public ICollection<UserSubscriptionPackage> GetAllEmpty()
        {
            return this._context.UsersSubscriptionPackages
                                            .ToList();
        }
        public async Task<ICollection<UserSubscriptionPackage>> GetAllEmptyAsync()
        {
            return await this._context.UsersSubscriptionPackages
                                            .ToListAsync();
        }
        public IQueryable<UserSubscriptionPackage> GetAllQueryable()
        {
            return this._context.UsersSubscriptionPackages;
        }
        public async Task<UserSubscriptionPackage> GetAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return await this._context.UsersSubscriptionPackages
                                        .Include(u => u.SubscriptionPackage)
                                        .Include(u => u.User)
                                        .FirstOrDefaultAsync(u => u.ID == id);
        }
        public UserSubscriptionPackage GetEmpty(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return this._context.UsersSubscriptionPackages
                                    .FirstOrDefault(u => u.ID == id);
        }
        public async Task<UserSubscriptionPackage> GetEmptyAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return await this._context.UsersSubscriptionPackages
                                    .FirstOrDefaultAsync(u => u.ID == id);
        }
        public void Save()
        {
            this._context.SaveChanges();
        }
        public async Task<int> SaveAsync()
        {
            return await this._context.SaveChangesAsync();
        }
        public void Update(UserSubscriptionPackage obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.Entry(obj).State = EntityState.Modified;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this._context.Dispose();
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