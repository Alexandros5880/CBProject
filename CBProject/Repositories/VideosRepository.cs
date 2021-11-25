using CBProject.HelperClasses.Interfaces;
using CBProject.Models;
using CBProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CBProject.Repositories
{
    public class VideosRepository :  IDisposable
    {
        private readonly ApplicationDbContext _context;
        private bool disposedValue;
        public VideosRepository(IUnitOfWork unitOfWork)
        {
            _context = unitOfWork.Context;
        }

        public IEnumerable<Video> GetVideosCC(string userId)
        {
            return GetAll().Where(v => v.CreatorId == userId);
        }

        public void Add(Video video)
        {
            if(video == null)
                throw new ArgumentNullException(nameof(video));

            _context.Videos.Add(video);
        }
        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            
            var video = Get(id);


            if (video == null)
                throw new ArgumentNullException(nameof(video));

            _context.Videos.Remove(video);
        }
        public Video Get(int? id)
        {
            return _context.Videos
                .Include(v=>v.Reviews)
                .Include(v => v.Ratings)
                .Include(v => v.Tags)
                .SingleOrDefault(v=>v.Id == id);
        }
        public IEnumerable<Video> GetAll()
        {
            return _context.Videos
                .Include(v => v.Reviews)
                .Include(v => v.Ratings)
                .Include(v => v.Tags);
        }
        public IEnumerable<Video> GetAllEmpty()
        {
            
            return _context.Videos.ToList();
        }
        public Video GetEmpty(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return _context.Videos.Find(id);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void Update(Video video)
        {
            if (video == null)
                throw new ArgumentNullException(nameof(video));

            _context.Entry(video).State = EntityState.Modified;
        }
        // TODO: VideosRepository Async
        public Task<int> UpdateAsync(Video obj)
        {
            throw new NotImplementedException();
        }
        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }
        public Task<Video> GetEmptyAsync(int? id)
        {
            throw new NotImplementedException();
        }
        public Task<Video> GetAsync(int? id)
        {
            throw new NotImplementedException();
        }
        public Task<ICollection<Video>> GetAllEmptyAsync()
        {
            throw new NotImplementedException();
        }
        public Task<ICollection<Video>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public Task<int> DeleteAsync(int? id)
        {
            throw new NotImplementedException();
        }
        public Task<int> AddAsync(Video obj)
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