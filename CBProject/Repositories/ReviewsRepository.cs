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
        //----------------------ASYNC------------------------------------------

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

    }
}