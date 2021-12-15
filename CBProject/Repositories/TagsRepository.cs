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
    public class TagsRepository : IRepository<Tag>, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private bool disposedValue;
        public TagsRepository(IUnitOfWork unitOfWork)
        {
            this._context = unitOfWork.Context;
        }
        public void Add(Tag tag)
        {
            if (tag == null)
                throw new ArgumentNullException(nameof(tag));
            this._context.Tags.Add(tag);
        }
        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var tag = this.Get(id);
            if (tag == null)
                throw new Exception("Tag Not Found");
            this._context.Tags.Remove(tag);
        }
        public Tag Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return this._context.Tags
                .SingleOrDefault(t=>t.ID == id);
        }
        public ICollection<Tag> GetAll()
        {
            return this._context.Tags
                .ToList();
        }       
        public ICollection<Tag> GetAllEmpty()
        {
            return this._context.Tags.ToList();
        }      
        public Tag GetEmpty(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return this._context.Tags
                .FirstOrDefault(t => t.ID == id);
        }        
        public void Save()
        {
            this._context.SaveChanges();
        }       
        public void Update(Tag tag)
        {
            if (tag == null)
                throw new ArgumentNullException(nameof(tag));
            this._context.Entry(tag).State = EntityState.Modified;
        }
        public async Task<int> SaveAsync()
        {
            return await this._context.SaveChangesAsync();
        }
        public async Task<Tag> GetEmptyAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return await this._context.Tags
                .SingleOrDefaultAsync(t => t.ID == id);
        }
        public async Task<Tag> GetAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return await this._context.Tags
                .SingleOrDefaultAsync(t => t.ID == id);
        }
        public async Task<ICollection<Tag>> GetAllEmptyAsync()
        {
            return await this._context.Tags
                .ToListAsync();
        }
        public async Task<ICollection<Tag>> GetAllAsync()
        {
            return await this._context.Tags
                .ToListAsync();
        }
        public ICollection<Tag> GetAllOtherFromVideo(Video video)
        {
            if (video == null)
                throw new ArgumentNullException(nameof(video));
            return this._context.Tags
                .Where(t => !video.Tags.Contains(t))
                .ToList();
        }
        public async Task<ICollection<Tag>> GetAllOtherFromVideoAsync(Video video)
        {
            if (video == null)
                throw new ArgumentNullException(nameof(video));
            return await this._context.Tags
                .Where(t => !video.Tags.Contains(t))
                .ToListAsync();
        }
        public ICollection<Tag> GetAllFromVideo(Video video)
        {
            if (video == null)
                throw new ArgumentNullException(nameof(video));
            return this._context.Tags
                .Where(t => video.Tags.Contains(t))
                .ToList();
        }
        public async Task<ICollection<Tag>> GetAllFromVideoAsync(Video video)
        {
            if (video == null)
                throw new ArgumentNullException(nameof(video));
            return await this._context.Tags
                .Where(t => video.Tags.Contains(t))
                .ToListAsync();
        }
        public ICollection<Tag> GetAllOtherFromEbook(Ebook ebook)
        {
            if (ebook == null)
                throw new ArgumentNullException(nameof(ebook));
            return this._context.Tags
                .Where(t => !ebook.Tags.Contains(t))
                .ToList();
        }
        public async Task<ICollection<Tag>> GetAllOtherFromEbookAsync(Ebook ebook)
        {
            if (ebook == null)
                throw new ArgumentNullException(nameof(ebook));
            return await this._context.Tags
                .Where(t => !ebook.Tags.Contains(t))
                .ToListAsync();
        }
        public ICollection<Tag> GetAllFromEbook(Ebook ebook)
        {
            if (ebook == null)
                throw new ArgumentNullException(nameof(ebook));
            return this._context.Tags
                .Where(t => ebook.Tags.Contains(t))
                .ToList();
        }
        public async Task<ICollection<Tag>> GetAllFromEbookAsync(Ebook ebook)
        {
            if (ebook == null)
                throw new ArgumentNullException(nameof(ebook));
            return await this._context.Tags
                .Where(t => ebook.Tags.Contains(t))
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