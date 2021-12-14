using CBProject.HelperClasses.Interfaces;
using CBProject.Models;
using CBProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CBProject.Repositories
{
    public class ReviewsRepository : IRepository<Review>, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private bool disposedValue;
        public ReviewsRepository(IUnitOfWork unitOfWork)
        {
            this._context = unitOfWork.Context;
        }
        public void Add(Review review)
        {
            if (review == null)
                throw new ArgumentNullException(nameof(review));
            this._context.Reviews.Add(review);
        }        
        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var review = this.Get(id);
            if (review == null)
                throw new ArgumentNullException(nameof(review));
            this._context.Reviews.Remove(review);
        }
        public Review Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return this._context.Reviews
                .Include(r => r.Video)
                .Include(r => r.Reviewer)
                .FirstOrDefault(r => r.Id == id);
        }
        public ICollection<Review> GetAll()
        {
            return this._context.Reviews
                .Include(r=>r.Video)
                .Include(r=>r.Reviewer)
                .ToList();
        }        
        public ICollection<Review> GetAllEmpty()
        {
            return this._context.Reviews.ToList();
        }        
        public Review GetEmpty(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return this._context.Reviews
                .SingleOrDefault(r=>r.Id == id);
        }        
        public void Save()
        {
            this._context.SaveChanges();
        }        
        public void Update(Review review)
        {
            if (review == null)
                throw new ArgumentNullException(nameof(review));
            this._context.Entry(review).State = EntityState.Modified;
        }
        public async Task<int> SaveAsync()
        {
            return await this._context.SaveChangesAsync();
        }
        public async Task<Review> GetEmptyAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return await this._context.Reviews
                .FirstOrDefaultAsync(r => r.Id == id);
        }
        public async Task<Review> GetAsync(int? id)
        {
            return await this._context.Reviews
                .Include(r => r.Video)
                .Include(r => r.Reviewer)
                .FirstOrDefaultAsync(r => r.Id == id);
        }
        public async Task<ICollection<Review>> GetAllEmptyAsync()
        {
            return await this._context.Reviews
                .ToListAsync();
        }
        public async Task<ICollection<Review>> GetAllAsync()
        {
            return await this._context.Reviews
                .Include(r => r.Video)
                .Include(r => r.Reviewer)
                .ToListAsync();
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