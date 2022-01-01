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
    public class TagsToVideosRepository : IRepository<TagToVideo>, IDisposable
    {
        private bool disposedValue;
        private readonly ApplicationDbContext _context;
        public TagsToVideosRepository(IUnitOfWork unitOfWork)
        {
            this._context = unitOfWork.Context;
        }
        public void Add(TagToVideo obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.TagsToVideos.Add(obj);
        }
        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.TagsToVideos
                                    .FirstOrDefault(t => t.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.TagsToVideos.Remove(obj);
        }
        public async Task DeleteAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = await this._context.TagsToVideos
                                .FirstOrDefaultAsync(t => t.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.TagsToVideos.Remove(obj);
        }
        public TagToVideo Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.TagsToVideos
                                    .Include(t => t.Video)
                                    .Include(T => T.Tag)
                                    .FirstOrDefault(T => T.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public ICollection<TagToVideo> GetAll()
        {
            return this._context.TagsToVideos
                                .Include(t => t.Video)
                                .Include(t => t.Tag)
                                .ToList();
        }
        public async Task<ICollection<TagToVideo>> GetAllAsync()
        {
            return await this._context.TagsToVideos
                                        .Include(t => t.Video)
                                        .Include(t => t.Tag)
                                        .ToListAsync();
                                    
        }
        public ICollection<TagToVideo> GetAllEmpty()
        {
            return this._context.TagsToVideos
                                .ToList();
        }
        public async Task<ICollection<TagToVideo>> GetAllEmptyAsync()
        {
            return await this._context.TagsToVideos
                                        .ToListAsync();
        }
        public IQueryable<TagToVideo> GetAllQueryable()
        {
            return this._context.TagsToVideos;
        }
        public async Task<TagToVideo> GetAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = await this._context.TagsToVideos
                                        .Include(t => t.Video)
                                        .Include(t => t.Tag)
                                        .FirstOrDefaultAsync(t => t.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public TagToVideo GetEmpty(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.TagsToVideos
                                    .FirstOrDefault(t => t.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public async Task<TagToVideo> GetEmptyAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = await this._context.TagsToVideos
                                            .FirstOrDefaultAsync(t => t.ID == id);
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
        public void Update(TagToVideo obj)
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