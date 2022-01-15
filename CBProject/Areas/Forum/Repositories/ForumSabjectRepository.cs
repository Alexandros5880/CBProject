using CBProject.Areas.Forum.Models.EntityModels;
using CBProject.Areas.Forum.Repositories.Interfaces;
using CBProject.HelperClasses.Interfaces;
using System;
using System.Threading.Tasks;

namespace CBProject.Areas.Forum.Repositories
{
    public class ForumSabjectRepository :  IRepository<ForumSabject>, IDisposable
    {
        private bool disposedValue;

        public ForumSabjectRepository(IUnitOfWork unitOfWork)
        {

        }

        public void Add(ForumSabject obj)
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

        public ForumSabject Get(int? id)
        {
            throw new System.NotImplementedException();
        }

        public System.Collections.Generic.ICollection<ForumSabject> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<System.Collections.Generic.ICollection<ForumSabject>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public System.Collections.Generic.ICollection<ForumSabject> GetAllEmpty()
        {
            throw new System.NotImplementedException();
        }

        public Task<System.Collections.Generic.ICollection<ForumSabject>> GetAllEmptyAsync()
        {
            throw new System.NotImplementedException();
        }

        public System.Linq.IQueryable<ForumSabject> GetAllQueryable()
        {
            throw new System.NotImplementedException();
        }

        public Task<ForumSabject> GetAsync(int? id)
        {
            throw new System.NotImplementedException();
        }

        public ForumSabject GetEmpty(int? id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ForumSabject> GetEmptyAsync(int? id)
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

        public void Update(ForumSabject obj)
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