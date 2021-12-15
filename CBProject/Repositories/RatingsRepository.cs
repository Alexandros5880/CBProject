﻿using CBProject.HelperClasses.Interfaces;
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
    public class RatingsRepository : IRepository<Rating>, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private bool disposedValue;
        public RatingsRepository(IUnitOfWork unitOfWork)
        {
            this._context = unitOfWork.Context;
        }
        public void Add(Rating obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.Ratings.Add(obj);
        }
        public void Update(Rating obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var rating = this.Get(id);
            if (rating == null)
                throw new ArgumentNullException(nameof(rating));
            this._context.Ratings.Remove(rating);
        }
        public Rating Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return this._context.Ratings
                .Include(r => r.Rater)
                .Include(r => r.Video)
                .FirstOrDefault(r => r.ID == id);
        }
        public async Task<Rating> GetAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return await this._context.Ratings
                .Include(r => r.Rater)
                .Include(r => r.Video)
                .FirstOrDefaultAsync(r => r.ID == id);
        }
        public Rating GetEmpty(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return this._context.Ratings
                .FirstOrDefault(r => r.ID == id);
        }
        public async Task<Rating> GetEmptyAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return await this._context.Ratings
                .FirstOrDefaultAsync(r => r.ID == id);
        }
        public ICollection<Rating> GetAll()
        {
            return this._context.Ratings
                .Include(r => r.Rater)
                .Include(r => r.Video)
                .ToList();
        }
        public async Task<ICollection<Rating>> GetAllAsync()
        {
            return await this._context.Ratings
                .Include(r => r.Rater)
                .Include(r => r.Video)
                .ToListAsync();
        }
        public ICollection<Rating> GetAllEmpty()
        {
            return this._context.Ratings.ToList();
        }
        public async Task<ICollection<Rating>> GetAllEmptyAsync()
        {
            return await this._context.Ratings.ToListAsync();
        }
        public ICollection<Rating> GetAllOtherFromVideo(Video video)
        {
            if (video == null)
                throw new ArgumentNullException(nameof(video));
            return this._context.Ratings
                .Where(r => !video.Ratings.Contains(r))
                .ToList();
        }
        public async Task<ICollection<Rating>> GetAllOtherFromVideoAsync(Video video)
        {
            if (video == null)
                throw new ArgumentNullException(nameof(video));
            return await this._context.Ratings
                .Where(r => !video.Ratings.Contains(r))
                .ToListAsync();
        }
        public ICollection<Rating> GetAllFromVideo(Video video)
        {
            if (video == null)
                throw new ArgumentNullException(nameof(video));
            return this._context.Ratings
                .Where(r => video.Ratings.Contains(r))
                .ToList();
        }
        public async Task<ICollection<Rating>> GetAllFromVideoAsync(Video video)
        {
            if (video == null)
                throw new ArgumentNullException(nameof(video));
            return await this._context.Ratings
                .Where(r => video.Ratings.Contains(r))
                .ToListAsync();
        }
        public ICollection<Rating> GetAllOtherFromEbook(Ebook ebook)
        {
            if (ebook == null)
                throw new ArgumentNullException(nameof(ebook));
            return this._context.Ratings
                .Where(r => !ebook.Ratings.Contains(r))
                .ToList();
        }
        public async Task<ICollection<Rating>> GetAllOtherFromEbookAsync(Ebook ebook)
        {
            if (ebook == null)
                throw new ArgumentNullException(nameof(ebook));
            return await this._context.Ratings
                .Where(r => !ebook.Ratings.Contains(r))
                .ToListAsync();
        }
        public ICollection<Rating> GetAllFromEbook(Ebook ebook)
        {
            if (ebook == null)
                throw new ArgumentNullException(nameof(ebook));
            return this._context.Ratings
                .Where(r => ebook.Ratings.Contains(r))
                .ToList();
        }
        public async Task<ICollection<Rating>> GetAllFromEbookAsync(Ebook ebook)
        {
            if (ebook == null)
                throw new ArgumentNullException(nameof(ebook));
            return await this._context.Ratings
                .Where(r => ebook.Ratings.Contains(r))
                .ToListAsync();
        }
        public void Save()
        {
            this._context.SaveChanges();
        }
        public async Task<int> SaveAsync()
        {
            return await this._context.SaveChangesAsync();
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