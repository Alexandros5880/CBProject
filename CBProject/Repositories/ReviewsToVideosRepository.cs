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
    public class ReviewsToVideosRepository : IRepository<ReviewToVideo>, IDisposable
    {
        private bool disposedValue;

        private readonly ApplicationDbContext _context;

        public ReviewsToVideosRepository(IUnitOfWork unitOfWork)
        {
            this._context = unitOfWork.Context;
        }

        public void Add(ReviewToVideo obj)
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

        public ReviewToVideo Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));


            throw new NotImplementedException();
        }

        public ICollection<ReviewToVideo> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<ReviewToVideo>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<ReviewToVideo> GetAllEmpty()
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<ReviewToVideo>> GetAllEmptyAsync()
        {
            throw new NotImplementedException();
        }

        public IQueryable<ReviewToVideo> GetAllQueryable()
        {
            throw new NotImplementedException();
        }

        public async Task<ReviewToVideo> GetAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));


            throw new NotImplementedException();
        }

        public ReviewToVideo GetEmpty(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));


            throw new NotImplementedException();
        }

        public async Task<ReviewToVideo> GetEmptyAsync(int? id)
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

        public void Update(ReviewToVideo obj)
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