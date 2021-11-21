using CBProject.Models;
using CBProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CBProject.Repositories
{
    public class ReviewsRepository : IRepository<Review>
    {
        private readonly ApplicationDbContext _context;

        public ReviewsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public void Add(Review review)
        {
            if (review == null)
                throw new ArgumentNullException(nameof(review));

            _context.Reviews.Add(review);
        }        

        public void Delete(int id)
        {
            var review = Get(id);

            if (review == null)
                throw new ArgumentNullException(nameof(review));

            _context.Reviews.Remove(review);
        }        

        public Review Get(int id)
        {
            return _context.Reviews.Find(id);
        }

        public ICollection<Review> GetAll()
        {
            return _context.Reviews.ToList();
        }        

        public ICollection<Review> GetAllEmpty()
        {
            throw new NotImplementedException();
        }        

        public Review GetEmpty(int id)
        {
            throw new NotImplementedException();
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
        //----------------------ASYNC------------------------------------------

        public Task<int> UpdateAsync(Review obj)
        {
            throw new NotImplementedException();
        }
        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }
        public Task<Review> GetEmptyAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Review> GetAsync(int id)
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

    }
}