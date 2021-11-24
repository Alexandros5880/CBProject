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
    public class CategoryRepository : IRepository<Category>, IDisposable
    {
        private bool disposedValue;
        private ApplicationDbContext _context { get; set; }
        public CategoryRepository(IUnitOfWork unitOfWork)
        {
            _context = unitOfWork.Context;
        }
        public void Add(Category obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            _context.Categories.Add(obj);
        }
        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var category = _context.Categories.FirstOrDefault(c => c.ID == id);
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            _context.Categories.Remove(category);
        }
        public Category Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return _context.Categories
                 .Include(c => c.Categories)
                 .Include(v => v.Videos)
                 .FirstOrDefault(c => c.ID == id);
        }
        public ICollection<Category> GetAll()
        {
            return _context.Categories
                .Include(c => c.Categories)
                .Include(v => v.Videos)
                .ToList();
        }
        public async Task<ICollection<Category>> GetAllAsync()
        {
            return await _context.Categories
                .Include(c => c.Categories)
                .Include(v => v.Videos)
                .ToListAsync();
        }
        public ICollection<Category> GetAllEmpty()
        {
            return _context.Categories.ToList();
        }
        public async Task<ICollection<Category>> GetAllEmptyAsync()
        {
            return await _context.Categories.ToListAsync();
        }
        public async Task<Category> GetAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return await _context.Categories
                .Include(c => c.Categories)
                .Include(v => v.Videos)
                .FirstAsync(c => c.ID == id);
        }
        public Category GetEmpty(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return _context.Categories
                 .FirstOrDefault(c => c.ID == id);
        }
        public async Task<Category> GetEmptyAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return await _context.Categories
                .FirstAsync(c => c.ID == id);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Update(Category obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            _context.Entry(obj).State = EntityState.Modified;
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