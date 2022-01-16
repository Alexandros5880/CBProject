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
    public class MesGroupsRepository : IRepository<MessengerGroup>, IDisposable
    {
        private bool disposedValue;
        private readonly ApplicationDbContext _context;
        public MesGroupsRepository(IUnitOfWork unitOfWork)
        {
            this._context = unitOfWork.Context;
        }
        public void Add(MessengerGroup obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.MessengerGroups.Add(obj);
        }
        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.MessengerGroups
                        .FirstOrDefault(g => g.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.MessengerGroups.Remove(obj);
        }
        public async Task DeleteAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = await this._context.MessengerGroups
                        .FirstOrDefaultAsync(g => g.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.MessengerGroups.Remove(obj);
        }
        public MessengerGroup Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.MessengerGroups
                        .Include(g => g.Users)
                        .Include(g => g.Messages)
                        .FirstOrDefault(g => g.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public ICollection<MessengerGroup> GetAll()
        {
            return this._context.MessengerGroups
                                .Include(g => g.Users)
                                .Include(g => g.Messages)
                                .ToList();
        }
        public async Task<ICollection<MessengerGroup>> GetAllAsync()
        {
            return await this._context.MessengerGroups
                                        .Include(g => g.Users)
                                        .Include(g => g.Messages)
                                        .ToListAsync();
        }
        public ICollection<MessengerGroup> GetAllEmpty()
        {
            return this._context.MessengerGroups
                                    .ToList();
        }
        public async Task<ICollection<MessengerGroup>> GetAllEmptyAsync()
        {
            return await this._context.MessengerGroups
                                    .ToListAsync();
        }
        public IQueryable<MessengerGroup> GetAllQueryable()
        {
            return this._context.MessengerGroups;
        }
        public async Task<MessengerGroup> GetAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = await this._context.MessengerGroups
                        .Include(g => g.Users)
                        .Include(g => g.Messages)
                        .FirstOrDefaultAsync(g => g.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public MessengerGroup GetEmpty(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = this._context.MessengerGroups
                        .FirstOrDefault(g => g.ID == id);
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            return obj;
        }
        public async Task<MessengerGroup> GetEmptyAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var obj = await this._context.MessengerGroups
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
        public void Update(MessengerGroup obj)
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