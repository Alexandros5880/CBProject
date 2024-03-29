﻿using CBProject.HelperClasses.Interfaces;
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
    public class SubscriptionPackageRepository : IRepository<SubscriptionPackage>, IDisposable
    {
        private ApplicationDbContext _context;
        private bool disposedValue;
        public SubscriptionPackageRepository(IUnitOfWork unitOfWork)
        {
            this._context = unitOfWork.Context;
        }
        public void Add(SubscriptionPackage obj)
        {
            if(obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.SubcriptionPackages.Add(obj);
        }
        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.SubcriptionPackages.Find(id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.SubcriptionPackages.Remove(obj);
        }
        public async Task DeleteAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var sub = await this._context.SubcriptionPackages
                                .FirstOrDefaultAsync(s => s.ID == id);
            this._context.SubcriptionPackages.Remove(sub);
        }
        public SubscriptionPackage Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return this._context.SubcriptionPackages
                .Include(s => s.MyUsers)
                .FirstOrDefault(s => s.ID == id);
        }
        public ICollection<SubscriptionPackage> GetAll()
        {
            return this._context.SubcriptionPackages
                .Include(s => s.MyUsers)
                .ToList();
        }
        public async Task<ICollection<SubscriptionPackage>> GetAllAsync()
        {
            return await this._context.SubcriptionPackages
                .Include(s => s.MyUsers)
                .ToListAsync();
        }
        public ICollection<SubscriptionPackage> GetAllEmpty()
        {
            return this._context.SubcriptionPackages
                .ToList();
        }
        public async Task<ICollection<SubscriptionPackage>> GetAllEmptyAsync()
        {
            return await this._context.SubcriptionPackages
                .ToListAsync();
        }
        public async Task<SubscriptionPackage> GetAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return await this._context.SubcriptionPackages
                .Include(s => s.MyUsers)
                .FirstAsync(s => s.ID == id);
        }
        public SubscriptionPackage GetEmpty(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return this._context.SubcriptionPackages
                .FirstOrDefault(s => s.ID == id);
        }
        public async Task<SubscriptionPackage> GetEmptyAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var packages = await this._context.SubcriptionPackages
                                .FirstOrDefaultAsync(s => s.ID == id);
            return packages;
        }
        public void Save()
        {
            this._context.SaveChanges();
        }
        public async Task<int> SaveAsync()
        {
            return await this._context.SaveChangesAsync();
        }
        public void Update(SubscriptionPackage obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.Entry(obj).State = EntityState.Modified;
        }
        public IQueryable<SubscriptionPackage> GetAllQueryable()
        {
            return this._context.SubcriptionPackages;
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