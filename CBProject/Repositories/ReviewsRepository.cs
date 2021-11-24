using CBProject.HelperClasses.Interfaces;
using CBProject.Models;
using CBProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CBProject.Repositories
{
    public class ReviewsRepository : IRepository<Review>, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private bool disposedValue;
        public ReviewsRepository(IUnitOfWork unitOfWork)
        {
            _context = unitOfWork.Context;
        }
        public void Add(Review review)
        {
            if (review == null)
                throw new ArgumentNullException(nameof(review));

            _context.Reviews.Add(review);
        }        
        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            
            var review = Get(id);

            if (review == null)
                throw new ArgumentNullException(nameof(review));

            _context.Reviews.Remove(review);
        }        
        public Review Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id)); 

            return _context.Reviews.Find(id);
        }
        public ICollection<Review> GetAll()
        {
            return _context.Reviews
                .Include(r=>r.Video)
                .Include(r=>r.Reviewer)
                .ToList();
        }        
        public ICollection<Review> GetAllEmpty()
        {

            return _context.Reviews.ToList();
        }        
        public Review GetEmpty(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return _context.Reviews
                .Include(r => r.Video)
                .Include(r => r.Reviewer)
                .SingleOrDefault(r=>r.Id == id);
        }        
        public void Save()
        {
            _context.SaveChanges();
        }        
        public void Update(Review review)
        {
            if (review == null)
                throw new ArgumentNullException(nameof(review));

            _context.Entry(review).State = EntityState.Modified;
        }
        public Task<int> UpdateAsync(Review obj)
        {
            throw new NotImplementedException();
        }
        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }
        public Task<Review> GetEmptyAsync(int? id)
        {
            throw new NotImplementedException();
        }
        public Task<Review> GetAsync(int? id)
        {
            throw new NotImplementedException();
        }
        public Task<ICollection<Review>> GetAllEmptyAsync()
        {
            throw new NotImplementedException();
        }
        public Task<ICollection<Review>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<int> AddAsync(Review obj)
        {
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