using CBProject.Areas.Forum.Models.EntityModels;
using CBProject.Areas.Messenger.Repositories.Interfaces;
using CBProject.HelperClasses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBProject.Areas.Messenger.Repositories
{
    public class MesMessagesRepository : IRepository<MessengerMessage>, IDisposable
    {
        private bool disposedValue;

        public MesMessagesRepository(IUnitOfWork unitOfWork)
        {

        }

        public void Add(MessengerMessage obj)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int? id)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int? id)
        {
            throw new System.NotImplementedException();
        }

        public MessengerMessage Get(int? id)
        {
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
            throw new System.NotImplementedException();
        }

        public MessengerMessage GetEmpty(int? id)
        {
            throw new System.NotImplementedException();
        }

        public Task<MessengerMessage> GetEmptyAsync(int? id)
        {
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
            throw new System.NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {

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