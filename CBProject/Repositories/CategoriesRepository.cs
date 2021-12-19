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
    public class CategoriesRepository : IRepository<Category>, IDisposable
    {
        private bool disposedValue;
        private ApplicationDbContext _context { get; set; }
        private CategoryToCategoryRepository _categoriesToCategoriesRepo { get; set; }
        public CategoriesRepository(IUnitOfWork unitOfWork)
        {
            this._context = unitOfWork.Context;
            this._categoriesToCategoriesRepo = unitOfWork.CategoryToCategory;
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
        public ICollection<Category> GetAll()
        {
            return _context.Categories
                .Include(c => c.CategoriesToCategories)
                .Include(v => v.Videos)
                .ToList();
        }
        public async Task<ICollection<Category>> GetAllAsync()
        {
            return await _context.Categories
                .Include(c => c.CategoriesToCategories)
                .Include(v => v.Videos)
                .ToListAsync();
        }
        public ICollection<Category> GetOtherAll(int? id)
        {
            var ccids = this._categoriesToCategoriesRepo
                .GetAllOtherWhereParentId(id);
            var parents = this._categoriesToCategoriesRepo
                                     .GetAllParentsWithChiledId(id);
            return _context.Categories
                .Include(c => c.CategoriesToCategories)
                .Include(v => v.Videos)
                .Where(c => id != c.ID)
                .Where(c => !ccids.Contains(c.ID))
                .Where(c => !parents.Contains(c.ID))
                .ToList();
        }
        public async Task<ICollection<Category>> GetOtherAllAsync(int? id)
        {
            var ccids = await this._categoriesToCategoriesRepo
                .GetAllOtherWhereParentIdAsync(id);
            var parents = await this._categoriesToCategoriesRepo
                                     .GetAllParentsWithChiledIdAsync(id);
            var categories = await _context.Categories
                .Include(c => c.CategoriesToCategories)
                .Include(v => v.Videos)
                .Where(c => id != c.ID)
                .Where(c => !ccids.Contains(c.ID))
                .Where(c => !parents.Contains(c.ID))
                .ToListAsync();
            return categories;
        }
        public ICollection<Category> GetMyAll(int? id)
        {
            var ccids = this._categoriesToCategoriesRepo
                .GetAllWhereParentId(id);
            return _context.Categories
                .Include(c => c.CategoriesToCategories)
                .Include(v => v.Videos)
                .Where(c => id != c.ID && ccids.Contains(c.ID))
                .ToList();
        }
        public async Task<ICollection<Category>> GetMyAllAsync(int? id)
        {
            var ccids = await this._categoriesToCategoriesRepo
                .GetAllWhereParentIdAsync(id);
            return await _context.Categories
                .Include(c => c.CategoriesToCategories)
                .Include(v => v.Videos)
                .Where(c => id != c.ID && ccids.Contains(c.ID))
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
        public IQueryable<Category> GetAllQueryable()
        {
            return this._context.Categories
                .Include(c => c.CategoriesToCategories)
                .Include(c => c.Videos)
                .Include(c => c.Ebooks);
        }
        public async Task<Category> GetAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return await _context.Categories
                .Include(c => c.CategoriesToCategories)
                .Include(v => v.Videos)
                .FirstOrDefaultAsync(c => c.ID == id);
        }
        public Category Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return _context.Categories
                 .Include(c => c.CategoriesToCategories)
                 .Include(v => v.Videos)
                 .FirstOrDefault(c => c.ID == id);
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
                .FirstOrDefaultAsync(c => c.ID == id);
        }
        public Category GetByName(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            return _context.Categories
                 .Include(c => c.CategoriesToCategories)
                 .Include(v => v.Videos)
                 .FirstOrDefault(c => c.Name == name);
        }
        public async Task<Category> GetByNameAsync(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            return await _context.Categories
                 .Include(c => c.CategoriesToCategories)
                 .Include(v => v.Videos)
                 .FirstOrDefaultAsync(c => c.Name == name);
        }
        public void AddCategory(Category parent, Category chiled)
        {
            if (parent == null)
                throw new ArgumentNullException(nameof(parent));
            if (chiled == null)
                throw new ArgumentNullException(nameof(chiled));
            this._categoriesToCategoriesRepo.AddChiled(parent.ID, chiled.ID);
        }
        public async Task AddCategoryAsync(Category parent, Category chiled)
        {
            if (parent == null)
                throw new ArgumentNullException(nameof(parent));
            if (chiled == null)
                throw new ArgumentNullException(nameof(chiled));
            await this._categoriesToCategoriesRepo.AddChiledAsync(parent.ID, chiled.ID);
        }
        public void AddCategories(Category parent, ICollection<int> categoriesIds)
        {
            if (parent == null)
                throw new ArgumentNullException(nameof(parent));
            if (categoriesIds.Count == 0)
                throw new InvalidOperationException("Sequence contains no elements");
            foreach (var id in categoriesIds)
            {
                this._categoriesToCategoriesRepo.AddChiled(parent.ID, id);
            }
        }
        public async Task AddCategoriesAsync(Category parent, ICollection<int> categoriesIds)
        {
            if (parent == null)
                throw new ArgumentNullException(nameof(parent));
            if (categoriesIds.Count == 0)
                throw new InvalidOperationException("Sequence contains no elements");
            foreach (var id in categoriesIds)
            {
                await this._categoriesToCategoriesRepo.AddChiledAsync(parent.ID, id);
            }
        }
        public void RemoveCategory(Category parent, Category chiled)
        {
            if (parent == null)
                throw new ArgumentNullException(nameof(parent));
            if (chiled == null)
                throw new ArgumentNullException(nameof(chiled));
            this._categoriesToCategoriesRepo.RemoveChiled(parent.ID, chiled.ID);
        }
        public async Task RemoveCategoryAsync(Category parent, Category chiled)
        {
            if (parent == null)
                throw new ArgumentNullException(nameof(parent));
            if (chiled == null)
                throw new ArgumentNullException(nameof(chiled));
            await this._categoriesToCategoriesRepo.RemoveChiledAsync(parent.ID, chiled.ID);
        }
        public void RemoveCategories(Category parent, ICollection<int> categoriesIds)
        {
            if (parent == null)
                throw new ArgumentNullException(nameof(parent));
            if (categoriesIds.Count == 0)
                throw new InvalidOperationException("Sequence contains no elements");
            foreach (var id in categoriesIds)
            {
                this._categoriesToCategoriesRepo.RemoveChiled(parent.ID, id);
            }
        }
        public async Task RemoveCategoriesAsync(Category parent, ICollection<int> categoriesIds)
        {
            if (parent == null)
                throw new ArgumentNullException(nameof(parent));
            if (categoriesIds.Count == 0)
                throw new InvalidOperationException("Sequence contains no elements");
            foreach (var id in categoriesIds)
            {
                await this._categoriesToCategoriesRepo.RemoveChiledAsync(parent.ID, id);
            }
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
                    this._categoriesToCategoriesRepo.Dispose();
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