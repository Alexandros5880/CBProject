﻿using CBProject.HelperClasses.Interfaces;
using CBProject.Models;
using CBProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CBProject.Repositories
{
    public class RatingsRepository : IRepository<Rating>, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private bool disposedValue;
        public RatingsRepository(IUnitOfWork unitOfWork)
        {
            _context = unitOfWork.Context;
        }
        public void Add(Rating rating)
        {
            if (rating == null)
                throw new ArgumentNullException(nameof(rating));

            _context.Ratings.Add(rating);
        }
        public void Delete(int id)
        {
            var rating = Get(id);

            if (rating == null)
                throw new ArgumentNullException(nameof(rating));
            
            _context.Ratings.Remove(rating);
        }
        public Rating Get(int id)
        {
            return _context.Ratings.Find(id);
        }
        public ICollection<Rating> GetAll()
        {
            return _context.Ratings.ToList();
        }
        public ICollection<Rating> GetAllEmpty()
        {
            throw new NotImplementedException();
        }
        public Rating GetEmpty(int id)
        {
            throw new NotImplementedException();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void Update(Rating rating)
        {
            if (rating == null)
                throw new ArgumentNullException(nameof(rating));

            _context.Entry(rating).State = EntityState.Modified;

        }
        public void Delete(int? id)
        {
            throw new NotImplementedException();
        }
        public Rating Get(int? id)
        {
            throw new NotImplementedException();
        }
        public Rating GetEmpty(int? id)
        {
            throw new NotImplementedException();
        }
        // TODO: RatingsRepository Async
        public Task<int> UpdateAsync(Rating obj)
        {
            throw new NotImplementedException();
        }
        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }
        public Task<Rating> GetEmptyAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Rating> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<ICollection<Rating>> GetAllEmptyAsync()
        {
            throw new NotImplementedException();
        }
        public Task<ICollection<Rating>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<int> AddAsync(Rating obj)
        {
            throw new NotImplementedException();
        }
        public Task<Rating> GetAsync(int? id)
        {
            throw new NotImplementedException();
        }
        public Task<Rating> GetEmptyAsync(int? id)
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