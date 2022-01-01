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
    public class RatingsToVideosRepository : IRepository<RatingToVideo>, IDisposable
    {
        private bool disposedValue;
        private ApplicationDbContext _context { get; set; }
        public RatingsToVideosRepository(IUnitOfWork unitOfWork)
        {
            this._context = unitOfWork.Context;
        }
        public void Add(RatingToVideo obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.RatingsToVideos.Add(obj);
        }
        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var ratingToVideo = this._context.RatingsToVideos
                                    .FirstOrDefault(r => r.ID == id);
            if (ratingToVideo == null)
                throw new ArgumentNullException(nameof(ratingToVideo));
            this._context.RatingsToVideos.Remove(ratingToVideo);
        }
        public async Task DeleteAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var ratingToVideo = await this._context.RatingsToVideos
                                        .FirstOrDefaultAsync(r => r.ID == id);
            if (ratingToVideo == null)
                throw new ArgumentNullException(nameof(ratingToVideo));
            this._context.RatingsToVideos.Remove(ratingToVideo);
        }
        public RatingToVideo Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var ratingToVideo = this._context.RatingsToVideos
                                            .Include(r => r.Video)
                                            .Include(r => r.Rating)
                                            .FirstOrDefault(r => r.ID == id);
            if (ratingToVideo == null)
                throw new ArgumentNullException(nameof(ratingToVideo));
            return ratingToVideo;
        }
        public ICollection<RatingToVideo> GetAll()
        {
            return this._context.RatingsToVideos
                                .Include(r => r.Video)
                                .Include(r => r.Rating)
                                .ToList();
        }
        public async Task<ICollection<RatingToVideo>> GetAllAsync()
        {
            return await this._context.RatingsToVideos
                                .Include(r => r.Video)
                                .Include(r => r.Rating)
                                .ToListAsync();
        }
        public ICollection<RatingToVideo> GetAllEmpty()
        {
            return this._context.RatingsToVideos.ToList();
        }
        public async Task<ICollection<RatingToVideo>> GetAllEmptyAsync()
        {
            return await this._context.RatingsToVideos.ToListAsync();
        }
        public IQueryable<RatingToVideo> GetAllQueryable()
        {
            return this._context.RatingsToVideos;
        }
        public async Task<RatingToVideo> GetAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var  ratingToVideo = await this._context.RatingsToVideos
                                        .Include(r => r.Video)
                                        .Include(r => r.Rating)
                                        .FirstOrDefaultAsync(r => r.ID == id);
            if (ratingToVideo == null)
                throw new ArgumentNullException(nameof(ratingToVideo));
            return ratingToVideo;
        }
        public RatingToVideo GetEmpty(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var ratingToVideo = this._context.RatingsToVideos
                                .FirstOrDefault(r => r.ID == id);
            if (ratingToVideo == null)
                throw new ArgumentNullException(nameof(ratingToVideo));
            return ratingToVideo;
        }
        public async Task<RatingToVideo> GetEmptyAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var ratingToVideo = await this._context.RatingsToVideos
                                .FirstOrDefaultAsync(r => r.ID == id);
            if (ratingToVideo == null)
                throw new ArgumentNullException(nameof(ratingToVideo));
            return ratingToVideo;
        }
        public void Save()
        {
            this._context.SaveChanges();
        }
        public async Task<int> SaveAsync()
        {
            return await this._context.SaveChangesAsync();
        }
        public void Update(RatingToVideo obj)
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