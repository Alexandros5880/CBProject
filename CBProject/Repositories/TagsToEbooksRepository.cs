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
    public class TagsToEbooksRepository : IRepository<TagToEbook>, IDisposable
    {
        private bool disposedValue;

        private readonly ApplicationDbContext _context;

        public TagsToEbooksRepository(IUnitOfWork unitOfWork)
        {
            this._context = unitOfWork.Context;
        }

        public void Add(TagToEbook obj)
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

        public TagToEbook Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));


            throw new NotImplementedException();
        }

        public ICollection<TagToEbook> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<TagToEbook>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<TagToEbook> GetAllEmpty()
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<TagToEbook>> GetAllEmptyAsync()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TagToEbook> GetAllQueryable()
        {
            throw new NotImplementedException();
        }

        public async Task<TagToEbook> GetAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));


            throw new NotImplementedException();
        }

        public TagToEbook GetEmpty(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));


            throw new NotImplementedException();
        }

        public async Task<TagToEbook> GetEmptyAsync(int? id)
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

        public void Update(TagToEbook obj)
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