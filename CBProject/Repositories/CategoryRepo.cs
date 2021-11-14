using CBProject.Models;
using CBProject.Models.EntityModels;
using CBProject.Models.Interfaces;
using CBProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CBProject.Repositories
{
    public class CategoryRepo : IRepository<Category>
    {
        private ApplicationDbContext _context { get; set; }
        public CategoryRepo(IContext context)
        {
            _context = (ApplicationDbContext)context;
        }
        public void Add(Category obj)
        {
            if( obj == null )
                throw new ArgumentNullException(nameof(obj));
            _context.Categories.Add(obj);
        }
        public void Delete(int? id)
        {
            if(id == null)
                throw new ArgumentNullException(nameof(id));
            var category = _context.Categories.FirstOrDefault(c => c.ID == id);
            if(category == null)
                throw new ArgumentNullException(nameof(category));
            _context.Categories.Remove(category);
        }
        public Category Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
           return _context.Categories
                .Include(c => c.Categories)
                .FirstOrDefault(c => c.ID == id);
        }

        public ICollection<Category> GetAll()
        {
            return _context.Categories
                .Include(c => c.Categories)
                .ToList();
        }

        public async Task<ICollection<Category>> GetAllAsync()
        {
            return await _context.Categories
                .Include(c => c.Categories)
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
            if(obj == null)
                throw new ArgumentNullException(nameof(obj));
            _context.Entry(obj).State = EntityState.Modified;
        }
    }
}