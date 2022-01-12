using CBProject.HelperClasses.Interfaces;
using CBProject.Models;
using CBProject.Models.EntityModels;
using CBProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CBProject.Areas.Forum.Repositories
{
    public class ForumMessagesRepository : IRepository<ForumMessage>, IDisposable
    {
        private bool disposedValue;
        private readonly ApplicationDbContext _context;
        public ForumMessagesRepository(IUnitOfWork unitOfWork)
        {
            this._context = unitOfWork.Context;
        }
        public void Add(ForumMessage obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.ForumMessages.Add(obj);
        }
        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.ForumMessages
                                    .FirstOrDefault(f => f.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.ForumMessages.Remove(obj);
        }
        public async Task DeleteAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = await this._context.ForumMessages
                                    .FirstOrDefaultAsync(f => f.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.ForumMessages.Remove(obj);
        }
        public ForumMessage Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.ForumMessages
                                    .Include(f => f.User)
                                    .FirstOrDefault(f => f.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public ICollection<ForumMessage> GetAll()
        {
            return this._context.ForumMessages
                                .Include(f => f.User)
                                .ToList();
        }
        public async Task<ICollection<ForumMessage>> GetAllAsync()
        {
            return await this._context.ForumMessages
                                .Include(f => f.User)
                                .ToListAsync();
        }
        public ICollection<ForumMessage> GetAllEmpty()
        {
            return this._context.ForumMessages
                                .ToList();
        }
        public async Task<ICollection<ForumMessage>> GetAllEmptyAsync()
        {
            return await this._context.ForumMessages
                                        .ToListAsync();
        }
        public IQueryable<ForumMessage> GetAllQueryable()
        {
            return this._context.ForumMessages;
        }
        public async Task<ForumMessage> GetAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = await this._context.ForumMessages
                                    .Include(f => f.User)
                                    .FirstOrDefaultAsync(f => f.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public ForumMessage GetEmpty(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.ForumMessages
                                    .FirstOrDefault(f => f.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public async Task<ForumMessage> GetEmptyAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = await this._context.ForumMessages
                                    .FirstOrDefaultAsync(f => f.ID == id);
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
        public void Update(ForumMessage obj)
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