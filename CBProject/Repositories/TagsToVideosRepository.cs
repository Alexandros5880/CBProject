using CBProject.HelperClasses.Interfaces;
using CBProject.Models;
using CBProject.Models.EntityModels;
using CBProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBProject.Repositories
{
    public class TagsToVideosRepository : IRepository<TagToVideo>, IDisposable
    {
        private bool disposedValue;

        private readonly ApplicationDbContext _context;

        public TagsToVideosRepository(IUnitOfWork unitOfWork)
        {
            this._context = unitOfWork.Context;
        }

        public void Add(TagToVideo obj)
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

        public async Task DeleteAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));


            throw new NotImplementedException();
        }

        public TagToVideo Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));


            throw new NotImplementedException();
        }

        public ICollection<TagToVideo> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<TagToVideo>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<TagToVideo> GetAllEmpty()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<TagToVideo>> GetAllEmptyAsync()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TagToVideo> GetAllQueryable()
        {
            throw new NotImplementedException();
        }

        public async Task<TagToVideo> GetAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));


            throw new NotImplementedException();
        }

        public TagToVideo GetEmpty(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));


            throw new NotImplementedException();
        }

        public async Task<TagToVideo> GetEmptyAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));


            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public async Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(TagToVideo obj)
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