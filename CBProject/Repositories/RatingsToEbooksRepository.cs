using CBProject.HelperClasses.Interfaces;
using CBProject.Models;
using CBProject.Models.EntityModels;
using CBProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CBProject.Repositories
{
    public class RatingsToEbooksRepository : IRepository<RatingToEbook>, IDisposable
    {
        private bool disposedValue;
        private ApplicationDbContext _context { get; set; }
        public RatingsToEbooksRepository(IUnitOfWork unitOfWork)
        {
            this._context = unitOfWork.Context;
        }
        public void Add(RatingToEbook obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.RatingsToEbooks.Add(obj);
        }
        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var ratingToEbook = this._context.RatingsToEbooks
                                    .FirstOrDefault(r => r.ID == id);
            if (ratingToEbook == null)
                throw new ArgumentNullException(nameof(ratingToEbook));
            this._context.RatingsToEbooks.Remove(ratingToEbook);
        }
        public async Task DeleteAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var ratingToEbook = await this._context.RatingsToEbooks
                                        .FirstOrDefaultAsync(r => r.ID == id);
            if (ratingToEbook == null)
                throw new ArgumentNullException(nameof(ratingToEbook));
            this._context.RatingsToEbooks.Remove(ratingToEbook);
        }
        public RatingToEbook Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var ratingToEbook = this._context.RatingsToEbooks
                                            .Include(r => r.Ebook)
                                            .Include(r => r.Rating)
                                            .FirstOrDefault(r => r.ID == id);
            if (ratingToEbook == null)
                throw new ArgumentNullException(nameof(ratingToEbook));
            return ratingToEbook;
        }
        public ICollection<RatingToEbook> GetAll()
        {
            return this._context.RatingsToEbooks
                                .Include(r => r.Ebook)
                                .Include(r => r.Rating)
                                .ToList();
        }
        public async Task<ICollection<RatingToEbook>> GetAllAsync()
        {
            return await this._context.RatingsToEbooks
                                .Include(r => r.Ebook)
                                .Include(r => r.Rating)
                                .ToListAsync();
        }
        public ICollection<RatingToEbook> GetAllEmpty()
        {
            return this._context.RatingsToEbooks.ToList();
        }
        public async Task<ICollection<RatingToEbook>> GetAllEmptyAsync()
        {
            return await this._context.RatingsToEbooks.ToListAsync();
        }
        public IQueryable<RatingToEbook> GetAllQueryable()
        {
            return this._context.RatingsToEbooks;
        }
        public async Task<RatingToEbook> GetAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var ratingToEbook = await this._context.RatingsToEbooks
                                        .Include(r => r.Ebook)
                                        .Include(r => r.Rating)
                                        .FirstOrDefaultAsync(r => r.ID == id);
            if (ratingToEbook == null)
                throw new ArgumentNullException(nameof(ratingToEbook));
            return ratingToEbook;
        }
        public RatingToEbook GetEmpty(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var ratingToEbook = this._context.RatingsToEbooks
                                .FirstOrDefault(r => r.ID == id);
            if (ratingToEbook == null)
                throw new ArgumentNullException(nameof(ratingToEbook));
            return ratingToEbook;
        }
        public async Task<RatingToEbook> GetEmptyAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var ratingToEbook = await this._context.RatingsToEbooks
                                .FirstOrDefaultAsync(r => r.ID == id);
            if (ratingToEbook == null)
                throw new ArgumentNullException(nameof(ratingToEbook));
            return ratingToEbook;
        }
        public void Save()
        {
            this._context.SaveChanges();
        }
        public async Task<int> SaveAsync()
        {
            return await this._context.SaveChangesAsync();
        }
        public void Update(RatingToEbook obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.Entry(obj).State = EntityState.Modified;
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