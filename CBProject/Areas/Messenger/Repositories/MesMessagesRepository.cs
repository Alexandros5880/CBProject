using CBProject.Areas.Forum.Models.EntityModels;
using CBProject.Areas.Messenger.Repositories.Interfaces;
using CBProject.HelperClasses.Interfaces;
using CBProject.Models;
using System;
using System.Collections.Generic;
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
            throw new System.NotImplementedException();
        }

        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            throw new System.NotImplementedException();
        }

        public MessengerMessage Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            throw new System.NotImplementedException();
        }

        public ICollection<MessengerMessage> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<ICollection<MessengerMessage>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public ICollection<MessengerMessage> GetAllEmpty()
        {
            throw new System.NotImplementedException();
        }

        public Task<ICollection<MessengerMessage>> GetAllEmptyAsync()
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<MessengerMessage> GetAllQueryable()
        {
            throw new System.NotImplementedException();
        }

        public Task<MessengerMessage> GetAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            throw new System.NotImplementedException();
        }

        public MessengerMessage GetEmpty(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            throw new System.NotImplementedException();
        }

        public Task<MessengerMessage> GetEmptyAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new System.NotImplementedException();
        }

        public void Update(MessengerMessage obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            throw new System.NotImplementedException();
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