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
    public class TagsRepository : IRepository<Tag>, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private bool disposedValue;
        public TagsRepository(IUnitOfWork unitOfWork)
        {
            _context = unitOfWork.Context;
        }
        public void Add(Tag tag)
        {
            if (tag == null)
                throw new ArgumentNullException(nameof(tag));

            _context.Tags.Add(tag);
        }
        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));


            var tag = Get(id);

            if (tag == null)
                throw new Exception("Tag Not Found");

            _context.Tags.Remove(tag);
        }
        public Tag Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return _context.Tags
                .Include(t=>t.Videos)
                .SingleOrDefault(t=>t.Id == id);
        }
        public ICollection<Tag> GetAll()
        {
            return _context.Tags
                .Include(t=>t.Videos)
                .ToList();
        }       
        public ICollection<Tag> GetAllEmpty()
        {
            return _context.Tags.ToList();
        }      
        public Tag GetEmpty(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return _context.Tags.Find(id);
        }        
        public void Save()
        {
            _context.SaveChanges();
        }       
        public void Update(Tag tag)
        {
            if (tag == null)
                throw new ArgumentNullException(nameof(tag));

            _context.Entry(tag).State = EntityState.Modified;
        }
        // TODO: TagsRepository Async
        public Task<int> UpdateAsync(Tag obj)
        {
            throw new NotImplementedException();
        }
        public Task<int> AddAsync(Tag obj)
        {
            throw new NotImplementedException();
        }
        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }
        public Task<Tag> GetEmptyAsync(int? id)
        {
            throw new NotImplementedException();
        }
        public Task<Tag> GetAsync(int? id)
        {
            throw new NotImplementedException();
        }
        public Task<ICollection<Tag>> GetAllEmptyAsync()
        {
            throw new NotImplementedException();
        }
        public Task<ICollection<Tag>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public Task<int> DeleteAsync(int? id)
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