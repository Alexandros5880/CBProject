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
        private CategoriesRepository _categoriesRepository { get; set; }
        public CategoryToCategoryRepository(IUnitOfWork unitOfWork)
        {
            this._context = unitOfWork.Context;
            this._categoriesRepository = unitOfWork.Categories;
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
                    MasterCategory = this._categoriesRepository.Get(parentId),
                    ChiledCategory = this._categoriesRepository.Get(chiledId)
                };
                this.Add(cc);
                this.Save();
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
                    MasterCategory = this._categoriesRepository.Get(parentId),
                    ChiledCategory = this._categoriesRepository.Get(chiledId)
                };
                this.Add(cc);
                await this.SaveAsync();
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
                this.Save();
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
                await this.SaveAsync();
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
        public ICollection<CategoryToCategory> GetAllWhereParentId(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return this._context.CategoriesToCategories
                .Where(cc => cc.ChiledCategoryId == id)
                .ToList();
        }
        public async Task<ICollection<CategoryToCategory>> GetAllWhereParentIdAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return await this._context.CategoriesToCategories
                .Where(cc => cc.ChiledCategoryId == id)
                .ToListAsync();
        }
        public ICollection<CategoryToCategory> GetAllOtherWhereParentId(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return this._context.CategoriesToCategories
                .Where(cc => cc.ChiledCategoryId != id)
                .ToList();
        }
        public async Task<ICollection<CategoryToCategory>> GetAllOtherWhereParentIdAsync(int? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            return await this._context.CategoriesToCategories
                .Where(cc => cc.ChiledCategoryId != id)
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
                    this._categoriesRepository.Dispose();
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