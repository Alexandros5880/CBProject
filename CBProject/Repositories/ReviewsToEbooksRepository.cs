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
    public class ReviewsToEbooksRepository : IRepository<ReviewToEbook>, IDisposable
    {
        private bool disposedValue;
        private readonly ApplicationDbContext _context;
        public ReviewsToEbooksRepository(IUnitOfWork unitOfWork)
        {
            this._context = unitOfWork.Context;
        }
        public void Add(ReviewToEbook obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.ReviewsToEbooks.Add(obj);
        }
        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.ReviewsToEbooks
                                .FirstOrDefault(r => r.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.ReviewsToEbooks.Remove(obj);
        }
        public async Task DeleteAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = await this._context.ReviewsToEbooks
                                            .FirstOrDefaultAsync(r => r.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.ReviewsToEbooks.Remove(obj);
        }
        public ReviewToEbook Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.ReviewsToEbooks
                                    .Include(r => r.Ebook)
                                    .Include(r => r.Review)
                                    .FirstOrDefault(r => r.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public ICollection<ReviewToEbook> GetAll()
        {
            return this._context.ReviewsToEbooks
                                .Include(r => r.Ebook)
                                .Include(r => r.Review)
                                .ToList();
        }
        public async Task<ICollection<ReviewToEbook>> GetAllAsync()
        {
            return await this._context.ReviewsToEbooks
                                .Include(r => r.Ebook)
                                .Include(r => r.Review)
                                .ToListAsync();
        }
        public ICollection<ReviewToEbook> GetAllEmpty()
        {
            return this._context.ReviewsToEbooks
                                        .ToList();
        }
        public async Task<ICollection<ReviewToEbook>> GetAllEmptyAsync()
        {
            return await this._context.ReviewsToEbooks
                                        .ToListAsync();
        }
        public IQueryable<ReviewToEbook> GetAllQueryable()
        {
            return this._context.ReviewsToEbooks;
        }
        public async Task<ReviewToEbook> GetAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.ReviewsToEbooks
                                    .Include(r => r.Ebook)
                                    .Include(r => r.Review)
                                    .FirstOrDefault(r => r.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public ReviewToEbook GetEmpty(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.ReviewsToEbooks
                                    .FirstOrDefault(r => r.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public async Task<ReviewToEbook> GetEmptyAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = await this._context.ReviewsToEbooks
                                            .FirstOrDefaultAsync(R => R.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public void Save()
        {
            this._context.SaveChanges();
        }
        public async Task<int> SaveAsync()
        {
            return await this._context.SaveChangesAsync();
        }
        public void Update(ReviewToEbook obj)
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