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
    public class ReviewsToEbooksRepository : IRepository<ReviewToEbook>, IDisposable
    {
        private bool disposedValue;

        private readonly ApplicationDbContext _context;

        public ReviewsToEbooksRepository(IUnitOfWork unitOfWork)
        {
            this._context = unitOfWork.Context;
        }

        public void Add(ReviewToEbook obj)
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

        public ReviewToEbook Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));


            throw new NotImplementedException();
        }

        public ICollection<ReviewToEbook> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<ReviewToEbook>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<ReviewToEbook> GetAllEmpty()
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<ReviewToEbook>> GetAllEmptyAsync()
        {
            throw new NotImplementedException();
        }

        public IQueryable<ReviewToEbook> GetAllQueryable()
        {
            throw new NotImplementedException();
        }

        public async Task<ReviewToEbook> GetAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));


            throw new NotImplementedException();
        }

        public ReviewToEbook GetEmpty(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));


            throw new NotImplementedException();
        }

        public async Task<ReviewToEbook> GetEmptyAsync(int? id)
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

        public void Update(ReviewToEbook obj)
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