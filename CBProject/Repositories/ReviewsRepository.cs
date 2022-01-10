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
            review.CreatedDate = DateTime.Now;
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
        public async Task DeleteAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var review = await this._context.Reviews
                                            .FirstOrDefaultAsync(r => r.ID == id);
            this._context.Reviews.Remove(review);
        }
        public async Task DeleteAllAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var review = this.Get(id);
            if (review == null)
                throw new Exception("Tag Not Found");
            var reviewsToEbooks = await this._context.ReviewsToEbooks
                                .Where(t => t.ReviewId == id)
                                .ToListAsync();
            var reviewsToVideos = await this._context.ReviewsToVideos
                                .Where(t => t.ReviewId == id)
                                .ToListAsync();
            foreach (var record in reviewsToEbooks)
            {
                this._context.ReviewsToEbooks.Remove(record);
            }
            foreach (var record in reviewsToVideos)
            {
                this._context.ReviewsToVideos.Remove(record);
            }
            this._context.Reviews.Remove(review);
        }
        public Review Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return this._context.Reviews
                .Include(r => r.Reviewer)
                .FirstOrDefault(r => r.ID == id);
        }
        public ICollection<Review> GetAll()
        {
            return this._context.Reviews
                .Include(r=>r.Reviewer)
                .OrderBy(r => r.CreatedDate)
                .ToList();
        }        
        public ICollection<Review> GetAllEmpty()
        {
            return this._context.Reviews
                        .OrderBy(r => r.CreatedDate)
                        .ToList();
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
                .Include(r => r.Reviewer)
                .FirstOrDefaultAsync(r => r.ID == id);
        }
        public async Task<ICollection<Review>> GetAllEmptyAsync()
        {
            return await this._context.Reviews
                                .OrderBy(r => r.CreatedDate)
                                .ToListAsync();
        }
        public async Task<ICollection<Review>> GetAllAsync()
        {
            return await this._context.Reviews
                            .OrderBy(r => r.CreatedDate)
                            .Include(r => r.Reviewer)
                            .ToListAsync();
        }
        public ICollection<Review> GetAllOtherFromVideo(Video video)
        {
            if (video == null)
                throw new ArgumentNullException(nameof(video));
            var reviewsIds = this._context.ReviewsToVideos
                                        .Where(r => r.VideoId != video.ID)
                                        .Select(r => r.ReviewId)
                                        .ToList();
            return this._context.Reviews
                                .Where(r => reviewsIds.Contains(r.ID))
                                .OrderBy(r => r.CreatedDate)
                                .ToList();
        }
        public async Task<ICollection<Review>> GetAllOtherFromVideoAsync(Video video)
        {
            if (video == null)
                throw new ArgumentNullException(nameof(video));
            var reviewsIds = await this._context.ReviewsToVideos
                                        .Where(r => r.VideoId != video.ID)
                                        .Select(r => r.ReviewId)
                                        .ToListAsync();
            return await this._context.Reviews
                                .Where(r => reviewsIds.Contains(r.ID))
                                .OrderBy(r => r.CreatedDate)
                                .ToListAsync();
        }
        public ICollection<Review> GetAllFromVideo(Video video)
        {
            if (video == null)
                throw new ArgumentNullException(nameof(video));
            var reviewsIds = this._context.ReviewsToVideos
                                        .Where(r => r.VideoId == video.ID)
                                        .Select(r => r.ReviewId)
                                        .ToList();
            return this._context.Reviews
                                .Where(r => reviewsIds.Contains(r.ID))
                                .OrderBy(r => r.CreatedDate)
                                .ToList();
        }
        public async Task<ICollection<Review>> GetAllFromVideoAsync(Video video)
        {
            if (video == null)
                throw new ArgumentNullException(nameof(video));
            var reviewsIds = await this._context.ReviewsToVideos
                                        .Where(r => r.VideoId == video.ID)
                                        .Select(r => r.ReviewId)
                                        .ToListAsync();
            return await this._context.Reviews
                                .Where(r => reviewsIds.Contains(r.ID))
                                .OrderBy(r => r.CreatedDate)
                                .ToListAsync();
        }
        public ICollection<Review> GetAllOtherFromEbook(Ebook ebook)
        {
            if (ebook == null)
                throw new ArgumentNullException(nameof(ebook));
            var reviewsIds = this._context.ReviewsToEbooks
                                        .Where(r => r.EbookId != ebook.ID)
                                        .Select(r => r.ReviewId)
                                        .ToList();
            return this._context.Reviews
                                .Where(r => reviewsIds.Contains(r.ID))
                                .OrderBy(r => r.CreatedDate)
                                .ToList();
        }
        public async Task<ICollection<Review>> GetAllOtherFromEbookAsync(Ebook ebook)
        {
            if (ebook == null)
                throw new ArgumentNullException(nameof(ebook));
            var reviewsIds = await this._context.ReviewsToEbooks
                                        .Where(r => r.EbookId != ebook.ID)
                                        .Select(r => r.ReviewId)
                                        .ToListAsync();
            return await this._context.Reviews
                                .Where(r => reviewsIds.Contains(r.ID))
                                .OrderBy(r => r.CreatedDate)
                                .ToListAsync();
        }
        public ICollection<Review> GetAllFromEbook(Ebook ebook)
        {
            if (ebook == null)
                throw new ArgumentNullException(nameof(ebook));
            var reviewsIds = this._context.ReviewsToEbooks
                                        .Where(r => r.EbookId == ebook.ID)
                                        .Select(r => r.ReviewId)
                                        .ToList();
            return this._context.Reviews
                                .Where(r => reviewsIds.Contains(r.ID))
                                .OrderBy(r => r.CreatedDate)
                                .ToList();
        }
        public async Task<ICollection<Review>> GetAllFromEbookAsync(Ebook ebook)
        {
            if (ebook == null)
                throw new ArgumentNullException(nameof(ebook));
            var reviewsIds = await this._context.ReviewsToEbooks
                                        .Where(r => r.EbookId == ebook.ID)
                                        .Select(r => r.ReviewId)
                                        .ToListAsync();
            return await this._context.Reviews
                                .Where(r => reviewsIds.Contains(r.ID))
                                .OrderBy(r => r.CreatedDate)
                                .ToListAsync();
        }
        public IQueryable<Review> GetAllQueryable()
        {
            return this._context.Reviews;
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