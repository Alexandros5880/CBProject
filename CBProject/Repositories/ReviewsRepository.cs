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
                .FirstOrDefault(r => r.ID == id);
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
                .SingleOrDefault(r=>r.ID == id);
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
                .FirstOrDefaultAsync(r => r.ID == id);
        }
        public async Task<Review> GetAsync(int? id)
        {
            return await this._context.Reviews
                .Include(r => r.Video)
                .Include(r => r.Reviewer)
                .FirstOrDefaultAsync(r => r.ID == id);
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
        public ICollection<Review> GetAllOtherFromVideo(Video video)
        {
            if (video == null)
                throw new ArgumentNullException(nameof(video));
            return this._context.Reviews
                .Where(r => !video.Reviews.Contains(r))
                .ToList();
        }
        public async Task<ICollection<Review>> GetAllOtherFromVideoAsync(Video video)
        {
            if (video == null)
                throw new ArgumentNullException(nameof(video));
            return await this._context.Reviews
                .Where(r => !video.Reviews.Contains(r))
                .ToListAsync();
        }
        public ICollection<Review> GetAllFromVideo(Video video)
        {
            if (video == null)
                throw new ArgumentNullException(nameof(video));
            return this._context.Reviews
                .Where(r => video.Reviews.Contains(r))
                .ToList();
        }
        public async Task<ICollection<Review>> GetAllFromVideoAsync(Video video)
        {
            if (video == null)
                throw new ArgumentNullException(nameof(video));
            return await this._context.Reviews
                .Where(r => video.Reviews.Contains(r))
                .ToListAsync();
        }
        public ICollection<Review> GetAllOtherFromEbook(Ebook ebook)
        {
            if (ebook == null)
                throw new ArgumentNullException(nameof(ebook));
            return this._context.Reviews
                .Where(r => !ebook.Reviews.Contains(r))
                .ToList();
        }
        public async Task<ICollection<Review>> GetAllOtherFromEbookAsync(Ebook ebook)
        {
            if (ebook == null)
                throw new ArgumentNullException(nameof(ebook));
            return await this._context.Reviews
                .Where(r => !ebook.Reviews.Contains(r))
                .ToListAsync();
        }
        public ICollection<Review> GetAllFromEbook(Ebook ebook)
        {
            if (ebook == null)
                throw new ArgumentNullException(nameof(ebook));
            return this._context.Reviews
                .Where(r => ebook.Reviews.Contains(r))
                .ToList();
        }
        public async Task<ICollection<Review>> GetAllFromEbookAsync(Ebook ebook)
        {
            if (ebook == null)
                throw new ArgumentNullException(nameof(ebook));
            return await this._context.Reviews
                .Where(r => ebook.Reviews.Contains(r))
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