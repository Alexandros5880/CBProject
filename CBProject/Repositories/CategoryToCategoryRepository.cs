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
    public class CategoryToCategoryRepository : IRepository<CategoryToCategory>, IDisposable
    {
        private bool disposedValue;
        private ApplicationDbContext _context { get; set; }
        public CategoryToCategoryRepository(IUnitOfWork unitOfWork)
        {
            this._context = unitOfWork.Context;
        }
        public void Add(CategoryToCategory obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            this._context.CategoriesToCategories.Add(obj);
        }
        public void AddChiled(int? parentId, int? chiledId)
        {
            if (parentId == null)
                throw new ArgumentNullException(nameof(parentId));
            if (chiledId == null)
                throw new ArgumentNullException(nameof(chiledId));
            var ccs = this._context.CategoriesToCategories
                .Where(catcat => catcat.MasterCategoryId == parentId && catcat.ChiledCategoryId == chiledId)
                .ToList();
            if (ccs.Count == 0)
            {
                CategoryToCategory cc = new CategoryToCategory()
                {
                    MasterCategory = this._context.Categories.FirstOrDefault(c => c.ID == parentId),
                    ChiledCategory = this._context.Categories.FirstOrDefault(c => c.ID == chiledId),
                };
                this.Add(cc);
            }
        }
        public async Task AddChiledAsync(int? parentId, int? chiledId)
        {
            if (parentId == null)
                throw new ArgumentNullException(nameof(parentId));
            if (chiledId == null)
                throw new ArgumentNullException(nameof(chiledId));
            var ccs = await this._context.CategoriesToCategories
                .Where(catcat => catcat.MasterCategoryId == parentId && catcat.ChiledCategoryId == chiledId)
                .ToListAsync();
            if (ccs.Count == 0)
            {
                CategoryToCategory cc = new CategoryToCategory()
                {
                    MasterCategory = this._context.Categories.FirstOrDefault(c => c.ID == parentId),
                    ChiledCategory = this._context.Categories.FirstOrDefault(c => c.ID == chiledId),
                };
                this.Add(cc);
            }
        }
        public void RemoveChiled(int? parentId, int? chiledId)
        {
            if (parentId == null)
                throw new ArgumentNullException(nameof(parentId));
            if (chiledId == null)
                throw new ArgumentNullException(nameof(chiledId));
            var ccs = this._context.CategoriesToCategories
                .Where(catcat => catcat.MasterCategoryId == parentId && catcat.ChiledCategoryId == chiledId)
                .ToList();
            if (ccs.Count != 0)
            {
                foreach (var c in ccs)
                {
                    this._context.CategoriesToCategories.Remove(c);
                }
            }
        }
        public async Task RemoveChiledAsync(int? parentId, int? chiledId)
        {
            if (parentId == null)
                throw new ArgumentNullException(nameof(parentId));
            if (chiledId == null)
                throw new ArgumentNullException(nameof(chiledId));
            var ccs = await this._context.CategoriesToCategories
                .Where(catcat => catcat.MasterCategoryId == parentId && catcat.ChiledCategoryId == chiledId)
                .ToListAsync();
            if (ccs.Count != 0)
            {
                foreach(var c in ccs)
                {
                    this._context.CategoriesToCategories.Remove(c);
                }
            }
        }
        public void Delete(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            var categoryToCategory = this._context.CategoriesToCategories
                .FirstOrDefault(cc => cc.ID == id);
            if (categoryToCategory == null)
                throw new ArgumentNullException(nameof(categoryToCategory));
            this._context.CategoriesToCategories.Remove(categoryToCategory);
        }
        public CategoryToCategory Get(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return _context.CategoriesToCategories
                 .FirstOrDefault(c => c.ID == id);
        }
        public ICollection<CategoryToCategory> GetAll()
        {
            return this._context.CategoriesToCategories
                .ToList();
        }
        public async Task<ICollection<CategoryToCategory>> GetAllAsync()
        {
            return await this._context.CategoriesToCategories
                .ToListAsync();
        }
        public ICollection<CategoryToCategory> GetAllEmpty()
        {
            return this._context.CategoriesToCategories
                .ToList();
        }
        public async Task<ICollection<CategoryToCategory>> GetAllEmptyAsync()
        {
            return await this._context.CategoriesToCategories
                .ToListAsync();
        }
        public ICollection<int> GetAllWhereParentId(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return this._context.CategoriesToCategories
                .Where(cc => cc.MasterCategoryId == id)
                .Select(cc => cc.ChiledCategoryId)
                .ToList();
        }
        public async Task<ICollection<int>> GetAllWhereParentIdAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return await this._context.CategoriesToCategories
                .Where(cc => cc.MasterCategoryId == id)
                .Select(cc => cc.ChiledCategoryId)
                .ToListAsync();
        }
        public ICollection<int> GetAllOtherWhereParentId(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return this._context.CategoriesToCategories
                .Where(cc => cc.MasterCategoryId == id)
                .Select(cc => cc.ChiledCategoryId)
                .ToList();
        }
        public async Task<ICollection<int>> GetAllOtherWhereParentIdAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return await this._context.CategoriesToCategories
                .Where(cc => cc.MasterCategoryId == id)
                .Select(cc => cc.ChiledCategoryId)
                .ToListAsync();
        }
        public ICollection<int> GetAllParentsWithChiledId(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return this._context.CategoriesToCategories
                .Where(cc => cc.ChiledCategoryId == id)
                .Select(cc => cc.MasterCategoryId)
                .ToList();
        }
        public async Task<ICollection<int>> GetAllParentsWithChiledIdAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return await this._context.CategoriesToCategories
                .Where(cc => cc.ChiledCategoryId == id)
                .Select(cc => cc.MasterCategoryId)
                .ToListAsync();
        }
        public async Task<CategoryToCategory> GetAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return await _context.CategoriesToCategories
                .FirstAsync(c => c.ID == id);
        }
        public CategoryToCategory GetEmpty(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return _context.CategoriesToCategories
                 .FirstOrDefault(c => c.ID == id);
        }
        public async Task<CategoryToCategory> GetEmptyAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return await _context.CategoriesToCategories
                .FirstAsync(c => c.ID == id);
        }
        public IQueryable<CategoryToCategory> GetAllQueryable()
        {
            return this._context.CategoriesToCategories;
        }
        public void Save()
        {
            this._context.SaveChanges();
        }
        public async Task<int> SaveAsync()
        {
            return await this._context.SaveChangesAsync();
        }
        public void Update(CategoryToCategory obj)
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