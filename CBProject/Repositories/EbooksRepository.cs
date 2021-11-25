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
    public class EbooksRepository : IRepository<Ebook>, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private bool disposedValue;
        public EbooksRepository(IUnitOfWork unitOfWork)
        {
            _context = unitOfWork.Context;
        }
        public void Add(Ebook ebook)
        {
            if (ebook == null)
                throw new ArgumentNullException(nameof(ebook));
            _context.Ebooks.Add(ebook);
        }
        public void Update(Ebook ebook)
        {
           if(ebook == null)
                throw new ArgumentNullException(nameof(ebook));
            _context.Entry(ebook).State = EntityState.Modified;
        }
        public Ebook Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return _context.Ebooks
                .Include(c => c.Category)
                .Include(c => c.Tags).Include(c => c.Reviews)
                .Include(c => c.Ratings)
                .Include(e => e.Category)
                .Include(e => e.ContentCreator)
                .FirstOrDefault(e=>e.ID == id);
        }
        public ICollection<Ebook> GetAll()
        {
            return _context.Ebooks.Include(c => c.Category)
                .Include(c => c.Tags).Include(c => c.Reviews)
                .Include(c => c.Ratings).ToList();
        }
        public void Delete(int? id)
        {
           
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var ebook = Get(id);
            if(ebook == null)
                throw new ArgumentNullException(nameof(id));
            _context.Ebooks.Remove(ebook);
        }
        public async Task<ICollection<Ebook>> GetAllAsync()
        {

            return await _context.Ebooks.Include(c => c.Category)
                .Include(c => c.Tags).Include(c => c.Reviews)
                .Include(c => c.Ratings).ToListAsync();
        }
        public ICollection<Ebook> GetAllEmpty()
        {
            return _context.Ebooks.ToList();
        }
        public async Task<ICollection<Ebook>> GetAllEmptyAsync()
        {
            return await this._context.Ebooks
                .ToListAsync();

        }
        public async Task<Ebook> GetAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var ebook = await _context.Ebooks.Include(c => c.Category)
                 .Include(c => c.Tags).Include(c => c.Reviews)
                 .Include(c => c.Ratings)
                 .Include(e => e.Category)
                 .Include(e => e.ContentCreator)
                 .FirstAsync(e => e.ID == id);
            if(ebook == null)
                throw new ArgumentNullException(nameof(ebook));
            return ebook;

        }
        public Ebook GetEmpty(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return _context.Ebooks.FirstOrDefault(e => e.ID == id);
        }
        public async Task<Ebook> GetEmptyAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var ebook = await _context.Ebooks.FindAsync(id);
            if (ebook == null)
                throw new ArgumentNullException(nameof(ebook));
            return ebook;

        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Save()
        {
            _context.SaveChanges();
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