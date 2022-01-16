using CBProject.Areas.Forum.Models.EntityModels;
using CBProject.Areas.Messenger.Repositories.Interfaces;
using CBProject.HelperClasses.Interfaces;
using CBProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CBProject.Areas.Messenger.Repositories
{
    public class MesMessagesRepository : IRepository<MessengerMessage>, IDisposable
    {
        private bool disposedValue;
        private readonly ApplicationDbContext _context;
        public MesMessagesRepository(IUnitOfWork unitOfWork)
        {
            this._context = unitOfWork.Context;
        }
        public void Add(MessengerMessage obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.MessengerMessages.Add(obj);
        }
        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.MessengerMessages
                        .Include(m => m.Group)
                        .Include(m => m.User)
                        .FirstOrDefault(g => g.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.MessengerMessages.Remove(obj);
        }
        public async Task DeleteAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = await this._context.MessengerMessages
                        .Include(m => m.Group)
                        .Include(m => m.User)
                        .FirstOrDefaultAsync(g => g.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.MessengerMessages.Remove(obj);
        }
        public MessengerMessage Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.MessengerMessages
                        .Include(m => m.Group)
                        .Include(m => m.User)
                        .FirstOrDefault(g => g.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public ICollection<MessengerMessage> GetAll()
        {
            return this._context.MessengerMessages
                        .Include(m => m.Group)
                        .Include(m => m.User)
                        .ToList();
        }
        public async Task<ICollection<MessengerMessage>> GetAllAsync()
        {
            return await this._context.MessengerMessages
                        .Include(m => m.Group)
                        .Include(m => m.User)
                        .ToListAsync();
        }
        public ICollection<MessengerMessage> GetAllEmpty()
        {
            return this._context.MessengerMessages
                                    .ToList();
        }
        public async Task<ICollection<MessengerMessage>> GetAllEmptyAsync()
        {
            return await this._context.MessengerMessages
                                        .ToListAsync();
        }
        public IQueryable<MessengerMessage> GetAllQueryable()
        {
            return this._context.MessengerMessages;
        }
        public async Task<MessengerMessage> GetAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = await this._context.MessengerMessages
                        .Include(m => m.Group)
                        .Include(m => m.User)
                        .FirstOrDefaultAsync(g => g.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public MessengerMessage GetEmpty(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.MessengerMessages
                        .FirstOrDefault(g => g.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public async Task<MessengerMessage> GetEmptyAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = await this._context.MessengerMessages
                        .FirstOrDefaultAsync(g => g.ID == id);
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
        public void Update(MessengerMessage obj)
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