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
    public class VideosRepository : IRepository<Video>, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly CategoriesRepository _categoriesRepository;
        private bool disposedValue;
        public VideosRepository(IUnitOfWork unitOfWork)
        {
            this._context = unitOfWork.Context;
            this._categoriesRepository = unitOfWork.Categories;
        }
        public ICollection<Video> GetVideosCC(string userId)
        {
            return this.GetAll()
                .Where(v => v.CreatorId == userId)
                .ToList();
        }
        public void Add(Video video)
        {
            if(video == null)
                throw new ArgumentNullException(nameof(video));

            this._context.Videos.Add(video);
        }
        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var video = this.Get(id);
            if (video == null)
                throw new ArgumentNullException(nameof(video));
            this._context.Videos.Remove(video);
        }
        public Video Get(int? id)
        {
            return this._context.Videos
                .Include(v=>v.Reviews)
                .Include(v => v.Ratings)
                .Include(v => v.Tags)
                .SingleOrDefault(v => v.ID == id);
        }
        public ICollection<Video> GetAll()
        {
            return this._context.Videos
                .Include(v => v.Reviews)
                .Include(v => v.Ratings)
                .Include(v => v.Tags)
                .ToList();
        }
        public ICollection<Video> GetAllEmpty()
        {
            
            return this._context.Videos.ToList();
        }
        public Video GetEmpty(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return this._context.Videos.Find(id);
        }
        public ICollection<Video> GetOtherVideosFromCategory(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var category = this._categoriesRepository.Get(id);
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            return _context.Videos
                .Include(v => v.Reviews)
                .Include(v => v.Ratings)
                .Include(v => v.Tags)
                .Where(v => !category.Videos.Contains(v))
                .ToList();
        }
        public ICollection<Video> GetVideosFromCategory(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var category = this._categoriesRepository.Get(id);
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            return _context.Videos
                .Include(v => v.Reviews)
                .Include(v => v.Ratings)
                .Include(v => v.Tags)
                .Where(v => category.Videos.Contains(v))
                .ToList();
        }
        public void Save()
        {
            this._context.SaveChanges();
        }
        public void Update(Video video)
        {
            if (video == null)
                throw new ArgumentNullException(nameof(video));
            this._context.Entry(video).State = EntityState.Modified;
        }
        public async Task<Video> GetAsync(int? id)
        {
            return await this._context.Videos
                .Include(v => v.Reviews)
                .Include(v => v.Ratings)
                .Include(v => v.Tags)
                .SingleOrDefaultAsync(v => v.ID == id);
        }
        public async Task<Video> GetEmptyAsync(int? id)
        {
            return await this._context.Videos
                .SingleOrDefaultAsync(v => v.ID == id);
        }
        public async Task<ICollection<Video>> GetAllAsync()
        {
            return await this._context.Videos
                .Include(v => v.Reviews)
                .Include(v => v.Ratings)
                .Include(v => v.Tags)
                .ToListAsync();
        }
        public async Task<ICollection<Video>> GetAllEmptyAsync()
        {
            return await this._context.Videos
                .ToListAsync();
        }
        public async Task<ICollection<Video>> GetOtherVideosFromCategoryAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var category = await this._categoriesRepository.GetAsync(id);
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            return await _context.Videos
                .Include(v => v.Reviews)
                .Include(v => v.Ratings)
                .Include(v => v.Tags)
                .Where(v => !category.Videos.Contains(v))
                .ToListAsync();
        }
        public async Task<ICollection<Video>> GetVideosFromCategoryAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var category = await this._categoriesRepository.GetAsync(id);
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            return await _context.Videos
                .Include(v => v.Reviews)
                .Include(v => v.Ratings)
                .Include(v => v.Tags)
                .Where(v => category.Videos.Contains(v))
                .ToListAsync();
        }
        public async Task<int> SaveAsync()
        {
            return await this._context.SaveChangesAsync();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this._context.Dispose();
                    this._categoriesRepository.Dispose();
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