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
    public class VideosRepository : IRepository<Video>
    {
        private readonly ApplicationDbContext _context;

        public VideosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Video video)
        {
            if(video == null)
                throw new ArgumentNullException(nameof(video));

            _context.Videos.Add(video);
        }

        

        public void Delete(int id)
        {
            var video = Get(id);

            if (video == null)
                throw new ArgumentNullException(nameof(video));

            _context.Videos.Remove(video);
        }

       

        public Video Get(int id)
        {
            return _context.Videos.Find(id);
        }

        public ICollection<Video> GetAll()
        {
            return _context.Videos.ToList();
        }

        

        public ICollection<Video> GetAllEmpty()
        {
            throw new NotImplementedException();
        }


        

        public Video GetEmpty(int id)
        {
            throw new NotImplementedException();
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
        //------------------------------ASYNC----------------------------------------------
        public Task<int> UpdateAsync(Video obj)
        {
            throw new NotImplementedException();
        }
        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }
        public Task<Video> GetEmptyAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Video> GetAsync(int id)
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
        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<int> AddAsync(Video obj)
        {
            throw new NotImplementedException();
        }
    }
}