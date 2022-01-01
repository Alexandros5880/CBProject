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
    public class ReviewsToVideosRepository : IRepository<ReviewToVideo>, IDisposable
    {
        private bool disposedValue;
        private readonly ApplicationDbContext _context;
        public ReviewsToVideosRepository(IUnitOfWork unitOfWork)
        {
            this._context = unitOfWork.Context;
        }
        public void Add(ReviewToVideo obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.ReviewsToVideos.Add(obj);
        }
        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.ReviewsToVideos
                                    .FirstOrDefault(r => r.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.ReviewsToVideos.Remove(obj);
        }
        public async Task DeleteAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = await this._context.ReviewsToVideos
                                        .FirstOrDefaultAsync(r => r.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.ReviewsToVideos.Remove(obj);
        }
        public ReviewToVideo Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.ReviewsToVideos
                                    .FirstOrDefault(r => r.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public ICollection<ReviewToVideo> GetAll()
        {
            return this._context.ReviewsToVideos
                                .Include(r => r.Video)
                                .Include(r => r.Review)
                                .ToList();
        }
        public async Task<ICollection<ReviewToVideo>> GetAllAsync()
        {
            return await this._context.ReviewsToVideos
                                        .Include(r => r.Video)
                                        .Include(r => r.Review)
                                        .ToListAsync();
        }
        public ICollection<ReviewToVideo> GetAllEmpty()
        {
            return this._context.ReviewsToVideos
                                .ToList();
        }
        public async Task<ICollection<ReviewToVideo>> GetAllEmptyAsync()
        {
            return await this._context.ReviewsToVideos
                                        .ToListAsync();
        }
        public IQueryable<ReviewToVideo> GetAllQueryable()
        {
            return this._context.ReviewsToVideos;
        }
        public async Task<ReviewToVideo> GetAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = await this._context.ReviewsToVideos
                                            .Include(r => r.Video)
                                            .Include(r => r.Review)
                                            .FirstOrDefaultAsync(r => r.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public ReviewToVideo GetEmpty(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.ReviewsToVideos
                            .FirstOrDefault(r => r.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public async Task<ReviewToVideo> GetEmptyAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = await this._context.ReviewsToVideos
                                        .FirstOrDefaultAsync(r => r.ID == id);
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
        public void Update(ReviewToVideo obj)
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