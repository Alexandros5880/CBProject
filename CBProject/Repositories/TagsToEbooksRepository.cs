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
    public class TagsToEbooksRepository : IRepository<TagToEbook>, IDisposable
    {
        private bool disposedValue;
        private readonly ApplicationDbContext _context;
        public TagsToEbooksRepository(IUnitOfWork unitOfWork)
        {
            this._context = unitOfWork.Context;
        }
        public void Add(TagToEbook obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.TagsToEbooks.Add(obj);
        }
        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.TagsToEbooks
                                    .FirstOrDefault(t => t.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.TagsToEbooks.Remove(obj);
        }
        public async Task DeleteAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = await this._context.TagsToEbooks
                                            .FirstOrDefaultAsync(t => t.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.TagsToEbooks.Remove(obj);
        }
        public TagToEbook Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.TagsToEbooks
                                    .Include(t => t.Ebook)
                                    .Include(t => t.Tag)
                                    .FirstOrDefault(t => t.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public ICollection<TagToEbook> GetAll()
        {
            return this._context.TagsToEbooks
                                .Include(t => t.Ebook)
                                .Include(t => t.Tag)
                                .ToList();
        }
        public async Task<ICollection<TagToEbook>> GetAllAsync()
        {
            return await this._context.TagsToEbooks
                                        .Include(t => t.Ebook)
                                        .Include(T => T.Tag)
                                        .ToListAsync();
        }
        public ICollection<TagToEbook> GetAllEmpty()
        {
            return this._context.TagsToEbooks
                                .ToList();
        }
        public async Task<ICollection<TagToEbook>> GetAllEmptyAsync()
        {
            return await this._context.TagsToEbooks
                                        .ToListAsync();
        }
        public IQueryable<TagToEbook> GetAllQueryable()
        {
            return this._context.TagsToEbooks;
        }
        public async Task<TagToEbook> GetAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = await this._context.TagsToEbooks
                                            .Include(t => t.Ebook)
                                            .Include(t => t.Tag)
                                            .FirstOrDefaultAsync(r => r.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public TagToEbook GetEmpty(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.TagsToEbooks
                                    .FirstOrDefault(t => t.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public async Task<TagToEbook> GetEmptyAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = await this._context.TagsToEbooks
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
        public void Update(TagToEbook obj)
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