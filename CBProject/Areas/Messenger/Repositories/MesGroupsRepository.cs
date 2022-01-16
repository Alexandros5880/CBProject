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
            throw new NotImplementedException();
        }

        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            throw new NotImplementedException();
        }

        public MessengerGroup Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            throw new NotImplementedException();
        }

        public ICollection<MessengerGroup> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<MessengerGroup>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<MessengerGroup> GetAllEmpty()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<MessengerGroup>> GetAllEmptyAsync()
        {
            throw new NotImplementedException();
        }

        public IQueryable<MessengerGroup> GetAllQueryable()
        {
            throw new NotImplementedException();
        }

        public Task<MessengerGroup> GetAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            throw new NotImplementedException();
        }

        public MessengerGroup GetEmpty(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            throw new NotImplementedException();
        }

        public Task<MessengerGroup> GetEmptyAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(MessengerGroup obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            throw new NotImplementedException();
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