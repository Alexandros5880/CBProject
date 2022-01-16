using CBProject.Areas.Forum.Models.EntityModels;
using CBProject.Areas.Forum.Repositories.Interfaces;
using CBProject.HelperClasses.Interfaces;
using CBProject.Models;
using System;
using System.Threading.Tasks;

namespace CBProject.Areas.Forum.Repositories
{
    public class ForumSabjectRepository :  IRepository<ForumSabject>, IDisposable
    {
        private bool disposedValue;
        private readonly ApplicationDbContext _context;

        public ForumSabjectRepository(IUnitOfWork unitOfWork)
        {
            this._context = unitOfWork.Context;
        }

        public void Add(ForumSabject obj)
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

        public ForumSabject Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
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
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            throw new System.NotImplementedException();
        }

        public ForumSabject GetEmpty(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            throw new System.NotImplementedException();
        }

        public Task<ForumSabject> GetEmptyAsync(int? id)
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

        public void Update(ForumSabject obj)
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