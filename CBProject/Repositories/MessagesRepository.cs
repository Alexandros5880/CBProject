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
    public class MessagesRepository : IRepository<ContactMessage>, IDisposable
    {
        private bool disposedValue;
        private readonly ApplicationDbContext _context;
        public MessagesRepository(IUnitOfWork unitOfWork)
        {
            this._context = unitOfWork.Context;
        }
        public void Add(ContactMessage obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.ContactMessages.Add(obj);
        }
        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this.Get(id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.ContactMessages.Remove(obj);
        }
        public async Task DeleteAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = await this.GetAsync(id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.ContactMessages.Remove(obj);
        }
        public ContactMessage Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.ContactMessages
                            .Include(m => m.User)
                            .FirstOrDefault(m => m.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public ICollection<ContactMessage> GetAll()
        {
            return this._context.ContactMessages
                                .OrderBy(m => m.UploatedDate)
                                .Include(m => m.User)
                                .ToList();
        }
        public async Task<ICollection<ContactMessage>> GetAllAsync()
        {
            return await this._context.ContactMessages
                                    .OrderBy(m => m.UploatedDate)
                                    .Include(m => m.User)
                                    .ToListAsync();
        }
        public ICollection<ContactMessage> GetAllEmpty()
        {
            return this._context.ContactMessages
                            .OrderBy(m => m.UploatedDate)
                            .ToList();
        }
        public async Task<ICollection<ContactMessage>> GetAllEmptyAsync()
        {
            return await this._context.ContactMessages
                                    .OrderBy(m => m.UploatedDate)
                                    .ToListAsync();
        }
        public IQueryable<ContactMessage> GetAllQueryable()
        {
            return this._context.ContactMessages;
        }
        public async Task<ContactMessage> GetAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = await this._context.ContactMessages
                                        .Include(m => m.User)
                                        .FirstOrDefaultAsync(m => m.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public ContactMessage GetEmpty(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.ContactMessages
                                        .FirstOrDefault(m => m.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public async Task<ContactMessage> GetEmptyAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = await this._context.ContactMessages
                                        .FirstOrDefaultAsync(m => m.ID == id);
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
        public void Update(ContactMessage obj)
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