using CBProject.HelperClasses.Interfaces;
using CBProject.Models;
using CBProject.Models.EntityModels;
using CBProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CBProject.Repositories
{
    public class ContentTypeRepository : IRepository<ContentType>
    {
        private ApplicationDbContext _context;
        public ContentTypeRepository(IUnitOfWork manager)
        {
            this._context = manager.Context;
        }
        public void Add(ContentType obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.ContentTypes.Add(obj); 
        }

        public void Update(ContentType obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var contentType = this._context.ContentTypes.FirstOrDefault(c => c.ID == id);
            if (contentType == null)
                throw new ArgumentNullException(nameof(contentType));
            this._context.ContentTypes.Remove(contentType);
        }

        public ContentType Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var contentType = this._context.ContentTypes.FirstOrDefault(c => c.ID == id);
            if (contentType == null)
                throw new ArgumentNullException(nameof(contentType));
            return contentType;
        }

        public async Task<ContentType> GetAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var contentType = await this._context.ContentTypes.FirstOrDefaultAsync(c => c.ID == id);
            if (contentType == null)
                throw new ArgumentNullException(nameof(contentType));
            return contentType;
        }

        public ContentType GetEmpty(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var contentType = this._context.ContentTypes.FirstOrDefault(c => c.ID == id);
            if (contentType == null)
                throw new ArgumentNullException(nameof(contentType));
            return contentType;
        }

        public async Task<ContentType> GetEmptyAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var contentType = await this._context.ContentTypes.FirstOrDefaultAsync(c => c.ID == id);
            if (contentType == null)
                throw new ArgumentNullException(nameof(contentType));
            return contentType;
        }

        public ICollection<ContentType> GetAll()
        {
            return this._context.ContentTypes.ToList();
        }

        public async Task<ICollection<ContentType>> GetAllAsync()
        {
            return await this._context.ContentTypes.ToListAsync();
        }

        public ICollection<ContentType> GetAllEmpty()
        {
            return this._context.ContentTypes.ToList();
        }

        public async Task<ICollection<ContentType>> GetAllEmptyAsync()
        {
            return await this._context.ContentTypes.ToListAsync();
        }

        public void Save()
        {
            this._context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
           return await this._context.SaveChangesAsync();
        }

    }
}